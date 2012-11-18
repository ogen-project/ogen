ALTER TABLE "FRM_QuestionTriggerQuestion"
  ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFQuestion_fkey" FOREIGN KEY ("IFQuestion")
    REFERENCES "FRM_Question" ("IDQuestion") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFTrigger_fkey" FOREIGN KEY ("IFTrigger")
    REFERENCES "FRM_Trigger" ("IDTrigger") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFQuestion__destination_fkey" FOREIGN KEY ("IFQuestion__destination")
    REFERENCES "FRM_Question" ("IDQuestion") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFUser__audit_fkey" FOREIGN KEY ("IFUser__audit")
    REFERENCES "CRD_User" ("IDUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

