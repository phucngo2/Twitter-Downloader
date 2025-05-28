<script lang="ts">
  import type { Snippet } from "svelte";

  interface Props {
    children?: Snippet;
  }

  let { children }: Props = $props();
</script>

<div class="px-4 overflow-auto md:px-12 h-dvh w-dvw scrollbar-stable">
  <div class="py-12 w-full max-w-[540px] min-w-[288px] mx-auto">
    {@render children?.()}
  </div>
</div>
