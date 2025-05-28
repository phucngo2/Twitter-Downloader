<script lang="ts">
  import { useTweetMediaMutation } from "../queries";
  import ErrorAlert from "./ErrorAlert.svelte";
  import MediaList from "./MediaList.svelte";
  import SearchForm from "./SearchForm.svelte";

  const mutation = useTweetMediaMutation();
  const handleMutation = (tweetUrl: string) => {
    $mutation.mutate(tweetUrl);
  };
</script>

<div class="flex flex-col gap-4">
  <SearchForm onSubmit={handleMutation} isPending={$mutation.isPending} />

  {#if $mutation.isError}
    <ErrorAlert>{$mutation.error.message}</ErrorAlert>
  {:else if $mutation.data}
    <MediaList mediaResponse={$mutation.data} />
  {/if}
</div>
