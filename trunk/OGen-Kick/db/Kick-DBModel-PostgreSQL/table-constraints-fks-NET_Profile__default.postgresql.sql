ALTER TABLE "NET_Profile__default"
  ADD CONSTRAINT "NET_Profile__default_IFProfile_fkey" FOREIGN KEY ("IFProfile")
    REFERENCES "CRD_Profile" ("IDProfile") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

