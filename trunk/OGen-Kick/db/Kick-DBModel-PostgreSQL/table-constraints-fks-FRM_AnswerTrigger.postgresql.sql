ALTER TABLE "FRM_AnswerTrigger"
  ADD CONSTRAINT "FRM_AnswerTrigger_IFAnswer_fkey" FOREIGN KEY ("IFAnswer")
    REFERENCES "FRM_Answer" ("IDAnswer") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_AnswerTrigger_IFTrigger_fkey" FOREIGN KEY ("IFTrigger")
    REFERENCES "FRM_Trigger" ("IDTrigger") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_AnswerTrigger_IFQuestion_fkey" FOREIGN KEY ("IFQuestion")
    REFERENCES "FRM_Question" ("IDQuestion") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_AnswerTrigger_IFUser__audit_fkey" FOREIGN KEY ("IFUser__audit")
    REFERENCES "CRD_User" ("IDUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;
