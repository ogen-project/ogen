<?xml version="1.0" encoding="UTF-8" ?>
<!--

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

-->

<!-- Summary:  !-->
<!-- Created: !-->
<!-- TODO: !-->

<!--Required header !-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="text" encoding="UTF-8" indent="yes" />
<xsl:preserve-space elements="*" />

<xsl:param name="TableName" />

<xsl:template match="/metadata/tables">
<xsl:apply-templates select="table[@name=$TableName]" />
</xsl:template>

<xsl:template match="table">
--- <xsl:value-of select="$TableName" />:
<xsl:for-each select="fields"><xsl:for-each select="field">
<xsl:value-of select="@name" />, <xsl:value-of select="@type" />
</xsl:for-each></xsl:for-each>
---
</xsl:template>

</xsl:stylesheet>