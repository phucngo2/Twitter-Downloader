<script lang="ts">
  import ClearButton from "./ClearButton.svelte";
  import FormInput from "./FormInput.svelte";
  import LoadingButton from "./LoadingButton.svelte";

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
    <ClearButton {tweetUrl} {handleClearInput} />

    <div class="grow">
      <FormInput
        type="text"
        className="w-full"
        placeholder="Paste tweet url here..."
        bind:value={tweetUrl}
      />
    </div>

    <LoadingButton
      disabled={!tweetUrl || isPending}
      type="submit"
      isLoading={isPending}>Search</LoadingButton
    >
  </label>
</form>
