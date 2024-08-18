<script lang="ts">
  let tweetUrl: string = "";

  const handleSubmit = () => {
    if (!tweetUrl) {
      return;
    }
    console.log(tweetUrl);
  };
</script>

<form
  on:submit|preventDefault={handleSubmit}
  class="flex flex-row items-center justify-center gap-2 p-4 card bg-neutral card-bordered"
>
  <label class="flex items-center flex-1 gap-2 pl-3 pr-2 input input-bordered">
    <span>😎</span>
    <input
      type="text"
      class="grow"
      placeholder="Paste tweet url here..."
      bind:value={tweetUrl}
    />
    <button
      disabled={!tweetUrl}
      type="submit"
      class="h-8 min-h-8 btn btn-primary">🔍 Search</button
    >
  </label>
</form>
