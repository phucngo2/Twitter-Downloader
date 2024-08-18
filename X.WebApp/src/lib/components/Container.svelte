<script lang="ts">
  import SearchForm from "./SearchForm.svelte";
  import { useTweetMediaMutation } from "../queries";
  import ErrorAlert from "./ErrorAlert.svelte";

  const mutation = useTweetMediaMutation();
  function handleMutation(event: CustomEvent<string>) {
    $mutation.mutate(event.detail);
  }
</script>

<div class="flex flex-col gap-4">
  <SearchForm on:submit={handleMutation} isPending={$mutation.isPending} />

  {#if $mutation.isError}
    <ErrorAlert message={$mutation.error.message} />
  {:else if $mutation.data}
    <div>{$mutation.data}</div>
  {/if}
</div>
