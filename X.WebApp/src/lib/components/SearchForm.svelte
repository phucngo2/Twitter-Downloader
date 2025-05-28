<script lang="ts">
  interface Props {
    onSubmit: (tweetUrl: string) => void;
    isPending?: boolean;
  }

  let { onSubmit, isPending }: Props = $props();

  let tweetUrl = $state<string>("");

  const handleClearInput = () => {
    tweetUrl = "";
  };

  const handleSubmit = (event: SubmitEvent) => {
    event.preventDefault();

    if (!tweetUrl) {
      return;
    }

    onSubmit(tweetUrl);
  };
</script>

<form
  onsubmit={handleSubmit}
  class="flex flex-row items-center justify-center w-full gap-2 p-4 card bg-neutral card-bordered"
>
  <label
    class="flex items-center flex-1 w-full gap-2 pl-3 pr-2 input input-bordered"
  >
    <!-- Clear Button -->
    {#if tweetUrl}
      <div class="tooltip" data-tip="Clear input...">
        <span
          class="cursor-pointer"
          onclick={handleClearInput}
          onkeydown={handleClearInput}
          role="button"
          aria-label="Clear search input"
          tabindex="0">😵</span
        >
      </div>
    {:else}
      <span>😎</span>
    {/if}
    <!-- Input -->
    <div class="grow">
      <input
        type="text"
        class="w-full"
        placeholder="Paste tweet url here..."
        bind:value={tweetUrl}
      />
    </div>
    <!-- Submit Button -->
    <button
      disabled={!tweetUrl || isPending}
      type="submit"
      class="h-8 min-h-8 btn btn-primary"
    >
      {#if isPending}
        <span class="loading loading-dots loading-sm"></span>
      {:else}
        <span>🔍 </span>
      {/if}
      <span class="hidden md:inline-block">Search</span>
    </button>
  </label>
</form>
