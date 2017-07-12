ALTER TABLE "FRM_FormGroup"
  ADD CONSTRAINT "FRM_FormGroup_IFForm_fkey" FOREIGN KEY ("IFForm")
    REFERENCES "FRM_Form" ("IDForm") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_FormGroup_IFGroup_fkey" FOREIGN KEY ("IFGroup")
    REFERENCES "FRM_Group" ("IDGroup") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FRM_FormGroup_IFUser__audit_fkey" FOREIGN KEY ("IFUser__audit")
    REFERENCES "CRD_User" ("IDUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;
