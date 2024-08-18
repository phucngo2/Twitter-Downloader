<script lang="ts">
  import { QueryClient, QueryClientProvider } from "@tanstack/svelte-query";
  import Container from "./lib/components/Container.svelte";
  import Layout from "./lib/components/Layout.svelte";

  const queryClient = new QueryClient({});
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
