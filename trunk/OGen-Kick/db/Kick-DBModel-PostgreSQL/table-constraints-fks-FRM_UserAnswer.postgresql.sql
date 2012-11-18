ALTER TABLE "FRM_UserAnswer"
  ADD CONSTRAINT "FRM_UserAnswer_IFAnswer_fkey" FOREIGN KEY ("IFAnswer")
    REFERENCES "FRM_Answer" ("IDAnswer") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_UserAnswer_IFUser_fkey" FOREIGN KEY ("IFUser")
    REFERENCES "CRD_User" ("IDUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_UserAnswer_IFUser__audit_fkey" FOREIGN KEY ("IFUser__audit")
    REFERENCES "CRD_User" ("IDUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

