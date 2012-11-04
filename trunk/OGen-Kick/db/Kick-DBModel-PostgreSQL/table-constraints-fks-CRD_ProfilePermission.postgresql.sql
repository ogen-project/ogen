ALTER TABLE "CRD_ProfilePermission"
  ADD CONSTRAINT "CRD_ProfilePermission_IFProfile_fkey" FOREIGN KEY ("IFProfile")
    REFERENCES "CRD_Profile" ("IDProfile") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "CRD_ProfilePermission_IFPermission_fkey" FOREIGN KEY ("IFPermission")
    REFERENCES "CRD_Permission" ("IDPermission") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

