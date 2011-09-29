ALTER TABLE "CRD_ProfileProfile"
  ADD CONSTRAINT "CRD_ProfileProfile_IFProfile_fkey" FOREIGN KEY ("IFProfile")
    REFERENCES "CRD_Profile" ("IDProfile") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "CRD_ProfileProfile_IFProfile_parent_fkey" FOREIGN KEY ("IFProfile_parent")
    REFERENCES "CRD_Profile" ("IDProfile") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

