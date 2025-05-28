<script lang="ts">
  import type { Snippet } from "svelte";

  interface Props {
    disabled?: boolean;
    isLoading?: boolean;
    type?: "button" | "submit" | "reset" | null | undefined;
    children?: Snippet;
  }

  let { disabled, type, isLoading, children }: Props = $props();
</script>

<button {disabled} {type} class="h-8 min-h-8 btn btn-primary">
  {#if isLoading}
    <span class="loading loading-dots loading-sm"></span>
  {:else}
    <span>🔍 </span>
  {/if}
  <span class="hidden md:inline-block">{@render children?.()}</span>
</button>
