import { createMutation } from "@tanstack/svelte-query";
import { axios, TWITTER_API_URL } from "../config";

export const useTweetMediaMutation = () => {
  return createMutation({
    mutationKey: ["tweet-medias"],
    mutationFn: (url: string) => {
      return axios.post(TWITTER_API_URL, {
        url,
      });
    },
  });
};
