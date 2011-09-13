ALTER TABLE "NET_Defaultprofile"
  ADD CONSTRAINT "NET_Defaultprofile_IFProfile_fkey" FOREIGN KEY ("IFProfile")
    REFERENCES "CRD_Profile" ("IDProfile") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

