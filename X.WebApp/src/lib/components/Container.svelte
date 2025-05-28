<script lang="ts">
  import { useTweetMediaMutation } from "../queries";
  import ErrorAlert from "./ErrorAlert.svelte";
  import SearchForm from "./form/SearchForm.svelte";
  import MediaList from "./media-list/MediaList.svelte";

  const mutation = useTweetMediaMutation();
  const handleMutation = (tweetUrl: string) => {
    $mutation.mutate(tweetUrl);
  };
</script>

<div class="flex flex-col gap-4">
  <SearchForm onSubmit={handleMutation} isPending={$mutation.isPending} />

  {#if $mutation.isError}
    <ErrorAlert message={$mutation.error.message || undefined} />
  {:else if $mutation.data}
    <MediaList mediaResponse={$mutation.data} />
  {/if}
</div>
