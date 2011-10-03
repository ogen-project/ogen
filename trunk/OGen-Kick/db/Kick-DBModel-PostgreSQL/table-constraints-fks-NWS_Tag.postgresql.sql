ALTER TABLE "NWS_Tag"
  ADD CONSTRAINT "NWS_Tag_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_Tag_IFTag__parent_fkey" FOREIGN KEY ("IFTag__parent")
    REFERENCES "NWS_Tag" ("IDTag") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_Tag_TX_Name_fkey" FOREIGN KEY ("TX_Name")
    REFERENCES "DIC_Text" ("IDText") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_Tag_IFUser__Approved_fkey" FOREIGN KEY ("IFUser__Approved")
    REFERENCES "NET_User" ("IFUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;
