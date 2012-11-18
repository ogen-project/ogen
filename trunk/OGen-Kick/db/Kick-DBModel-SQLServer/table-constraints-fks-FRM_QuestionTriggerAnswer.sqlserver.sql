ALTER TABLE "FRM_QuestionTriggerAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerAnswer_IFAnswer_fkey" FOREIGN KEY (
		"IFAnswer"
	) REFERENCES "FRM_Answer" (
		"IDAnswer"
	)
GO
ALTER TABLE "FRM_QuestionTriggerAnswer" CHECK CONSTRAINT "FRM_QuestionTriggerAnswer_IFAnswer_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerAnswer_IFQuestion_fkey" FOREIGN KEY (
		"IFQuestion"
	) REFERENCES "FRM_Question" (
		"IDQuestion"
	)
GO
ALTER TABLE "FRM_QuestionTriggerAnswer" CHECK CONSTRAINT "FRM_QuestionTriggerAnswer_IFQuestion_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerAnswer_IFTrigger_fkey" FOREIGN KEY (
		"IFTrigger"
	) REFERENCES "FRM_Trigger" (
		"IDTrigger"
	)
GO
ALTER TABLE "FRM_QuestionTriggerAnswer" CHECK CONSTRAINT "FRM_QuestionTriggerAnswer_IFTrigger_fkey"
GO

ALTER TABLE "FRM_QuestionTriggerAnswer" WITH CHECK 
	ADD CONSTRAINT "FRM_QuestionTriggerAnswer_IFUser__audit_fkey" FOREIGN KEY (
		"IFUser__audit"
	) REFERENCES "CRD_User" (
		"IDUser"
	)
GO
ALTER TABLE "FRM_QuestionTriggerAnswer" CHECK CONSTRAINT "FRM_QuestionTriggerAnswer_IFUser__audit_fkey"
GO

