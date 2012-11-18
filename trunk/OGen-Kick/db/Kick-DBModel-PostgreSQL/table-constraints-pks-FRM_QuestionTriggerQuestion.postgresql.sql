ALTER TABLE "FRM_QuestionTriggerQuestion"
  ADD CONSTRAINT "FRM_QuestionTriggerQuestion_pkey" PRIMARY KEY (
    "IFQuestion",
    "IFTrigger",
    "IFQuestion__destination"
  )
;

