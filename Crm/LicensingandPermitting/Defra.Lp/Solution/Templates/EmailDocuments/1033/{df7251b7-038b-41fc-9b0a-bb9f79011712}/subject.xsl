﻿<?xml version="1.0" ?><xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"><xsl:output method="text" indent="no"/><xsl:template match="/data"><![CDATA[Microsoft Dynamics CRM: ]]><xsl:choose><xsl:when test="asyncoperation/name"><xsl:value-of select="asyncoperation/name" /></xsl:when><xsl:otherwise>Bulk Deletion task</xsl:otherwise></xsl:choose><![CDATA[ Failed]]></xsl:template></xsl:stylesheet>