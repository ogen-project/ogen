ALTER TABLE "CRD_ProfilePermition"
  ADD CONSTRAINT "CRD_ProfilePermition_IFProfile_fkey" FOREIGN KEY ("IFProfile")
    REFERENCES "CRD_Profile" ("IDProfile") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "CRD_ProfilePermition_IFPermition_fkey" FOREIGN KEY ("IFPermition")
    REFERENCES "CRD_Permition" ("IDPermition") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

