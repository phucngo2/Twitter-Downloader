<script lang="ts">
  import SearchForm from "./SearchForm.svelte";
  import { useTweetMediaMutation } from "../queries";

  const mutation = useTweetMediaMutation();
  function handleMutation(event: CustomEvent<string>) {
    $mutation.mutate(event.detail);
  }
</script>

<div>
  <SearchForm on:submit={handleMutation} isPending={$mutation.isPending} />
</div>
