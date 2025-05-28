<script lang="ts">
  interface Props {
    value: string;
    type?: string;
    placeholder?: string;
    className: string;
  }

  let {
    value = $bindable(),
    className,
    placeholder,
    type = "text",
  }: Props = $props();
</script>

<input {type} class={className} {placeholder} bind:value />
