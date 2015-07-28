<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:template match="/">
      <html>
        <body>
          <h2>Students</h2>
          <table border="1">
            <tr bgcolor="#ccc">
              <th>Name</th>
              <th>Gender</th>
              <th>Birthday</th>
              <th>Phone Number</th>
              <th>Email</th>
              <th>University</th>
              <th>Specialty</th>
              <th>Faculty Number</th>
            </tr>
            <xsl:for-each select="students/student">
              <tr>
                <td>
                  <xsl:value-of select="name"/>
                </td>
                <td>
                  <xsl:value-of select="gender"/>
                </td>
                <td>
                  <xsl:value-of select="birthDate"/>
                </td>
                <td>
                  <xsl:value-of select="phoneNumber"/>
                </td>
                <td>
                  <xsl:value-of select="email"/>
                </td>
                <td>
                  <xsl:value-of select="university"/>
                </td>
                <td>
                  <xsl:value-of select="specialty"/>
                </td>
                <td>
                  <xsl:value-of select="facultyNumber"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
