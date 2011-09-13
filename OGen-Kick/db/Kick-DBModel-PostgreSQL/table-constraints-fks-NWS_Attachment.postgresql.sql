ALTER TABLE "NWS_Attachment"
  ADD CONSTRAINT "NWS_Attachment_IFContent_fkey" FOREIGN KEY ("IFContent")
    REFERENCES "NWS_Content" ("IDContent") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_Attachment_TX_Description_fkey" FOREIGN KEY ("TX_Description")
    REFERENCES "DIC_Text" ("IDText") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_Attachment_TX_Name_fkey" FOREIGN KEY ("TX_Name")
    REFERENCES "DIC_Text" ("IDText") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

