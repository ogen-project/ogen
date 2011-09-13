ALTER TABLE "NWS_Highlight"
  ADD CONSTRAINT "NWS_Highlight_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_Highlight_IFHighlight__parent_fkey" FOREIGN KEY ("IFHighlight__parent")
    REFERENCES "NWS_Highlight" ("IDHighlight") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_Highlight_IFUser__Approved_fkey" FOREIGN KEY ("IFUser__Approved")
    REFERENCES "NET_User" ("IFUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

