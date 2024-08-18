export interface TweetVideoVariant {
  bitrate?: number;
  contentType: "video/mp4" | "string";
  url: "string";
}

export interface TweetMedia {
  displayUrl: string;
  expendedUrl: string;
  idStr: string;
  mediaUrlHttps: string;
  type: "video" | "photo" | "animated_gif";
  videoVariants?: TweetVideoVariant[];
}

export interface TweetMediaResponse {
  medias: TweetMedia[];
}
