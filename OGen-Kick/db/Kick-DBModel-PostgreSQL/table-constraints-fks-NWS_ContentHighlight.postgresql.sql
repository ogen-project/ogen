ALTER TABLE "NWS_ContentHighlight"
  ADD CONSTRAINT "NWS_ContentHighlight_IFContent_fkey" FOREIGN KEY ("IFContent")
    REFERENCES "NWS_Content" ("IDContent") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_ContentHighlight_IFHighlight_fkey" FOREIGN KEY ("IFHighlight")
    REFERENCES "NWS_Highlight" ("IDHighlight") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

