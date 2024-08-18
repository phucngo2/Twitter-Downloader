<script lang="ts">
  import type { TweetMediaResponse } from "../types";
  import MediaItem from "./MediaItem.svelte";

  export let mediaResponse: TweetMediaResponse;
</script>

<div class="flex flex-col w-full gap-4">
  {#each mediaResponse.medias as media, index}
    <MediaItem {media} {index} />
  {/each}
</div>
