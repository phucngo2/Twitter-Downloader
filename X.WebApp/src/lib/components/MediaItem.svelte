<script lang="ts">
  import type { TweetMedia } from "../types";

  export let index: number;
  export let media: TweetMedia;

  $: mediaUrl = (() => {
    if (media.type !== "video" || !media.videoVariants) {
      return media.mediaUrlHttps;
    }
    return media.videoVariants.reduce((max, variant) => {
      if (!variant.bitrate) {
        return max;
      }
      return (max.bitrate || 0) > variant.bitrate ? max : variant;
    })?.url;
  })();
</script>

<div class="p-4 card-side card bg-neutral">
  <figure class="w-1/3">
    <img src={media.mediaUrlHttps} alt="Media preview" />
  </figure>
  <div class="py-0 pr-0 card-body">
    <div class="card-title">Media #{index + 1}: {media.type}</div>
    <div class="mt-auto ml-auto">
      <a
        href={mediaUrl}
        target="_blank"
        rel="noreferrer"
        class="px-3 truncate h-9 btn btn-secondary min-h-9"
        >🚀 Open in new tab</a
      >
    </div>
  </div>
</div>
