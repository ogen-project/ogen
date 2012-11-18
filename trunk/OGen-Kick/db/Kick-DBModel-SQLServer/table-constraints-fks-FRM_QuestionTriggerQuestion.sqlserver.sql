ALTER TABLE "FRM_QuestionTriggerQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFQuestion_fkey" FOREIGN KEY (
		"IFQuestion"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_QuestionTriggerQuestion" CHECK CONSTRAINT "FRM_QuestionTriggerQuestion_IFQuestion_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFTrigger_fkey" FOREIGN KEY (
		"IFTrigger"
	) REFERENCES "FRM_Trigger" (
		"IDTrigger"
	)
GO
ALTER TABLE "FRM_QuestionTriggerQuestion" CHECK CONSTRAINT "FRM_QuestionTriggerQuestion_IFTrigger_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFQuestion__destination_fkey" FOREIGN KEY (
		"IFQuestion__destination"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_QuestionTriggerQuestion" CHECK CONSTRAINT "FRM_QuestionTriggerQuestion_IFQuestion__destination_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerQuestion" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerQuestion_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_QuestionTriggerQuestion" CHECK CONSTRAINT "FRM_QuestionTriggerQuestion_IFUser__audit_fkey"
GO

