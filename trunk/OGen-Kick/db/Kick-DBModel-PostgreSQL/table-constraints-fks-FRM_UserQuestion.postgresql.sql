ALTER TABLE "FRM_UserQuestion"
  ADD CONSTRAINT "FRM_UserQuestion_IFQuestion_fkey" FOREIGN KEY ("IFQuestion")
    REFERENCES "FRM_Question" ("IDQuestion") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_UserQuestion_IFUser__audit_fkey" FOREIGN KEY ("IFUser__audit")
    REFERENCES "CRD_User" ("IDUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_UserQuestion_IFUser_fkey" FOREIGN KEY ("IFUser")
    REFERENCES "CRD_User" ("IDUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;
