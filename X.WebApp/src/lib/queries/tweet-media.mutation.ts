import { createMutation } from "@tanstack/svelte-query";
import { axios, TWITTER_API_URL } from "../config";
import type { TweetMediaResponse } from "../types";

export const useTweetMediaMutation = () => {
  return createMutation({
    mutationKey: ["tweet-medias"],
    mutationFn: async (url: string) => {
      return (
        await axios.post<TweetMediaResponse>(TWITTER_API_URL, {
          url,
        })
      ).data;
    },
  });
};
