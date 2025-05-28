<script lang="ts">
  interface Props {
    tweetUrl: string;
    handleClearInput: () => void;
  }

  let { tweetUrl, handleClearInput }: Props = $props();
</script>

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
