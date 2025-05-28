<script lang="ts">
  import { QueryClientProvider } from "@tanstack/svelte-query";
  import Container from "./lib/components/Container.svelte";
  import Layout from "./lib/components/Layout.svelte";
  import { queryClient } from "./lib/config";
</script>

<main class="app">
  <QueryClientProvider client={queryClient}>
    <Layout>
      <Container />
    </Layout>
  </QueryClientProvider>
</main>

<style>
</style>
