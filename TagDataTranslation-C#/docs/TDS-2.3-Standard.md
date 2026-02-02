EPC Tag Data Standard TDS
defines the Electronic Product Code™ and specifies the memory contents of Gen 2
RFID Tags
Release 2.3, Ratified, Oct 2025
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 2 of 448
Document Summary
Document Item Current Value
Document Name EPC Tag Data Standard TDS
Document Date Oct 2025
Document Version 2.3
Document Issue
Document Status Ratified
Document Description defines the Electronic Product Code™ and specifies the memory contents of Gen 2 RFID Tags
Contributors
Name Organisation
Jaewook Byun Auto-ID Labs at KAIST
Jin Mitsugi Auto-ID Labs at Keio University
HJ Cha Avery Dennison RFID
Jeanne Duckett Avery Dennison RFID
John Gallant Avery Dennison RFID
Akane Mitsui Avery Dennison RFID
Kevin Berisso BAIT Consulting
Shi Yu Beijing REN JU ZHI HUI Technology Co. Ltd.
Tony Ceder Charming RFID
Josef Preishuber-Pflügl CISC Semiconductor GmbH
François-Régis Dousset DANONE SPA
Olivier Joyez DECATHLON
Michael Isabell CCL eAgile
Jim Springer EM Microelectronic
Odarci Maia Junior EMPRESA BRASILEIRA DE CORREIOS E TELEGRAFOS
Julie McGill FoodLogiQ
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 3 of 448
Name Organisation
Guilda Javaheri Golden State Foods
Aruna Ravikumar GS1 Australia
Sue Schmid GS1 Australia
Jeroen van Weperen GS1 Australia
Ethan Ward GS1 Australia
Eugen Sehorz GS1 Austria
Luiz Costa GS1 Brasil
Roberto Matsubayashi GS1 Brasil
Huipeng Deng GS1 China
Zhimin Li GS1 China
Gao Peng GS1 China
Yi Wang GS1 China
Ruoyun Yan GS1 China
Marisa Lu GS1 Chinese Taipei
Sandra Hohenecker GS1 Germany
Roman Winter GS1 Germany
Steven Keddie GS1 Global Office
Timothy Marsh GS1 Global Office
```
Craig Alan Repec (editor) GS1 Global Office
```
Greg Rowe GS1 Global Office
John Ryu GS1 Global Office
Claude Tetelin GS1 Global Office
Elena Tomanovich GS1 Global Office
Mohit Tomar GS1 Global Office
Wayne Luk GS1 Hong Kong, China
K K Suen GS1 Hong Kong, China
Judit Egri GS1 Hungary
Linda Vezzani GS1 Italy
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 4 of 448
Name Organisation
Koji Asano GS1 Japan
Kazuna Kimura GS1 Japan
Noriyuki Mama GS1 Japan
Mayu Sasase GS1 Japan
Yuki Sato GS1 Japan
Sergio Pastrana GS1 Mexico
Sarina Pielaat GS1 Netherlands
Gary Hartley GS1 New Zealand
Alice Mukaru GS1 Sweden
Heinz Graf GS1 Switzerland
Shawn Chen GS1 US
Norma Crockett GS1 US
Jonathan Gregory GS1 US
Andrew Meyer GS1 US
Gena Morgan GS1 US
Amber Walls GS1 US
Megan Brewster Impinj, Inc
Shinichi Ike Johnson & Johnson
Blair Korman Johnson & Johnson
Fabian Moritz Schenk Lambda ID GmbH
Don Ferguson Lyngsoe Systems Ltd.
```
Mark Harrison (editor) Milecastle Media Limited
```
Danny Haak Nedap
Chris Brown Printronix Auto ID
Jeffrey Chen Printronix Auto ID
Marisa Campos PROAGRIND, Lda.
Akshay Koshti Robert Bosch GmbH
Holly Mitchell Seagull Scientific
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 5 of 448
Name Organisation
Mo Ramzan SML
Jerome Torro SNCF Rolling Stock Department
Albertus Pretorius Tonnjes ISI Patent Holding GmbH
Masatoshi Oka TOPPAN
Taira Wakamiya TOPPAN
Elizabeth Waldorf TraceLink
Log of Changes
Release Date of Change Changed By Summary of Change
1.9.1 8 July 2015 D. Buckley New GS1 branding applied
1.10 Mar 2017 Craig Alan Repec Listed in full in the Abstract below
1.11 Sep 2017 Craig Alan Repec Listed in full in the Abstract below
1.12 April 2019 Craig Alan Repec and Mark
Harrison
WR 19-076
Added EPC URI for UPUI, to support EU 2018/574, as well as EPC
```
URI for PGLN – GLN of Party AI (417) – in accordance with GS1
```
```
General Specifications 19.1;
```
Added normative specificatons around handling of GCP length for
```
individually assigned GS1 Keys;
```
```
Corrected ITIP pure identity pattern syntax;
```
Introduced "Fixed Width Integer" encoding and decoding sections in
support of ITIP binary encoding.
```
1.13 September 2019 Craig Alan Repec WR 19-262 Added IMOVN EPC for IMO Vessel Number;
```
```
WR 19-264 corrected GSIN syntax erratum in section 6.3.12;
```
corrected UPUI example erratum in section 7.16.
2.0 Aug 2022 Mark Harrison and Craig Alan
Repec
```
Major release; see comprehensive summary of changes in the
```
```
"Differences from EPC Tag Data Standard (TDS) Version 1.13"
```
section, immediately proceeding section 1.
Note that TDS will be updated as necessary to harmonise with GS1's
Gen2 v3 Air Interface Protocol, once that standard has been
published.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 6 of 448
Release Date of Change Changed By Summary of Change
2.1 Feb 2024 Mark Harrison and Craig Alan
Repec
Update to correct minor errors and errata in version 2.0.
Updated URI grammar in sections 12 and 13.
```
Clarified use of ISO/IEC 20248 DigSig, using GS1 AI (8030), in
```
section 17.
Updated section 9.2, including Figure 9-1 and Table 9-2, to reflect
encoding of ISO/IEC 20248 DigSig in User Memory.
Updated section 9.3, Figure 9-2 and Table 9-3 to reflect the Read
```
User Memory (RUM) indicator specified in Gen2v3.
```
Updated Table 9-4 to reflect Gen2v3 assignments to bits 214h-217h
of XPC.
Updated section 16 to reflect mandatory serialisation of TID
specified in Gen2v3.
```
Also added support for AIs (7241), (7242), (8030), (4330), (4331),
```
```
(4332), (4333) and (7011).
```
Additionally, the Packed Objects ID Table for Data Format 9 in
Section F.2 has been supplemented with an external, normative
artefact in CSV format.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 7 of 448
Release Date of Change Changed By Summary of Change
2.2 Feb 2025 Mark Harrison and
Craig Alan Repec
Updates to align with TDT 2.2.
Changed encoding method names and descriptions on section 14.5,
to allow for leading zeros:
■ "Fixed-Bit-Length Integer" is changed to "Fixed-Bit-Length
Numeric String"
■ "Variable-length integer" is changed to "Variable Length Numeric
string"
■ "Variable-length integer without encoding indicator" is changed to
"Variable-Length Numeric String without encoding indicator"
Added "Optional minus sign in 1 bit" encoding method
Added "Sequence indicator" encoding method
Added the following AIs to Packed objects ID Tables in sections F.1
```
and F.2 as well as TDS / TDT Table F (used for encoding additional
```
AIDC after the EPC binary string within EPC/UII memory, for new
```
EPC schemes introduced in TDS 2.0 only):
```
• 7002
• 7041
• 716
• 7250
• 7251
• 7252
• 7253
• 7254
• 7255
• 7256
• 7257
• 7258
• 7259
2.3 Oct 2025 Mark Harrison and
Craig Alan Repec
Introduction of twelve new ‘++’ EPC schemes, SGTIN++ and
DSGTIN++ that are modelled on existing schemes SGTIN+ and
DSGTIN+ but extended to support binary encoding of a custom
domain name after the serial number, to better support translation
back to non-canonical GS1 Digital Link URIs. Other new ‘++’ EPC
schemes introduced in TDS 2.3 have a similar relationship to the
corresponding ‘+’ EPC schemes introduced in TDS 2.0, adding
support for encoding of a custom domain name.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 8 of 448
Disclaimer
GS1 seeks to minimise barriers to the adoption of its standards and guidelines by making the intellectual property required to implement them available, to the greatest
extent possible, on a royalty-free basis, or when necessary, under a RAND licence. Such royalty-free and RAND licences are provided pursuant to the GS1 IP Policy
```
(available here: https://www.gs1.org/standards/ip), which governs the work of work group participants who contribute to drafting standards and guidelines, including
```
this document. In addition to licences, the GS1 IP Policy provides various benefits and obligations that apply to all implementers of GS1 standards and guidelines, and
all implementations of GS1 standards are subject to those terms.
Nevertheless, please note the possibility that an implementation of one or more features of this standard or guideline may be the subject of a patent or other
intellectual property right that is not covered by the licences granted pursuant to the IP Policy. In addition, the licences granted under the IP Policy do not include the IP
rights or claims of third parties who were not participants in the corresponding standard development work group.
Accordingly, GS1 recommends that any person or organisation developing an implementation of this standard or guideline should determine whether any patents or
other intellectual property may encompass such implementation, and whether a licence under a patent or other IP right is needed. The implementer should determine
the potential need for licensing in view of the details of the specific implementation being designed in consultation with that party's patent counsel.
```
The official versions of all GS1 standards and guidelines are provided as PDF files on GS1's online reference directory (https://ref.gs1.org) (the "GS1 Reference"). Any
```
```
other representations of standards or guidelines in any other format (e.g., web pages) are provided for convenience and descriptive purposes only, and in the event of a
```
conflict, the GS1 Reference document shall govern.
THIS DOCUMENT IS PROVIDED “AS IS” WITH NO WARRANTIES WHATSOEVER, EXPRESS OR IMPLIED, INCLUDING ANY WARRANTY OF MERCHANTABILITY,
NONINFRINGEMENT, FITNESS FOR PARTICULAR PURPOSE, ACCURACY OR COMPLETENESS, OR ANY WARRANTY OTHERWISE ARISING OUT OF THIS DOCUMENT. GS1
disclaims all liability for any damages arising from any use or misuse of this document, whether special, indirect, consequential, or compensatory damages, and
including liability for infringement of any intellectual property rights, relating to use of information in or reliance upon this document.
GS1 makes no commitment to update the information contained herein, and retains the right to make changes to this document at any time, without notice. GS1® and
the GS1 logo are registered trademarks of GS1 AISBL.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 9 of 448
Table of Contents
Foreword ......................................................................................................................................................... 23
1 Introduction .............................................................................................................................................. 35
2 Terminology and typographical conventions ............................................................................................. 36
3 Overview of TDS........................................................................................................................................ 37
4 The Electronic Product Code: A universal identifier for physical objects ................................................... 41
4.1 The need for a universal identifier: an example ........................................................................................................................ 41
4.2 Use of identifiers in a Business Data Context ...........................................................................................................................43
4.3 Relationship between EPCs and GS1 keys ...............................................................................................................................44
4.4 Use of the EPC in the GS1 System Architecture ........................................................................................................................ 49
5 Common grammar elements .................................................................................................................... 52
6 EPC URI .................................................................................................................................................... 54
6.1 Use of the EPC URI ..............................................................................................................................................................54
6.2 Assignment of EPCs to physical objects ...................................................................................................................................55
6.3 EPC URI syntax ...................................................................................................................................................................55
```
6.3.1 Serialised Global Trade Item Number (SGTIN) ................................................................................................................. 58
```
```
6.3.2 Serial Shipping Container Code (SSCC) ..........................................................................................................................59
```
```
6.3.3 Global Location Number With or Without Extension (SGLN) ............................................................................................... 59
```
```
6.3.4 Global Returnable Asset Identifier (GRAI) ....................................................................................................................... 60
```
```
6.3.5 Global Individual Asset Identifier (GIAI).......................................................................................................................... 61
```
```
6.3.6 Global Service Relation Number – Recipient (GSRN) ......................................................................................................... 62
```
```
6.3.7 Global Service Relation Number – Provider (GSRNP) ......................................................................................................... 62
```
```
6.3.8 Global Document Type Identifier (GDTI) .........................................................................................................................63
```
```
6.3.9 Component / Part Identifier (CPI) ..................................................................................................................................63
```
```
6.3.10 Serialised Global Coupon Number (SGCN) ....................................................................................................................... 64
```
```
6.3.11 Global Identification Number for Consignment (GINC) ...................................................................................................... 65
```
```
6.3.12 Global Shipment Identification Number (GSIN) ................................................................................................................ 66
```
```
6.3.13 Individual Trade Item Piece (ITIP) .................................................................................................................................66
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 10 of 448
```
6.3.14 Unit Pack Identifier (UPUI) ............................................................................................................................................67
```
```
6.3.15 Global Location Number of Party (PGLN) .........................................................................................................................68
```
```
6.3.16 General Identifier (GID) ...............................................................................................................................................68
```
```
6.3.17 US Department of Defense Identifier (DOD) .................................................................................................................... 69
```
```
6.3.18 Aerospace and Defense Identifier (ADI) ..........................................................................................................................70
```
```
6.3.19 BIC Container Code (BIC) .............................................................................................................................................71
```
```
6.3.20 IMO Vessel Number (IMOVN) ........................................................................................................................................72
```
6.4 EPC Class URI Syntax ..........................................................................................................................................................73
```
6.4.1 GTIN + Batch/Lot (LGTIN) ............................................................................................................................................74
```
7 Correspondence between EPCs and GS1 Keys .......................................................................................... 75
```
7.1 The GS1 Company Prefix (GCP) in EPC encodings ..................................................................................................................... 75
```
7.2 Determining length of the EPC CompanyPrefix component for individually assigned GS1 Keys ......................................................... 75
7.2.1 Individually assigned GTINs ..........................................................................................................................................75
7.2.2 Individually assigned GLNs ...........................................................................................................................................76
7.2.3 Other individually assigned GS1 Keys .............................................................................................................................76
```
7.3 Serialised Global Trade Item Number (SGTIN) .........................................................................................................................77
```
7.3.1 GTIN-12 and GTIN-13 ..................................................................................................................................................79
7.3.2 GTIN-8 ......................................................................................................................................................................79
7.3.3 RCN-8 .......................................................................................................................................................................80
```
7.3.4 Company Internal Numbering (GS1 Prefixes 04 and 0001 – 0007)...................................................................................... 80
```
```
7.3.5 Restricted Circulation (GS1 Prefixes 02 and 20 – 29) ........................................................................................................ 80
```
```
7.3.6 Coupon Code Identification for Restricted Distribution (GS1 Prefixes 981-984 and 99) ........................................................... 80
```
```
7.3.7 Refund Receipt (GS1 Prefix 980) ...................................................................................................................................81
```
```
7.3.8 ISBN, ISMN, and ISSN (GS1 Prefixes 977, 978, or 979) .................................................................................................... 81
```
```
7.4 Serial Shipping Container Code (SSCC) ...................................................................................................................................82
```
```
7.5 Global Location Number With or Without Extension (SGLN)........................................................................................................ 83
```
```
7.6 Global Returnable Asset Identifier (GRAI)................................................................................................................................ 86
```
```
7.7 Global Individual Asset Identifier (GIAI) ..................................................................................................................................88
```
```
7.8 Global Service Relation Number – Recipient (GSRN) ................................................................................................................. 90
```
```
7.9 Global Service Relation Number – Provider (GSRNP) ................................................................................................................. 91
```
```
7.10 Global Document Type Identifier (GDTI) .................................................................................................................................93
```
```
7.11 Component and Part Identifier (CPI) ......................................................................................................................................94
```
```
7.12 Serialised Global Coupon Number (SGCN) ...............................................................................................................................96
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 11 of 448
```
7.13 Global Identification Number for Consignment (GINC) ............................................................................................................... 97
```
```
7.14 Global Shipment Identification Number (GSIN) ........................................................................................................................ 99
```
```
7.15 Individual Trade Item Piece (ITIP)........................................................................................................................................ 100
```
```
7.16 Unit Pack Identifier (UPUI) .................................................................................................................................................. 102
```
```
7.17 Global Location Number of Party (PGLN) ............................................................................................................................... 103
```
```
7.18 GTIN + batch/lot (LGTIN) ................................................................................................................................................... 105
```
8 URIs for EPC Pure identity patterns ....................................................................................................... 107
8.1 Syntax ............................................................................................................................................................................. 107
8.2 Semantics ........................................................................................................................................................................ 111
9 Memory Organisation of Gen 2 RFID tags .............................................................................................. 112
9.1 Types of Tag Data ............................................................................................................................................................. 112
9.2 Gen 2 Tag Memory Map ...................................................................................................................................................... 113
9.3 PC bits ............................................................................................................................................................................. 119
9.4 XPC bits ........................................................................................................................................................................... 121
10 Filter Value ....................................................................................................................................... 123
10.1 Use of "Reserved" and "All Others" Filter Values ..................................................................................................................... 123
10.2 Filter Values for SGTIN and DSGTIN+ / DSGTIN++ EPC Tags .................................................................................................. 123
10.3 Filter Values for SSCC EPC Tags........................................................................................................................................... 124
10.4 Filter Values for SGLN EPC Tags........................................................................................................................................... 125
10.5 Filter Values for GRAI EPC Tags ........................................................................................................................................... 125
10.6 Filter Values for GIAI EPC Tags ............................................................................................................................................ 125
10.7 Filter Values for GSRN and GSRNP EPC Tags .......................................................................................................................... 126
10.8 Filter Values for GDTI EPC Tags ........................................................................................................................................... 126
10.9 Filter Values for CPI EPC Tags ............................................................................................................................................. 127
10.10 Filter Values for SGCN EPC Tags .......................................................................................................................................... 127
10.11 Filter Values for ITIP EPC Tags ............................................................................................................................................ 128
10.12 Filter Values for GID EPC Tags ............................................................................................................................................. 128
10.13 Filter Values for DOD EPC Tags ............................................................................................................................................ 128
10.14 Filter Values for ADI EPC Tags ............................................................................................................................................. 128
```
11 Attribute bits (refer to 9.3 and 9.4) .................................................................................................. 131
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 12 of 448
12 EPC Tag URI and EPC Raw URI ......................................................................................................... 132
12.1 Structure of the EPC Tag URI and EPC Raw URI ..................................................................................................................... 132
12.2 Control Information ........................................................................................................................................................... 134
12.2.1 Filter Values ............................................................................................................................................................. 134
12.2.2 Other control information fields ................................................................................................................................... 134
12.3 EPC Tag URI and EPC Pure Identity URI ................................................................................................................................ 136
12.3.1 EPC Binary Coding Schemes ....................................................................................................................................... 136
12.3.2 EPC Pure Identity URI to EPC Tag URI .......................................................................................................................... 140
12.3.3 EPC Tag URI to EPC Pure Identity URI .......................................................................................................................... 141
12.4 Grammar ......................................................................................................................................................................... 141
13 URIs for EPC Tag Encoding patterns ................................................................................................. 144
13.1 Syntax ............................................................................................................................................................................. 145
13.2 Semantics ........................................................................................................................................................................ 147
14 EPC Binary Encoding ......................................................................................................................... 148
14.1 Overview of Binary Encoding ............................................................................................................................................... 148
14.2 EPC Binary Headers ........................................................................................................................................................... 149
14.3 Encoding procedure ........................................................................................................................................................... 153
14.3.1 "Integer" Encoding Method ......................................................................................................................................... 153
14.3.2 "String" Encoding method ........................................................................................................................................... 154
14.3.3 "Partition Table" Encoding method ............................................................................................................................... 155
14.3.4 "Unpadded Partition Table" Encoding method ................................................................................................................ 156
14.3.5 "String Partition Table" Encoding method ...................................................................................................................... 157
14.3.6 "Numeric String" Encoding method .............................................................................................................................. 158
14.3.7 "6-bit CAGE/DODAAC" Encoding method ....................................................................................................................... 159
14.3.8 "6-Bit Variable String" Encoding method ....................................................................................................................... 159
14.3.9 "6-Bit Variable String Partition Table" Encoding method .................................................................................................. 160
14.3.10 "Fixed Width Integer" Encoding Method ........................................................................................................................ 161
14.4 Decoding procedure ........................................................................................................................................................... 162
14.4.1 "Integer" Decoding method......................................................................................................................................... 163
14.4.2 "String" Decoding method .......................................................................................................................................... 163
14.4.3 "Partition Table" Decoding method ............................................................................................................................... 164
14.4.4 "Unpadded Partition Table" Decoding method ................................................................................................................ 165
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 13 of 448
14.4.5 "String Partition Table" Decoding method...................................................................................................................... 165
14.4.6 "Numeric String" Decoding method .............................................................................................................................. 166
14.4.7 "6-Bit CAGE/DoDAAC" Decoding method ....................................................................................................................... 167
14.4.8 "6-Bit Variable String" Decoding method ....................................................................................................................... 168
14.4.9 "6-Bit Variable String Partition Table" Decoding method .................................................................................................. 169
14.4.10 "Fixed Width Integer" Decoding method ....................................................................................................................... 170
14.5 Encoding/Decoding methods introduced in TDS 2.0 ................................................................................................................ 170
14.5.1 "+AIDC Data Toggle Bit" ............................................................................................................................................ 172
14.5.2 "Fixed-Bit-Length Numeric String" ............................................................................................................................... 174
14.5.3 "Prioritised Date"....................................................................................................................................................... 175
14.5.4 "Fixed-Length Numeric" ............................................................................................................................................. 177
14.5.5 "Delimited/Terminated Numeric" ................................................................................................................................. 179
14.5.6 "Variable-length alphanumeric" ................................................................................................................................... 182
14.5.7 "Single data bit" ........................................................................................................................................................ 202
14.5.8 "6-digit date YYMMDD"............................................................................................................................................... 203
14.5.9 "10-digit date+time YYMMDDhhmm" ............................................................................................................................ 204
14.5.10 "Variable-format date / date range" ............................................................................................................................. 207
14.5.11 "Variable-precision date+time" .................................................................................................................................... 210
```
14.5.12 "Country code (ISO 3166-1 alpha-2)"........................................................................................................................... 214
```
14.5.13 "Variable-length numeric string without encoding indicator" ............................................................................................. 217
14.5.14 "Optional minus sign in 1 bit" ...................................................................................................................................... 218
14.5.15 "Sequence indicator" ................................................................................................................................................. 219
14.5.16 "Custom domain name or hostname" ........................................................................................................................... 221
14.6 EPC Binary coding tables .................................................................................................................................................... 236
```
14.6.1 Serialised Global Trade Item Number (SGTIN) ............................................................................................................... 237
```
```
14.6.2 Serial Shipping Container Code (SSCC) ........................................................................................................................ 243
```
```
14.6.3 Global Location Number with or without Extension (SGLN) .............................................................................................. 247
```
```
14.6.4 Global Returnable Asset Identifier (GRAI) ..................................................................................................................... 251
```
```
14.6.5 Global Individual Asset Identifier (GIAI)........................................................................................................................ 255
```
```
14.6.6 Global Service Relation Number - Recipient (GSRN) ....................................................................................................... 259
```
```
14.6.7 Global Service Relation Number - Provider (GSRNP) ....................................................................................................... 262
```
```
14.6.8 Global Document Type Identifier (GDTI) ....................................................................................................................... 266
```
```
14.6.9 CPI Identifier (CPI) .................................................................................................................................................... 272
```
```
14.6.10 Global Coupon Number (SGCN) ................................................................................................................................... 279
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 14 of 448
```
14.6.11 Individual Trade Item Piece (ITIP) ............................................................................................................................... 283
```
```
14.6.12 General Identifier (GID) ............................................................................................................................................. 288
```
14.6.13 DoD Identifier ........................................................................................................................................................... 289
```
14.6.14 ADI Identifier (ADI) ................................................................................................................................................... 289
```
15 EPC Memory Bank contents .............................................................................................................. 291
15.1 Encoding procedures .......................................................................................................................................................... 291
15.1.1 EPC Tag URI into Gen 2 EPC Memory Bank .................................................................................................................... 291
15.1.2 EPC Raw URI into Gen 2 EPC Memory Bank ................................................................................................................... 292
15.2 Decoding procedures ......................................................................................................................................................... 293
15.2.1 Gen 2 EPC Memory Bank into EPC Raw URI ................................................................................................................... 293
15.2.2 Gen 2 EPC Memory Bank into EPC Tag URI .................................................................................................................... 294
15.2.3 Gen 2 EPC Memory Bank into Pure Identity EPC URI ....................................................................................................... 294
15.2.4 Decoding of control information ................................................................................................................................... 295
15.3 '+AIDC data' following new EPC schemes in the EPC/UII memory bank ..................................................................................... 295
```
16 Tag Identification (TID) Memory Bank Contents .............................................................................. 325
```
```
16.1 Short Tag Identification (TID).............................................................................................................................................. 325
```
```
16.2 Extended Tag identification (XTID) ....................................................................................................................................... 326
```
16.2.1 XTID Header............................................................................................................................................................. 327
16.2.2 XTID Serialisation...................................................................................................................................................... 329
16.2.3 Optional Command Support segment ........................................................................................................................... 329
16.2.4 BlockWrite and BlockErase segment ............................................................................................................................. 330
16.2.5 User Memory and BlockPermaLock segment .................................................................................................................. 332
16.2.6 Optional Lock Bit segment .......................................................................................................................................... 332
```
16.3 Serialised Tag Identification (STID) ...................................................................................................................................... 333
```
16.3.1 STID URI grammar .................................................................................................................................................... 333
16.3.2 Decoding procedure: TID Bank Contents to STID URI ..................................................................................................... 334
17 User Memory Bank Contents ............................................................................................................. 335
18 Conformance .................................................................................................................................... 337
18.1 Conformance of RFID Tag Data............................................................................................................................................ 337
```
18.1.1 Conformance of Reserved Memory Bank (Bank 00) ........................................................................................................ 337
```
```
18.1.2 Conformance of EPC Memory Bank (Bank 01) ................................................................................................................ 337
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 15 of 448
```
18.1.3 Conformance of TID Memory Bank (Bank 10) ................................................................................................................ 338
```
```
18.1.4 Conformance of User Memory Bank (Bank 11) ............................................................................................................... 338
```
18.2 Conformance of Hardware and Software Components ............................................................................................................. 338
18.2.1 Conformance of hardware and software Components That Produce or Consume Gen 2 Memory Bank Contents ....................... 338
18.2.2 Conformance of hardware and software Components that Produce or Consume URI Forms of the EPC ................................... 339
18.2.3 Conformance of hardware and software components that translate between EPC Forms ...................................................... 341
18.3 Conformance of Human Readable Forms of the EPC and of EPC Memory Bank contents ............................................................... 341
A Character Set for Alphanumeric Serial Numbers .................................................................................... 342
```
B Glossary (non-normative) ...................................................................................................................... 345
```
C References ............................................................................................................................................. 349
D Extensible Bit Vectors ............................................................................................................................ 351
```
E (non-normative) Examples: EPC encoding and decoding ....................................................................... 352
```
```
E.1 Encoding a Serialised Global Trade Item Number (SGTIN) to SGTIN-96 ..................................................................................... 352
```
```
E.2 Decoding an SGTIN-96 to a Serialised Global Trade Item Number (SGTIN) ................................................................................ 354
```
E.3 Summary Examples of All EPC schemes ................................................................................................................................ 356
F Packed objects ID Table for Data Format 9 ............................................................................................ 366
```
F.1 Tabular Format (non-normative) .......................................................................................................................................... 366
```
```
F.2 Comma-Separated-Value (CSV) format................................................................................................................................. 389
```
G 6-Bit Alphanumeric Character Set .......................................................................................................... 397
```
H (Intentionally Omitted) .......................................................................................................................... 399
```
I Packed Objects structure ....................................................................................................................... 400
I.1 Overview.......................................................................................................................................................................... 400
I.2 Overview of Packed Objects documentation ........................................................................................................................... 400
I.3 High-Level Packed Objects format design .............................................................................................................................. 400
I.4 Format Flags section .......................................................................................................................................................... 403
I.5 Object Info section ............................................................................................................................................................ 405
I.6 Secondary ID Bits section ................................................................................................................................................... 413
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 16 of 448
I.7 Aux Format section ............................................................................................................................................................ 413
I.8 Data section ..................................................................................................................................................................... 415
I.9 ID Map and Directory encoding options ................................................................................................................................. 418
J Packed Objects ID tables ....................................................................................................................... 424
J.1 Packed Objects data format registration file structure ............................................................................................................. 424
J.2 Mandatory and optional ID table columns .............................................................................................................................. 426
J.3 Syntax of OIDs, IDstring, and FormatString Columns .............................................................................................................. 429
J.4 OID input/output representation .......................................................................................................................................... 432
K Packed Objects encoding tables ............................................................................................................. 434
```
L Encoding Packed Objects (non-normative) ............................................................................................ 441
```
```
M Decoding Packed Objects (non-normative) ............................................................................................ 445
```
M.1 Overview.......................................................................................................................................................................... 445
M.2 Decoding alphanumeric data ............................................................................................................................................... 446
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 17 of 448
Index of figures
```
Figure 1 Organisation of the EPC Tag Data Standard (TDS) ........................................................................................................................ 39
```
Figure 2 Example Visibility Data Stream .................................................................................................................................................. 42
Figure 3 Illustration of GRAI Identifier Namespace .................................................................................................................................... 43
Figure 4 Illustration of EPC Identifier Namespace ...................................................................................................................................... 44
Figure 5 Illustration of Relationship of GS1 key and EPC Identifier Namespaces............................................................................................. 45
Figure 6 EPC Structures used within the GS1 System Architecture............................................................................................................... 51
Figure 7 EPC Schemes and Where the Pure Identity Form is Defined ........................................................................................................... 56
Figure 8 Correspondence between SGTIN EPC URI and GS1 element string .................................................................................................. 78
Figure 9 Correspondence between SSCC EPC URI and GS1 element string.................................................................................................... 82
Figure 10 Correspondence between SGLN EPC URI without extension and GS1 element string ........................................................................ 84
Figure 11 Correspondence between SGLN EPC URI with extension and GS1 element string ............................................................................. 84
Figure 12 Correspondence between GRAI EPC URI and GS1 element string .................................................................................................. 87
Figure 13 Correspondence between GIAI EPC URI and GS1 element string ................................................................................................... 89
Figure 14 Correspondence between GSRN EPC URI and GS1 element string ................................................................................................. 90
Figure 15 Correspondence between GSRNP EPC URI and GS1 element string ................................................................................................ 92
Figure 16 Correspondence between GDTI EPC URI and GS1 element string .................................................................................................. 93
Figure 17 Correspondence between CPI EPC URI and GS1 element string .................................................................................................... 95
Figure 18 Correspondence between SGCN EPC URI and GS1 element string ................................................................................................. 96
Figure 19 Correspondence between GINC EPC URI and GS1 element string .................................................................................................. 98
Figure 20 Correspondence between GSIN EPC URI and GS1 element string .................................................................................................. 99
Figure 21 Correspondence between ITIP EPC URI and GS1 element string...................................................................................................101
Figure 22 Correspondence between UPUI EPC URI and GS1 element string .................................................................................................102
Figure 23 Correspondence between PGLN EPC URI without extension and GS1 element string .......................................................................104
Figure 24 Correspondence between LGTIN EPC Class URI and GS1 element string........................................................................................105
Figure 25 Gen 2 Tag Memory Map .........................................................................................................................................................114
```
Figure 26 Gen 2 Protocol Control (PC) Bits Memory Map ...........................................................................................................................118
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 18 of 448
Figure 27 Illustration of EPC Tag URI and EPC Raw URI ............................................................................................................................133
Figure 28 Illustration of Filter Value within EPC Tag URI ...........................................................................................................................134
Figure 29 Example of the use of the +AIDC data toggle bit ......................................................................................................................... 173
Figure 30 Prioritised date format support for 6-digit date values .................................................................................................................. 175
Figure 31 Example of numeric delimiter and terminator .............................................................................................................................. 180
Figure 32 Examples of "Variable-length alphanumeric" encoding method ...................................................................................................... 183
Figure 33 Decision tree flowchart to select the most efficient encoding method based on the value being encoded ............................................. 184
Figure 34 Example value - alphanumeric, encoded as file-safe URI-safe base 64 ........................................................................................... 191
Figure 35 Use of the "Variable-length URN Code 40" method to encode 6 characters ...................................................................................... 195
Figure 36 Example of alphanumeric encoded as 7-bit ASCII ........................................................................................................................ 200
Figure 37 Efficient encoding of YYMMDD date value using 16 bits ................................................................................................................. 203
Figure 38 Encoding of YYMMDDhhmm date time value using 27 bits............................................................................................................. 205
Figure 39 Encoding of "Variable-format date / date range" .......................................................................................................................... 208
Figure 40 Encoding of "Variable-precision date+time" ................................................................................................................................ 211
Figure 41 ISO 3166-1 alpha-2 country code encoded as file-safe URI base 64 ............................................................................................... 215
Figure 42 Example of URN Code 40 method to encode custom hostname ...................................................................................................... 222
Figure 43 Example of 7-bit truncated ASCII method to encode custom hostname .......................................................................................... 222
Figure 44 Example of 7-bit truncated ASCII method to encode custom hostname with TLD optimisation ........................................................... 223
Figure 45 Example of '+AIDC data' in EPC/UII memory .............................................................................................................................. 296
Figure 46 Reading and interpreting additional bits after the 8-bit data header ............................................................................................... 299
Figure 47 Examples of encoding all-numeric and alphanumeric batch/lot number .......................................................................................... 319
Figure 48 Encoding more than one AIDC data value after the EPC ................................................................................................................ 320
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 19 of 448
Index of tables
Table 4-1 EPC Schemes and Corresponding GS1 keys ............................................................................................................................... 46
Table 6-1 EPC Class Schemes and Where the Pure Identity Form is Defined ................................................................................................. 74
Table 9-1 Kinds of Data on a Gen 2 RFID Tag .........................................................................................................................................112
Table 9-2 Gen 2 Memory Map ...............................................................................................................................................................115
```
Table 9-3 Gen 2 Protocol Control (PC) Bits Memory Map ...........................................................................................................................119
```
Table 10-1 SGTIN Filter Values .............................................................................................................................................................124
Table 10-2 SSCC Filter Values ..............................................................................................................................................................124
Table 10-3 SGLN Filter Values ..............................................................................................................................................................125
Table 10-4 GRAI Filter Values ...............................................................................................................................................................125
Table 10-5 GIAI Filter Values................................................................................................................................................................125
Table 10-6 GSRN and GSRNP Filter Values .............................................................................................................................................126
Table 10-7 GDTI Filter Values ...............................................................................................................................................................126
Table 10-8 CPI Filter Values .................................................................................................................................................................127
Table 10-9 SGCN Filter Values ..............................................................................................................................................................127
Table 10-10 ITIP Filter Values ..............................................................................................................................................................128
Table 10-11 ADI Filter Values ...............................................................................................................................................................128
Table 12-1 Control information fields .....................................................................................................................................................135
Table 12-2 EPC Binary Coding Schemes and their limitations ....................................................................................................................137
Table 14-1 EPC Binary Header Values ....................................................................................................................................................149
Table 14-2 Summary of Encoding/Decoding methods introduced in TDS 2.0 ................................................................................................. 170
Table 14-3 "Fixed-Length Numeric" encoding table .................................................................................................................................... 178
Table 14-4 Encoding table for initial digits of "Delimited/Terminated Numeric" encoding method ..................................................................... 180
Table 14-5 Mapping table for "Variable-length upper case hexadecimal" encoding method .............................................................................. 187
Table 14-6 Mapping table for "Variable-length lower case hexadecimal" encoding method .............................................................................. 189
Table 14-7 Mapping table for "Variable-length 6-bit file-safe URI-safe base 64" encoding method .................................................................... 191
Table 14-8 URN Code 40 character table .................................................................................................................................................. 195
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 20 of 448
Table 14-9 Character table for "Variable-length 7-bit ASCII" encoding method .............................................................................................. 198
```
Table 14-10 Encoding table for "Country code (ISO 3166-1 alpha-2)" .......................................................................................................... 215
```
```
Table 14-11Optimisation Table A (7-bit values only) .................................................................................................................................. 223
```
```
Table 14-12 - Optimisation Table B1 (14-bit values all beginning with ‘0000000’, for optimised encoding of regional or country-specific top-level
```
```
domains (.ac to .li)) ..............................................................................................................................................................................226
```
```
Table 14-13 Optimisation Table B2 (14-bit values all beginning with ‘0000001’, for optimised encoding of regional or country-specific top-level
```
```
domains (.lk to .zw)) ............................................................................................................................................................................... 229
```
```
Table 14-14 - Optimisation Table B3 (14-bit values all beginning with ‘0000010’, for optimised encoding of compound country-specific TLDs (.co.uk
```
```
etc.)) ..................................................................................................................................................................................................... 232
```
```
Table 14-15 Optimisation Table B4 (14-bit values all beginning with ‘0000010’, for optimised encoding of less frequently used gTLDs ('.tech' etc.)
```
.........................................................................................................................................................................................................233
Table 14-16 SGTIN Partition Table ........................................................................................................................................................237
Table 14-17 SGTIN-96 coding table.......................................................................................................................................................238
Table 14-18 SGTIN-198 coding table .....................................................................................................................................................239
Table 14-19 GRAI Partition Table ..........................................................................................................................................................251
Table 14-20 GRAI-170 coding table .......................................................................................................................................................252
Table 14-21 GRAI+ coding table ...........................................................................................................................................................253
Table 14-22 GRAI++ coding table .........................................................................................................................................................254
Table 14-23 GIAI-96 Partition Table ......................................................................................................................................................255
Table 14-24 GIAI-96 coding table .........................................................................................................................................................255
Table 14-25 CPI-96 coding table ...........................................................................................................................................................273
Table 14-26 CPI-var coding table ..........................................................................................................................................................274
Table 14-27 CPI+ coding table .............................................................................................................................................................276
Table 14-28 CPI++ coding table ...........................................................................................................................................................277
Table 14-29 GID-96 coding table ..........................................................................................................................................................288
Table 14-30 ADI-var coding table .........................................................................................................................................................289
Table 15-1 Recipe to Fill In Gen 2 EPC Memory Bank from EPC Tag URI ......................................................................................................291
Table 15-2 Recipe to Fill In Gen 2 EPC Memory Bank from EPC Raw URI .....................................................................................................293
Table 16-1 Short TID format ................................................................................................................................................................326
```
Table 16-2 Non-Normative example: Extended Tag Identification (XTID) format for the TID memory bank ..................................................327
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 21 of 448
Table 16-3 The XTID header ................................................................................................................................................................328
Table 16-4 Optional Command Support XTID Word ..................................................................................................................................329
Table 16-5 XTID Block Write and Block Erase Information ........................................................................................................................330
Table 16-6 XTID Block PermaLock and User Memory Information ..............................................................................................................332
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 22 of 448
Index of special encoding tables new to TDS 2.0
Table Description TDS section
E Table E lists the permitted values for encoding indicator together with the encoding methods and the
character ranges supported by each method.
14.5.6
K Table K is derived from GS1 Gen Specs Figure 7.8.1-2, adding an additional column to indicate how many
additional bits need to be read beyond the initial eight bits of the data header.
15.3
```
F After determining the GS1 Application Identifier key (whether 2,3 or 4 digits), a lookup in column a of Table F
```
explains how the corresponding value is to be encoded.
B Table B calculates the number of bits required to encode the value of a string of length L depending on
the encoding method selected. This table may be used to avoid the need for floating-point arithmetic
calculations.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 23 of 448
Foreword
Abstract
```
The EPC Tag Data Standard (TDS) defines the Electronic Product Code™, and also specifies the memory contents of Gen 2 RFID Tags. In
```
more detail, TDS covers two broad areas:
```
■ The specification of the Electronic Product Code (EPC), including its representation at various levels of the GS1 System Architecture and
```
its correspondence to GS1 keys and other existing codes.
■ The specification of data that is carried on Gen 2 RFID tags, including the EPC, "user memory" data, control information, and tag
manufacture information.
Audience for this document
The target audience for this specification includes:
■ EPC Middleware vendors
■ RFID Tag users and encoders
■ Reader vendors
■ Application developers
■ System integrators
Differences from EPC Tag Data Standard Version 1.6
The EPC Tag Data Standard Version 1.7 is fully backward-compatible with EPC Tag Data Standard Version 1.6.
The EPC Tag Data Standard Version 1.7 includes these new or enhanced features:
```
■ A new EPC Scheme, the Component and Part Identifier (CPI) scheme, has been added ;
```
■ Various typographical errors have been corrected.
Differences from EPC Tag Data Standard Version 1.7
The EPC Tag Data Standard Version 1.8 is fully backward-compatible with EPC Tag Data Standard Version 1.7.
The EPC Tag Data Standard Version 1.8 includes the following enhacements:
■ The GIAI EPC Scheme has been allocated an additional Filter Value, "Rail Vehicle".
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 24 of 448
Differences from EPC Tag Data Standard Version 1.8
The EPC Tag Data Standard Version 1.9 is fully backward-compatible with EPC Tag Data Standard Version 1.8.
The EPC Tag Data Standard Version 1.9 includes the following enhancements:
```
■ A new EPC Class URI to represent the combination of a GTIN plus a Batch/Lot (LGTIN) has been added.
```
```
■ A new EPC Scheme the SerialisedGlobal Coupon Number (SGCN), has been added along with the SGCN-96 binary encoding.
```
```
■ A new EPC Scheme, the Global Service Relation Number – Provider" (GSRNP), has been added along with the GSRNP-96 binary encoding. This
```
```
corresponds to the addition of AI (8017) to [GS1GS14.0];
```
```
■ The existing GSRN EPC Scheme is retitled Global Service Relation Number – Recipient to harmonise with [GS1GS14.0] update to AI (8018). The
```
EPC Scheme name and URI is unchanged, however, to preserve backward compatibility with TDS 1.8 and earlier.
■ New AIs are added to the Packed Objects ID Table for EPC User Memory, to harmonise TDS with [GS1GS14.0], thereby ensuring that all AIs can
be encoded in both barcode and RFID data carriers:
```
□ Packaging Component Number: AI (243)
```
```
□ Global Coupon Number: AI (255)
```
```
□ Country Subdivision of Origin: AI (427)
```
```
□ National Healthcare Reimbursement Number (NHRN) – Germany PZN: AI (710)
```
```
□ National Healthcare Reimbursement Number (NHRN) – France CIP: AI (711)
```
```
□ National Healthcare Reimbursement Number (NHRN) – Spain CN: AI (712)
```
```
□ National Healthcare Reimbursement Number (NHRN) – Brazil DRN: AI (713)
```
```
□ Component Part Identifier (8010)
```
```
□ Component / Part Identifier Serial Number (8011)
```
```
□ Global Service Relation Number – Provider: AI (8017)
```
```
□ Service Relation Instance Number (SRIN): AI (8019)
```
```
□ Extended Packaging URL: AI (8200)
```
```
■ DEPRECATED "Secondary data for specific health industry products" AI (22) in the Packed Objects ID Table for EPC User Memory, to harmonise
```
```
TDS with the GS1 General Specifications;
```
■ A new EPC binary encoding for the Global Document Type Identifier, GDTI-174, is to accommodate all values of the GDTI serial number permitted
```
by [GS1GS14.0] (1 – 17 alphanumeric characters, compared to 1 – 17 numeric characters permitted in earlier versions of the GS1 General
```
```
Specifications).
```
```
■ DEPRECATED the GDTI-113 EPC Binary Encoding; the GDTI-174 Binary Encoding should be used instead
```
```
■ Updated all [GS1GS14.0] version and section references;
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 25 of 448
```
■ Marked Attribute Bits information as pertaining only to Gen2 v 1.x tags;
```
```
■ Changed "ItemReference" to "ItemRefAndIndicator" in SGTIN general syntax;
```
```
■ Corrected provision on number of characters in "String" Encoding method’s validity test from "less than b/7" to "less than or equal to b/7";
```
■ Corrected various errata.
Differences from EPC Tag Data Standard Version 1.9
The EPC Tag Data Standard Version 1.10 is fully backward-compatible with EPC Tag Data Standard Version 1.9.
The EPC Tag Data Standard Version 1.10 includes the following enhancements:
■ New EPC URIs have been added to represent the following identifiers:
□ GINC
□ GSIN
□ BIC container code
```
■ Clarification has been added regarding SGTIN Filter Values "Full Case for Transport" and "Unit Load";
```
```
■ GDTI EPC Scheme has been allocated an additional Filter Value, "Travel Document";
```
```
■ ADI EPC Scheme has been allocated a number of additional Filter Values, to harmonise with the 2015 release of ATA’s Spec 2000;
```
■ New AIs have been added to the Packed Objects ID Table for EPC User Memory, to harmonise TDS with [GS1GS17.0], thereby ensuring that all
AIs can be encoded in both barcode and RFID data carriers:
```
□ Sell by date: AI (16)
```
```
□ Percentage discount of a coupon: AI (394n)
```
```
□ Catch area: AI (7005)
```
```
□ First freeze date: AI (7006)
```
```
□ Harvest date: AI (7007)
```
```
□ Species for fishery purposes: AI (7008)
```
```
□ Fishing gear type: AI (7009)
```
```
□ Production method: AI (7010)
```
```
□ Software version: AI (8012)
```
```
□ Loyalty points of a coupon: AI (8111)
```
```
■ "GS1-128 Coupon Extended Code - NSC" AI (8102) has been marked as DEPRECATED;
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 26 of 448
```
■ Format string for "International Bank Account Number (IBAN)" AI (8007) has been corrected;
```
```
■ SGCN coding table has been corrected to include the SGCN header;
```
```
■ Short Tag Identifcation within the TID Memory Bank has been updated to align with [UHFC1G2v2.0];
```
```
■ Correspondence between EPCs and GS1 Keys has been updated to accommodate 4- and 5-digit GCPs, to align with [GS1GS17.0];
```
■ Abstract, Audience and overview of Differences have been moved to a new "Foreword" section added after the Table of Contents.
```
Differences from EPC Tag Data Standard (TDS) Version 1.10
```
TDS v 1.11 is fully backward-compatible with TDS v 1.10.
TDS v 1.11 includes the following enhancements:
```
■ A new EPC Scheme, the Individual Trade Item Piece (ITIP), has been added along with the ITIP-110 and ITIP-212 binary encodings.
```
■ The following new AIs have been added to the Packed Objects ID Table for EPC User Memory, to harmonise TDS with [GS1GS17.1], thereby
ensuring that all AIs can be encoded in both barcode and RFID data carriers:
```
□ GLN of the production or service location: AI (416)
```
```
□ Refurbishment lot ID: AI (7020)
```
```
□ Functional status: AI (7021)
```
```
□ Revision status: AI (7022)
```
```
□ Global Individual Asset Identifier (GIAI) of an Assembly: AI (7023)
```
```
■ Format string for AIs 91-99 has been revised to allow for up to 90 characters (previously up to 30), in order to harmonise TDS with
```
```
[GS1GS17.0];
```
```
Note: To harmonise with [GS1GS17.0], which have extended the length AIs 91-99 to 90 (previously 30) alphanumeric
```
```
characters, TDS v 1.11 has extended the string format of AIs 91-99 (encoded by means of Packed Objects in User Memory) from
```
```
1*30an (alphanumeric, length 1 to 30) to 1*an (alphanumeric, no upper bound).
```
This revision to tables F.1 and Fs.2 of TDS is fully backward compatible, allowing a tag written per TDS 1.10 to decode properly per
TDS 1.11. It is also mostly forward compatible, allowing a tag written per TDS 1.11 to decode properly per TDS 1.10, as long as the
length of AI 91,…,99 is 30 or fewer. A tag written per TDS 1.10 with a longer value for one of these AIs may signal an error indicating
that the value is too long, but other AIs will decode properly. Another minor issue is that the encoding algorithm will no longer
enforce an upper limit on the length of an encoded value, so it will be possible to encode an AI 91-99 character value that is too long
```
per [GS1GS] (e.g. 100 character). Therefore, to ensure compliance with the GenSpecs and rest of the GS1 System, AI 91-99
```
character values encoded in User Memory should not exceed 90 characters in length.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 27 of 448
```
■ Marked all EPC binary headers previously reserved for 64-bit encodings as now "Reserved for Future Use" (RFU), reflecting the July 2009
```
sunsetting of the 64-bit encodings.
```
Differences from EPC Tag Data Standard (TDS) Version 1.11
```
TDS v 1.12 is fully backward-compatible with TDS v 1.11.
TDS v 1.12 includes the following enhancements:
■ The following EPC Schemes have been been added:
o UPUI
o PGLN
```
■ Guidance has been added (to section 7) to determine the length of the EPC CompanyPrefix component for individually assigned GS1 Keys
```
```
■ "Fixed Width Integer" encoding and decoding methods have been added (to section 14) in support of ITIP,
```
■ Coding method for the Piece and Total components of the ITIP has been corrected from "String" to "Fixed Width Integer"
■ The following new AIs have been added to the Packed Objects ID Table for EPC User Memory, to harmonise TDS with [GS1GS19.1], thereby
ensuring that all AIs can be encoded in both barcode and RFID data carriers:
```
□ Consumer product variant: AI (22)
```
```
□ Third party controlled, serialised extension of GTIN (TPX): AI (235)
```
```
□ Global Location Number of Party: AI (417)
```
```
□ National Healthcare Reimbursement Number (NHRN) – Portugal AIM: AI (714)
```
```
□ GS1 UIC with Extension 1 and Importer index (per EU 2018/574): AI (7040)
```
```
□ Global Model Number: AI (8013)
```
```
□ Identification of pieces of a trade item (ITIP) contained in a logistics unit: AI (8026)
```
```
□ Paperless coupon code identification for use in North America: AI (8112)
```
```
Differences from EPC Tag Data Standard (TDS) Version 1.12
```
TDS v 1.13 includes the following enhancement:
■ Added IMOVN EPC URIO, to encode the IMO Vessel Number.
```
■ Added Protocol ID: AI (7240) to the Packed Objects ID Table for EPC User Memory, to harmonise TDS with [GS1GS19.1], ensuring support for all
```
GS1 AIs in User Memory.
■ Corrected minor errata
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 28 of 448
TDS v 1.13 is fully backward-compatible with TDS v 1.12.
```
Differences from EPC Tag Data Standard (TDS) Version 1.13
```
TDS version 2.0 introduces twelve new EPC schemes and simplified binary encoding to promote greater interoperability with barcodes.
Existing EPC schemes already defined in TDS 1.13 remain valid and are not deprecated. The new EPC schemes do not use partition tables
and the length of the GS1 Company Prefix is neither significant nor does it need to be known for the new binary encodings. Each of the new
EPC schemes may also be appended with additional AIDC data after the EPC. Where appropriate, the new schemes make use of encoding
indicators and length indicators to support efficient binary encodings when encoding fewer characters than the maximum permitted or when
```
using a more restricted character set (e.g. only using digits where alphanumeric characters are allowed).
```
In order to continue support for filtering and selection over the air interface based on the GS1 Company Prefix or the primary GS1 identifier
```
(such as GTIN, SSCC etc.) the primary identifier is encoded using 4 bits per digit in most of the new EPC schemes; the exceptions to this
```
statement are the new GIAI+ and CPI+ schemes because the GIAI and CPI permit alphanumeric characters to follow immediately after the
GS1 Company Prefix, so for GIAI+ and CPI+, it is only the initial numeric digits of the GIAI and CPI that are encoded using 4 bits per digit.
This can include any initial all-numeric digits of the Individual Asset Identifier or the Component/Part Reference. These are aligned on nibble
boundaries and ensure that in each of the new schemes the primary identifier and GS1 Company Prefix component appears at well-defined
bit positions relative to the start of the EPC/UII memory bank irrespective of the value of any indicator digit or extension digit that may be
present. No URN syntax is defined for the new EPC schemes but mappings to element strings and GS1 Digital Link URIs are indicated.
```
Because EPCIS/CBV 2.0 accepts a constrained subset of GS1 Digital Link URIs (specifically at instance-level granularity and without
```
```
additional data attributes) as a valid alternative to pure identity EPC URNs, there is no major need to define URN syntax for the new EPC
```
schemes introduced in TDS 2.0.
The filter values already defined for EPC schemes prior to TDS 2.0 remain valid and unaltered and are carried forward into the
corresponding new EPC schemes. For example, the new schemes SGTIN+, SGTIN++, DSGTIN+ and DSGTIN++ share the same set of filter
values already defined for SGTIN-96 and SGTIN-198.
TDS 2.0 also introduces a new EPC binary encoding, DSGTIN+, a date-prioritised serialised GTIN in which a critical date value appears
before the GTIN within the binary encoding. This is expected to be particularly useful for perishable goods, stock rotation and management
of goods with limited remaining shelf life. This enables an RFID reader to select products from any brand owner or manufacturer where the
critical date matches a specified value such as products whose use-by date or sell-by date is today, so that they can be removed from the
sales area or discounted for quick sale.
TDS 2.0 now mentions GS1 Digital Link and recognises that a constrained subset of GS1 Digital Link URIs may be used in EPCIS/CBV v2.0
event data, as a valid alternative to pure identity EPC URNs.
TDS v 2.0 includes the following enhancements and changes with respect to TDS v 1.13:
```
■ Sensor data (as encoded in the XPC bits) is included in "Business Data" carried by tags (section 9.1).
```
■ Encodings new to TDS 2.0 are described counting bits from left to right.
```
■ Clarification that the Length bits (10h-14h) in the PC Bits represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data" appended to the EPC itself.
```
■ Description of the UMI bit (15h) has been aligned with § 6.3.2.1.2.2 of the Gen2v2 standard [UHFC1G2].
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 29 of 448
```
■ Description of the XPC W1 indicator (16h) has been aligned with § 6.3.2.1.2.5 of [UHFC1G2].
```
■ Description of the Attribute bits moved from section 11 to sections 9.3 and 9.4.
■ Description of XPC bits added as new section 9.4, aligned with § 6.3.2.1.2.5 of [UHFC1G2].
```
■ Most EPC encoding examples have been updated to use sample GCP 9521141; the SGTIN examples in section E use GTIN 09506000134352 to
```
illustrate a resolvable GS1 Digital Link URI.
```
■ Twelve (12) new EPC Binary Headers in the F0-FB range have been added to section 14.2 for the new "EPC+" encoding schemes.
```
■ EPC Binary Header FE has been reserved as an 'Unspecified' / 'Pad' Header for use with optimised Select functionality tentatively planned for
Gen2v3.
```
■ The "Integer" Encoding Method (section 14.3.1) now provides and explicit reminder that "leading zeros are not permitted".
```
■ Section 14.5 specifies new Encoding/Decoding methods introduced in TDS 2.0, specifically:
□ "+AIDC Data Toggle Bit"
□ "Fixed-Bit-Length Numeric String"
□ "Prioritised Date"
□ "Fixed-Length Numeric"
□ "Delimited/Terminated Numeric"
```
□ "Variable-length alphanumeric" (section 14.5.6), including a decision tree to help implementations determine the most efficient of
```
```
the following encoding methods to use (based on characters actually present in the value to be encoded):
```
- Variable-length numeric string
- Variable-length upper case hexadecimal
- Variable-length lower case hexadecimal
- Variable-length 6-bit file-safe URI-safe base 64
- Variable-length URN Code 40
- Variable-length 7-bit ASCII
□ "Single data bit"
□ "6-digit date YYMMDD"
□ "10-digit date+time YYMMDDhhmm"
□ "Variable-format date / date range"
□ "Variable-precision date+time"
```
□ "Country code (ISO 3166-1 alpha-2)"
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 30 of 448
```
■ EPC Memory Bank Decoding procedures now specify (section 15.2.4) one text string (rather than two text strings in TDS 1.13) to include XPC_W1
```
and XPC_W2, when only the former or both of these exist,
■ Section 15.3 details encoding and decoding of the new "'+AIDC data' following new EPC schemes in the EPC/UII memory bank"
```
■ Within the XTID Header (section 16.2.1), an indicator (bit 9 in XTID) has been added to specify that the XTID includes the Lock Bit Segment; for
```
the Serialisation bits of the XTID Header, clarification has been provided to state that bit 15 is MSB abd bit 13 is LSB.
```
■ The Optional Lock Bit Segment (section 16.2.6) has been added to XTID, to indicate the current lock bit settings for the memory banks on the
```
tag,
```
■ The STID URI (section 16.3) has been corrected to reflect the X, S and F indicators and 9-bit MDID introduced by Gen2 v2.
```
```
■ User Memory Bank Contents (section 17) have been updated to reflect support for ISO/IEC 20248 Digital Signatures, and to refer to section 9.3
```
for an explanation of the UMI,
```
■ Section E includes updated examples for all EPC (TDS 1.13) and EPC+ (TDS 2.0) schemes.
```
```
■ Section F adds the following new GS1 Application Identifiers (AIs) for use in conjunction with Packed Objects:
```
```
□ 395(***)
```
□ 4300
□ 4301
□ 4302
□ 4303
□ 4304
□ 4305
□ 4306
□ 4307
□ 4308
□ 4309
□ 4310
□ 4311
□ 4312
□ 4313
□ 4314
□ 4315
□ 4316
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 31 of 448
□ 4317
□ 4318
□ 4319
□ 4320
□ 4321
□ 4322
□ 4323
□ 4324
□ 4325
□ 4326
□ 715
□ 723s
□ 723s
□ 723s
□ 723s
□ 723s
□ 723s
□ 723s
□ 723s
□ 723s
□ 723s
Differences from EPC Tag Data Standard Version 2.0
TDS v 2.1 is fully backward-compatible with TDS v 2.0.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 32 of 448
TDS v 2.0 includes the following changes with respect to TDS v 1.13:
■ Added index of figures
■ Added index of tables
```
■ Added text to Sections 6.3.16 and 14.6.12, General Identifier (GID), to indicate that General Manager Number issuance has been
```
discontinued, effective June 2023.
■ Added index of encoding Tables E, F, K and B, introduced to TDS 2.0/2.1 in sections 14.5.6 and 15.3.
■ Restored encoding Table B, which had been unintentionally omitted from the published version of TDS 2.0, to section 15.3. Table B calculates
the number of bits required to encode the value of a string of length L depending on the encoding method selected. This may be used to avoid
the need for floating-point arithmetic calculations.
■ Restored missing rows to Table K, which had been unintentionally shortened in the published version of TDS 2.0. Table K now includes all rows,
```
including those where the AI key is 2 digits, so that those are explicit; this means that any 2-digit string not present in the full Table K is
```
currently also missing from the corresponding table in GenSpecs and does not correspond to a currently defined AI key of 2, 3 or 4 digits.
■ Corrected Table E to resolve contradiction between Table E and the encoding indicators mentioned in sections 14.5.6.2 and 14.5.6.3.
```
■ Section 17 (Packed Objects) now references new GS1 AI (8030) and clarifies the role of the Party GLN (PGLN) as Domain Authority ID (DAID)
```
when a [ISO20248] digital signature is associated with a GS1 element string.
```
■ Section F adds the following new GS1 Application Identifiers (AIs) for use in conjunction with Packed Objects:
```
```
□ AIDC media type: AI (7241)
```
```
□ Version Control Number (VCN): AI (7242)
```
```
□ Digital Signature (DigSig): AI (8030)
```
□ Test by date: AI 7011
```
□ Maximum temperature in Fahrenheit: AI (4330)
```
```
□ Maximum temperature in Celsius: AI (4331)
```
```
□ Minimum temperature in Fahrenheit: AI (4332)
```
```
□ Minimum temperature in Celsius: AI (4333)
```
```
■ Typographical errors have been corrected in the Packed Objects ID Table for Data Format 9, in Sections F.1 (non-normative tabular format) and
```
```
F.2 (normative CSV format).
```
■ The Packed Objects ID Table for Data Format 9 in Section F.2 has been supplemented with an external, normative artefact in CSV format.
TDS v 2.1 also corrects minor errors in non-normative examples and other errata discovered after the publication of TDS v 2.0.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 33 of 448
Differences from EPC Tag Data Standard Version 2.1
TDS v 2.2 is fully backward-compatible with TDS v 2.1.
TDS v 2.2 includes the following changes with respect to TDS v 2.1:
■ Various adjustments to align with TDT 2.2.
■ Changed encoding method names and descriptions on section 14.5, to allow for leading zeros:
```
o "Fixed-Bit-Length Integer" (section 14.5.2) is changed to "Fixed-Bit-Length Numeric String"
```
```
o "Variable-length integer" (section 14.5.6.1) is changed to "Variable Length Numeric string"
```
```
o "Variable-length integer without encoding indicator" (section 14.5.13) is changed to "Variable-Length Numeric String without encoding
```
indicator"
```
■ Added "Optional minus sign in 1 bit" encoding method (section 14.5.14)
```
```
■ Added "Sequence indicator" encoding method (section 14.5.15)
```
```
■ Section F adds the following new GS1 Application Identifiers (AIs) for use in conjunction with Packed Objects:
```
```
□ UN/CEFACT freight unit type: AI (7041)
```
```
□ National Healthcare Reimbursement Number (NHRN) – Italy AIC: AI (716)
```
```
□ Date of birth: AI (7250)
```
```
□ Date and time of birth: AI (7251)
```
```
□ Biological sex: AI (7252)
```
```
□ Family name of person: AI (7253)
```
```
□ Given name of person: AI (7254)
```
```
□ Name suffix of person: AI (7255)
```
```
□ Full name of person: AI (7256)
```
```
□ Address of person: AI (7257)
```
```
□ Baby birth sequence indicator: AI (7258)
```
```
□ Baby of family name: AI (7259)
```
```
■ A typographical error has been corrected in the Packed Objects ID Table for Data Format 9, in Section F.2 (normative CSV format).
```
TDS v 2.2 also corrects minor errors in non-normative examples and other errata discovered after the publication of TDS v 2.1.
Differences from EPC Tag Data Standard Version 2.2
TDS v 2.3 is fully backward-compatible with TDS v 2.2.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 34 of 448
TDS v 2.3 includes the following changes with respect to TDS v 2.2:
■ Twelve new EPC schemes are introduced, including SGTIN++ and DSGTIN++ that are modelled on extended versions of existing schemes such
```
as SGTIN+ and DSGTIN+ (introduced in TDS 2.0). The new ‘++’ EPC schemes add lossless encoding of a custom domain name after the serial
```
number or serial component within the binary encoding of the EPC and are intended to support lossless translation between an EPC binary string
and a non-canonical GS1 Digital Link URI that has a custom domain name or hostname, typically registered by the respective licensee of the GS1
identifier, such as the domain name of a brand owner of a product.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 35 of 448
1 Introduction
```
The EPC Tag Data Standard defines the Electronic Product Code™ (EPC), and specifies the memory contents of Gen 2 RFID Tags. In more
```
detail, TDS covers two broad areas:
■ The specification of the Electronic Product Code, including its representation at various levels of the GS1 Architecture and its correspondence to
GS1 keys and other existing codes.
■ The specification of data that is carried on Gen 2 RFID tags, including the EPC, "user memory" data, control information, and tag manufacture
information.
```
The Electronic Product Code (EPC) is a universal identifier for any physical object. It is used in information systems that need to track or
```
otherwise refer to physical objects. A very large subset of applications that use the EPC also rely upon RFID Tags as a data carrier. For this
reason, a large part of TDS is concerned with the encoding of EPCs onto RFID tags, along with defining the standards for other data apart
from the EPC that may be stored on a Gen 2 RFID tag.
```
Therefore, the two broad areas covered by TDS (the EPC and RFID) overlap in the parts where the encoding of the EPC onto RFID tags is
```
discussed. Nevertheless, it should always be remembered that the EPC and RFID are not at all synonymous: EPC is an identifier, and RFID
```
is a data carrier. RFID tags contain other data besides EPC identifiers (and in some applications may not carry an EPC identifier at all), and
```
```
the EPC identifier exists in non-RFID contexts (those non-RFID contexts including the URI form used within information systems, printed
```
```
human-readable EPC URIs, and EPC identifiers derived from barcode data following the procedures in this standard).
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 36 of 448
2 Terminology and typographical conventions
Within this specification, the terms SHALL, SHALL NOT, SHOULD, SHOULD NOT, MAY, NEED NOT, CAN, and CANNOT are to be interpreted
as specified in Annex G of the ISO/IEC Directives, Part 2, 2001, 4th edition [ISODir2]. When used in this way, these terms will always be
```
shown in ALL CAPS; when these words appear in ordinary typeface they are intended to have their ordinary English meaning.
```
All sections of this document, with the exception of Section Introduction are normative, except where explicitly noted as non-normative.
The following typographical conventions are used throughout the document:
■ ALL CAPS type is used for the special terms from [ISODir2] enumerated above.
■ Monospace type is used for illustrations of identifiers and other character strings that exist within information systems.
```
The term "Gen 2 RFID Tag" (or just "Gen 2 Tag") as used in this specification refers to any RFID tag that conforms to the EPCglobal UHF
```
Class 1 Generation 2 Air Interface, Version 1.2.0 or later [UHFC1G2], as well as any RFID tag that conforms to another air interface
standard that shares the same memory map. Bitwise addresses within Gen 2 Tag memory banks are indicated using hexadecimal numerals
```
ending with a subscript "h"; for example, 20h denotes bit address 20 hexadecimal (32 decimal).
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 37 of 448
3 Overview of TDS
This section provides an overview of TDS and how the parts fit together.
TDS covers two broad areas:
■ The specification of the EPC, including its representation at various levels of the GS1 System Architecture and its correspondence to GS1 keys
and other existing codes.
■ The specification of data that is carried on Gen 2 RFID tags, including the EPC, "user memory" data, control information, and tag manufacture
information.
The EPC is a universal identifier for any physical object, although EPC URI formats are also defined for locations and organisations. It is used
in information systems that need to track or otherwise refer to physical objects. Within computer systems, including electronic documents,
```
databases, and electronic messages, the EPC takes the form of an Internet Uniform Resource Identifier (URI). This is true regardless of
```
whether the EPC was originally read from an RFID tag or some other kind of data carrier. This URI is called the "Pure Identity EPC URI." The
following is an example of a Pure Identity EPC URI:
```
urn:epc:id:sgtin:9521141.012345.4711
```
This same identifier can also be encoded as a canonical GS1 Digital Link URI [GS1DL] as follows:
```
https://id.gs1.org/01/09521141123454/21/4711
```
or as a non-canonical GS1 Digital link URI such as:
```
https://example.com/01/09521141123454/21/4711
```
```
or even (with some additional URI path information):
```
```
https://example.com/some/path/info/01/09521141123454/21/4711
```
Note that these example GS1 Digital Link URIs are not currently configured to redirect to a demonstration Web page.
```
Although GS1 defines a canonical syntax for GS1 Digital Link URIs using the hostname id.gs1.org (and supported by the GS1 global resolver
```
```
at id.gs1.org ), it is permissible for other jurisdictions to recommend the use of an alternative hostname or URI stem for the resolution of
```
GS1 Digital Link URIs. Although these would not be 'canonical', they might be recommended within a particular jurisdiction and supported
by a corresponding resolver.
A very large subset of applications that use EPCs also rely upon RFID tags as a data carrier. RFID is often a very appropriate data carrier
technology to use for applications involving visibility of physical objects, because RFID permits data to be physically attached to an object
such that reading the data is minimally invasive to material handling processes. For this reason, a large part of TDS is concerned with the
encoding of EPCs onto RFID tags, along with defining the standards for other data apart from the EPC that may be stored on a Gen 2 RFID
tag. Owing to memory limitations of RFID tags, the EPC is not stored in URI form on the tag, but is instead encoded into a compact binary
representation. This is called the "EPC Binary Encoding" and refers to on-tag encoding of the EPC, regardless of the choice of which specific
EPC scheme is used.
```
Therefore, the two broad areas covered by TDS (the EPC and RFID) overlap in the parts where the encoding of the EPC onto RFID tags is
```
discussed. Nevertheless, it should always be remembered that the EPC and RFID are not at all synonymous: EPC is an identifier, and RFID
```
is a data carrier. RFID tags contain other data besides EPC identifiers (and in some applications may not carry an EPC identifier at all), and
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 38 of 448
```
the EPC identifier exists in non-RFID contexts (those non-RFID contexts currently including the URI form used within information systems,
```
```
printed human-readable EPC URIs, and EPC identifiers derived from barcode data following the procedures in this standard).
```
```
The term "Electronic Product Code" (or "EPC") is used when referring to the EPC regardless of the concrete form used to represent it. The
```
term "Pure Identity EPC URI" is used to refer specifically to the text form the EPC takes within computer systems, including electronic
documents, databases, and electronic messages. The term "EPC Binary Encoding" is used specifically to refer to the form the EPC takes
within the memory of RFID tags.
```
The following figure illustrates the parts of TDS and how they fit together. (The colours in the figure refer to the types of data that may be
```
```
stored on RFID tags, explained further in Section 9.1.).
```
```
Note that filter values are included within the EPC Binary Encoding of many EPC schemes but are specific to RFID tags and (with the
```
```
exception of Application Level Events (ALE)), are not included at any other layer of the GS1 System Architecture, nor are they present in
```
element strings, pure identity EPC URIs nor GS1 Digital Link URIs. They are intended primarily for low-level applications rather than
```
information exchange and do not reliably express logistic level (e.g. item, case, pallet), nor should they be confused with the indicator digit
```
of a GTIN-14 or the extension digit of an SSCC. There are risks of relying on the filter value if this is not harmonised across the
stakeholders who use it.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 39 of 448
```
Figure 3-1 Organisation of the EPC Tag Data Standard (TDS)
```
The first few sections define those aspects of the Electronic Product Code that are independent from RFID.
```
Section 4 provides an overview of the Electronic Product Code (EPC) and how it relates to other GS1 standards and the GS1 General
```
Specifications.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 40 of 448
Section 6 specifies the Pure Identity EPC URI form of the EPC. This is a textual form of the EPC, and is recommended for use in business
applications and business documents as a universal identifier for any physical object for which visibility information is kept. In particular,
this form is what is used as the "what" dimension of visibility data in the EPCIS specification, and is also available as an output from the
```
Application Level Events (ALE) interface.
```
Section 7 specifies the correspondence between Pure Identity EPC URIs as defined in Section 6 and barcode element strings as defined in
the GS1 General Specifications.
Section 8 specifies the Pure Identity Pattern URI, which is a syntax for representing sets of related EPCs, such as all EPCs for a given trade
item regardless of serial number.
The remaining sections address topics that are specific to RFID, including RFID-specific forms of the EPC as well as other data apart from
the EPC that may be stored on Gen 2 RFID tags.
Section 9 provides general information about the memory structure of Gen 2 RFID Tags.
Sections 10 and 11 specify "control" information that is stored in the EPC memory bank of Gen 2 tags along with a binary-encoded form of
```
the EPC (EPC Binary Encoding). Control information is used by RFID data capture applications to guide the data capture process by
```
providing hints about what kind of object the tag is affixed to. Control information is not part of the EPC, and does not comprise any part of
```
the unique identity of a tagged object. There are two kinds of control information specified: the "filter value" (Section 10) that makes it
```
easier to read desired tags in an environment where there may be other tags present, such as reading a pallet tag in the presence of a large
```
number of item-level tags, and "Attribute bits" (Sections 9.3 and 9.4) that provide additional special attribute information such as alerting
```
to the presence of hazardous material. The same "Attribute bits" are available regardless of what kind of EPC is used, whereas the available
```
"filter values" are different depending on the type of EPC (and with certain types of EPCs, no filter value is available at all).
```
Section 12 specifies the "tag" Uniform Resource Identifiers, which is a compact string representation for the entire data content of the EPC
memory bank of Gen 2 RFID Tags. This data content includes the EPC together with "control" information as defined in Section 9.1. In the
"tag" URI, the EPC content of the EPC memory bank is represented in a form similar to the Pure Identity EPC URI. Unlike the Pure Identity
EPC URI, however, the "tag" URI also includes the control information content of the EPC memory bank. The "tag" URI form is
recommended for use in capture applications that need to read control information in order to capture data correctly, or that need to write
```
the full contents of the EPC memory bank. "Tag" URIs are used in the Application Level Events (ALE) interface, both as an input (when
```
```
writing tags) and as an output (when reading tags).
```
Section 13 specifies the EPC Tag Pattern URI, which is a syntax for representing sets of related RFID tags based on their EPC content, such
as all tags containing EPCs for a given range of serial numbers for a given trade item.
Sections 14 and 9.2 specify the contents of the EPC memory bank of a Gen 2 RFID tag at the bit level. Section 14 specifies how to translate
between the "tag" URI and the EPC Binary Encoding. The binary encoding is a bit-level representation of what is actually stored on the tag,
```
and is also what is carried via the Low Level Reader Protocol (LLRP) interface. Section 9.2 specifies how this binary encoding is combined
```
with Attribute bits and other control information in the EPC memory bank.
Section 16 specifies the binary encoding of the TID memory bank of Gen 2 RFID Tags.
Section 17 specifies the binary encoding of the User memory bank of Gen 2 RFID Tags.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 41 of 448
4 The Electronic Product Code: A universal identifier for physical objects
The Electronic Product Code is designed to facilitate business processes and applications that need to manipulate visibility data – data about
observations of physical objects. The EPC is a universal identifier that provides a unique identity for any physical object. The EPC is designed
to be unique across all physical objects in the world, over all time, and across all categories of physical objects. It is expressly intended for
use by business applications that need to track all categories of physical objects, whatever they may be.
```
By contrast, GS1 identification keys defined in the GS1 General Specifications [GS1GS] can identify categories of objects (GTIN), unique
```
```
objects (SSCC, GLN, GIAI, GSRN, CPID), or a hybrid (GRAI, GDTI, GCN) that may identify either categories or unique objects depending on
```
```
the absence or presence of a serial number. (Two other keys, GINC and GSIN, identify logical groupings, not physical objects.) The GTIN, as
```
the only category identification key, requires a separate serial number to uniquely identify an object but that serial number is not
considered part of the identification key.
There is a well-defined correspondence between EPCs and GS1 keys. This allows any physical object that is already identified by a GS1 key
```
(or GS1 key + serial number combination) to be used in an EPC context where any category of physical object may be observed. Likewise,
```
it allows EPC data captured in a broad visibility context to be correlated with other business data that is specific to the category of object
involved and which uses GS1 keys.
The remainder of this section elaborates on these points.
4.1 The need for a universal identifier: an example
The following example illustrates how visibility data arises, and the role the EPC plays as a unique identifier for any physical object. In this
example, there is a storage room in a hospital that holds radioactive samples, among other things. The hospital safety officer needs to track
what things have been in the storage room and for how long, in order to ensure that exposure is kept within acceptable limits. Each physical
object that might enter the storage room is given a unique Electronic Product Code, which is encoded onto an RFID Tag affixed to the
object. An RFID reader positioned at the storage room door generates visibility data as objects enter and exit the room, as illustrated below.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 42 of 448
Figure 4-1 Example Visibility Data Stream
As the illustration shows, the data stream of interest to the safety officer is a series of events, each identifying a specific physical object and
when it entered or exited the room. The unique EPC for each object is an identifier that may be used to drive the business process. In this
```
example, the EPC (in Pure Identity EPC URI form) would be a primary key of a database that tracks the accumulated exposure for each
```
```
physical object; each entry/exit event pair for a given object would be used to update the accumulated exposure database.
```
This example illustrates how the EPC is a single, universal identifier for any physical object. The items being tracked here include all kinds of
```
things: trade items, reusable transports, fixed assets, service relations, documents, among others that might occur. By using the EPC, the
```
application can use a single identifier to refer to any physical object, and it is not necessary to make a special case for each category of
thing.
Visibility Data Stream at Storage Room Entrance
Time In /
Out
EPC Comment
8:23am In urn:epc:id:sgtin:9521141.012345.62852 10cc Syringe #62852
```
(trade item)
```
8:52am In urn:epc:id:grai:9521141.54321.2528 Pharma Tote #2528
```
(reusable transport)
```
8:59am In urn:epc:id:sgtin:9521141.012345.1542 10cc Syringe #1542
```
(trade item)
```
```
9:02am Out urn:epc:id:giai:9521141.17320508 Infusion Pump #52 (fixed
```
```
asset)
```
```
9:32am In urn:epc:id:gsrn:9521141.0000010253 Nurse Jones (service
```
```
relation)
```
```
9:42am Out urn:epc:id:gsrn:9521141.0000010253 Nurse Jones (service
```
```
relation)
```
9:52am In urn:epc:id:gdti:9521141.00001.1618034 Patient Smith’s chart
```
(document)
```
RFID Reader
Hospital
Storage Room
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 43 of 448
4.2 Use of identifiers in a Business Data Context
```
Generally speaking, an identifier is a member of set (or "namespace") of strings (names), such that each identifier is associated with a
```
specific thing or concept in the real world. Identifiers are used within information systems to refer to the real world thing or concept in
question. An identifier may occur in an electronic record or file, in a database, in an electronic message, or any other data context. In any
```
given context, the producer and consumer must agree on which namespace of identifiers is to be used; within that context, any identifier
```
belonging to that namespace may be used.
The keys defined in the GS1 General Specifications [GS1GS1] are each a namespace of identifiers for a particular category of real-world
```
entity. For example, the Global Returnable Asset Identifier (GRAI) is a key that is used to identify returnable assets, such as plastic totes
```
and pallet skids. The set of GRAI codes can be thought of as identifiers for the members of the set "all returnable assets." A GRAI code may
```
be used in a context where only returnable assets are expected; e.g., in a rental agreement from a moving services company that rents
```
returnable plastic crates to customers to pack during a move. This is illustrated below.
Figure 4-2 Illustration of GRAI Identifier Namespace
The upper part of the figure illustrates the GRAI identifier namespace. The lower part of the figure shows how a GRAI might be used in the
context of a rental agreement, where only a GRAI is expected.
```
GRAI = 09521141123454400 (100 liter tote #AB23)
```
```
GRAI = 09521141123455500(500 liter tote #XY67)
```
```
GRAI = 09521141123454500 (100 liter tote #AB24)
```
```
GRAIs: All returnable
```
assets
<RentalRecord>
<Items>
<grai>09521141123454400</grai>
<grai>09521141123454500</grai>
…
Establishes the context as returnable assets
Therefore, any GRAI could go here
```
(and nothing else)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 44 of 448
Figure 4-3 Illustration of EPC Identifier Namespace
In contrast, the EPC namespace is a space of identifiers for any physical object, physical location or organisation. The set of EPCs can be
thought of as identifiers for the members of the set "all physical objects, physical locations or organisations." EPCs are used in contexts
where any type of physical object may appear, such as in the set of observations arising in the hospital storage room example above. Note
that the EPC URI as illustrated in Figure 4 includes strings such as sgtin, grai, and so on as part of the EPC URI identifier. This is in
```
contrast to GS1 Keys, where no such indication is part of the key itself; instead, this is indicated outside of the key, such as in the XML
```
```
element name <grai> in the example in Figure 3 in the Application Identifier (AI) that accompanies a GS1 key in a GS1 element string.
```
4.3 Relationship between EPCs and GS1 keys
There is a well-defined relationship between EPCs and GS1 keys. For each GS1 key that denotes an individual physical object, there is a
corresponding EPC, including both an EPC URI and a binary encoding for use in RFID tags. In addition, each GS1 key that denotes a class or
grouping of physical objects has a corresponding URI form. These correspondences are formally defined by conversion rules specified in
Section 7, which define how to map a GS1 key to the corresponding EPC value and vice versa. The well-defined correspondence between
GS1 keys and EPCs allows for seamless migration of data between GS1 key and EPC contexts as necessary.
```
EPCs:
```
All physical objects
```
(N.B. EPCs can also
```
identify physical
locations and
```
organisations)
```
```
EPC = urn:epc:id:sgtin:9521141.012345.62852
```
```
(10cc Syringe #62852 – trade item)
```
```
EPC = urn:epc:id:grai:9521141.54321.2528
```
```
(Pharma Tote #2528 – reusable asset)
```
<EPCISDocument>
<ObjectEvent>
<epcList>
<epc>urn:epc:id:sgtin:9521141.012345.62852</epc>
<epc>urn:epc:id:grai:9521141.54321.2528</epc>
…
Establishes the context as all EPCs
```
(physical objects, locations, organisations)
```
Therefore, any EPC could go here
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 45 of 448
Figure 4-4 Illustration of Relationship of GS1 key and EPC Identifier Namespaces
```
GIAIs: All fixed assets
```
```
SSCCs: All logistics loads
```
```
EPCs: all physical objects (N.B.
```
EPCs can also identify physical
```
locations and organisations)
```
```
GTINs: All trade item
```
```
classes (not individuals)
```
- all serial numbers
```
GRAIs: All reusable asset
```
classes and individuals
- all serial numbers
```
(Not shown: SGLN, GDTI, GSRN, GID, and
```
```
USDoD identifiers)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 46 of 448
Not every GS1 key corresponds to an EPC, nor vice versa. Specifically:
```
■ A Global Trade Item Number (GTIN) by itself does not correspond to an EPC, because a GTIN identifies a class of trade items, not an individual
```
trade item. The combination of a GTIN and a unique serial number, however, does correspond to an EPC. This combination is called a Serialised
Global Trade Item Number, or SGTIN. The GS1 General Specifications do not define the SGTIN as a GS1 key.
```
■ In the GS1 General Specifications, the Global Returnable Asset Identifier (GRAI) can be used to identify either a class of returnable assets, or an
```
individual returnable asset, depending on whether the optional serial number is included. Only the form that includes a serial number, and thus
```
identifies an individual, has a corresponding EPC. The same is true for the Global Document Type Identifier (GDTI) and the Global Coupon
```
```
Number (GCN) – hereafter, in this context, "Serialised Global Coupon Number (SGCN)".
```
```
■ There is an EPC corresponding to each Global Location Number (GLN), and there is also an EPC corresponding to each combination of a GLN with
```
an extension component. Collectively, these EPCs are referred to as SGLNs.1
■ EPCs include identifiers for which there is no corresponding GS1 key. These include the General Identifier and the US Department of Defense
identifier and the Aerospace and Defense Identifier.
The following table summarises the EPC schemes defined in this specification and their correspondence to GS1 keys.
Table 4-1 EPC Schemes and Corresponding GS1 keys
EPC Scheme Tag Encodings Corresponding GS1 key Typical use
sgtin sgtin-96
sgtin-198
sgtin+
dsgtin+
```
GTIN key (plus added serial
```
```
number)
```
Trade item
sgtin++
dsgtin++
```
GTIN key (plus added serial
```
```
number).
```
Also encodes a custom
domain name used in non-
canonical GS1 Digital Link
URIs
sscc sscc-96
sscc+
SSCC Pallet load or other logistics unit
load
sscc++ SSCC. Also encodes a
custom domain name used
in non-canonical GS1 Digital
Link URIs
sgln sgln-96
sgln-195
sgln+
GLN of physical location
```
(with or without additional
```
```
extension)
```
Location
1 Note that in this context, the letter "S" does not stand for "serialized" as it does in SGTIN. See Section 6.3.3 for an explanation.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 47 of 448
EPC Scheme Tag Encodings Corresponding GS1 key Typical use
sgln++ GLN of physical location
```
(with or without additional
```
```
extension). Also encodes a
```
custom domain name used
in non-canonical GS1 Digital
Link URIs
grai grai-96
grai-170
grai+
```
GRAI (serial number
```
```
mandatory)
```
Returnable/reusable asset
```
grai++ GRAI (serial number
```
```
mandatory). Also encodes
```
a custom domain name
used in non-canonical GS1
Digital Link URIs
giai giai-96
giai-202
giai+
GIAI Fixed asset
giai++ GIAI. Also encodes a
custom domain name used
in non-canonical GS1 Digital
Link URIs
gsrn gsrn-96
gsrn+
GSRN – Recipient Hospital admission or club
membership
gsrn++ GSRN – Recipient. Also
encodes a custom domain
name used in non-canonical
GS1 Digital Link URIs
gsrnp gsrnp-96
gsrnp+
GSRN for service provider Medical caregiver or loyalty club
gsrnp++ GSRN for service provider.
Also encodes a custom
domain name used in non-
canonical GS1 Digital Link
URIs
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 48 of 448
EPC Scheme Tag Encodings Corresponding GS1 key Typical use
gdti gdti-96
gdti-113
```
(DEPRECATED)
```
gdti-174
gdti+
```
GDTI (serial number
```
```
mandatory)
```
Document
```
gdti++ GDTI (serial number
```
```
mandatory). Also encodes
```
a custom domain name
used in non-canonical GS1
Digital Link URIs
cpi cpi-96
cpi-var
cpi+
[none]
```
(8010) + (8011)
```
```
Technical industries (e.g.
```
```
automotive ) - components and
```
parts
```
cpi++ (8010) + (8011). Also
```
encodes a custom domain
name used in non-canonical
GS1 Digital Link URIs
sgcn sgcn-96
sgcn+
```
GCN (serial number
```
```
mandatory)
```
Coupon
```
sgcn++ GCN (serial number
```
```
mandatory). Also encodes
```
a custom domain name
used in non-canonical GS1
Digital Link URIs
ginc [none] GINC Logical grouping of goods
intended for transport as a
whole, assigned by a freight
forwarder
gsin [none] GSIN Logical grouping of logistic units
travelling under one despatch
advice and/or bill of lading
itip itip-110
itip-212
itip+
```
(8006) + (21) One of multiple pieces
```
comprising, and subordinate to, a
```
whole (which is, in turn,
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 49 of 448
EPC Scheme Tag Encodings Corresponding GS1 key Typical use
```
itip++ (8006) + (21). Also
```
encodes a custom domain
name used in non-canonical
GS1 Digital Link URIs
identified by an SGTIN or the
```
combination of AIs 01 + 21).
```
upui [none] GTIN + TPX Pack identification to combat
illicit trade
pgln [none] Party GLN Identification of economic
```
operator; identification of owning
```
party or possessing party in the
```
Chain of Custody (CoC) / Chain
```
```
of Ownership (CoO)
```
gid gid-96 [none] Unspecified
usdod usdod-96 [none] US Dept of Defense supply chain
adi adi-var [none] Aerospace and defense – aircraft
and other parts and items
bic [none] [none] Intermodal shipping containers
imovn [none] [none] Vessel identificaton
4.4 Use of the EPC in the GS1 System Architecture
The GS1 System Architecture [GS1Arch] is a collection of hardware, software, and data standards, together with shared network services,
all in service of a common goal of enhancing business flows and computer applications. The GS1 System Architecture includes software
standards at various levels of abstraction, from low-level interfaces to RFID reader devices all the way up to the business application level.
The EPC and related structures specified herein are intended for use at different levels within the GS1 System Architecture. Specifically:
```
■ Pure Identity EPC URI: A representation of an EPC is as an Internet Uniform Resource Identifier (URI) called the Pure Identity EPC URI. Before
```
TDS 2.0, the Pure Identity EPC URI was the preferred way to denote a specific physical object within business applications. The Pure Identity URI
may also be used at the data capture level when the EPC is to be read from an RFID tag or other data carrier, in a situation where the additional
"control" information present on an RFID tag is not needed.
```
■ GS1 Digital Link URI (as an alternative to Pure Identity EPC URIs): Starting in TDS 2.0 and EPCIS 2.0 / CBV 2.0, there is now recognition
```
```
that a GS1 Digital Link URI (or a constrained subset of these, specifically at instance-level granularity and without additional data attributes) can
```
provide an equivalent way to denote a specific physical object within business applications and traceability data. Furthermore, a GS1 Digital Link
URI expresses GS1 Application Identifiers in a less convoluted syntax and can behave like a URL, linking to multiple kinds of online information
and services, making use of resolver infrastructure for GS1 Digital Link and multiple link types defined in the GS1 Web vocabulary. GS1 Digital
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 50 of 448
```
Link URIs can also be used as Linked Data identifiers to express factual claims (e.g. using terms defined in schema.org and the GS1 Web
```
```
Vocabulary).
```
■ EPC Tag URI: The EPC memory bank of a Gen 2 RFID Tag contains the EPC plus additional "control information" that is used to guide the
process of data capture from RFID tags. The EPC Tag URI is a URI string that denotes a specific EPC together with specific settings for the control
information found in the EPC memory bank. In other words, the EPC Tag URI is a text equivalent of the entire EPC memory bank contents. The
EPC Tag URI is typically used at the data capture level when reading from an RFID tag in a situation where the control information is of interest to
the capturing application. It is also used when writing the EPC memory bank of an RFID tag, in order to fully specify the contents to be written.
■ Binary Encoding: The EPC memory bank of a Gen 2 RFID Tag actually contains a compressed encoding of the EPC and additional "control
information" in a compact binary form. For the EPC schemes defined before TDS 2.0, there is a 1-to-1 translation between EPC Tag URIs and the
binary contents of a Gen 2 RFID Tag. For the new EPC schemes and binary encodings introduced in TDS 2.0, no new EPC Tag URI syntax is
defined and encoding/decoding is between the binary representation and the corresponding GS1 element strings or GS1 Digital Link URIs, as
discussed in section 14.5. Normally, the binary encoding is only encountered at a very low level of software or hardware, and is translated to the
```
EPC Tag URI or Pure Identity EPC URI form (for EPC schemes for which these are defined) before being presented to application logic. The binary
```
encoding of the new EPC schemes introduced in TDS 2.0 would be more usually translated to GS1 element strings or GS1 Digital Link URIs.
```
Starting in TDS 2.0 and EPCIS 2.0 / CBV 2.0, there is now recognition that a GS1 Digital Link URI (or a constrained subset of these, specifically at
```
```
instance-level granularity and without additional data attributes) can provide an equivalent way to denote a specific physical object within
```
business applications and traceability data.
```
Note that both the Pure Identity EPC URI and the GS1 Digital Link URI are independent of choice of data carrier (e.g. EPC/RFID or
```
```
barcodes), while the EPC Tag URI and the Binary Encoding are specific to Gen 2 RFID Tags because they include RFID-specific "control
```
information" in addition to the unique EPC identifier.
The figure below illustrates where these structures normally occur in relation to the layers of the GS1 System Archtecture.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 51 of 448
Figure 4-5 EPC Structures used within the GS1 System Architecture
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 52 of 448
5 Common grammar elements
The syntax of various URI forms defined herein is specified via ABNF grammar defined in [RFC5234] and [RFC7405]. The following grammar
elements are used throughout this specification.
```
ZeroComponent = "0"
```
```
NonZeroDigit = "1" / "2" / "3" / "4" / "5" / "6" / "7" / "8" / "9"
```
```
Digit = "0" / NonZeroDigit
```
```
NonZeroComponent = NonZeroDigit 0*Digit
```
```
NumericComponent = ZeroComponent / NonZeroComponent
```
```
PaddedNumericComponent = 1*Digit
```
```
PaddedNumericComponentOrEmpty = 0*Digit
```
```
UpperAlpha = %x41-5A ; A-Z
```
```
LowerAlpha = %x61-7A ; a-z
```
```
OtherChar = "!" / "'" / "(" / ")" / "*" / "+" / "," / "-" / "." / ":" / ";" / "=" / "_"
```
```
UpperHexChar = Digit / "A" / "B" / "C" / "D" / "E" / "F"
```
```
HexChar = UpperHexChar / "a" / "b" / "c" / "d" / "e" / "f"
```
```
HexComponent = 1*UpperHexChar
```
```
HexComponentOrEmpty = 0*UpperHexChar
```
```
Escape = "%" HexChar HexChar
```
```
GS3A3Char = Digit / UpperAlpha / LowerAlpha / OtherChar / Escape
```
```
GS3A3Component = 1*GS3A3Char
```
```
CPRefChar = Digit / UpperAlpha / "-" / "%2F" / "%23"
```
```
CPRefComponent = 1*CPRefChar
```
The syntactic construct GS3A3Component is used to represent fields of GS1 codes that permit alphanumeric and other characters as
```
specified in Figure 7.12-1 of the GS1 General Specifications (see Annex A.) Owing to restrictions on URN syntax as defined by [RFC2141],
```
```
not all characters permitted in the GS1 General Specifications may be represented directly in a URN. Specifically, the characters " (double
```
```
quote), % (percent), & (ampersand), / (forward slash), < (less than), > (greater than), and ? (question mark) are permitted in the GS1
```
General Specifications but may not be included directly in a URN. To represent one of these characters in a URN, escape notation must be
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 53 of 448
used in which the character is represented by a percent sign, followed by two hexadecimal digits that give the ASCII character code for the
character.
The syntactic construct CPRefComponent is used to represent fields that permit upper-case alphanumeric and the characters hyphen,
forward slash, and pound / number sign. Owing to restrictions on URN syntax as defined by [RFC2141], not all of these characters may be
```
represented directly in a URN. Specifically, the characters # (pound / number sign) and / (forward slash) may not be included directly in a
```
URN. To represent one of these characters in a URN, escape notation must be used in which the character is represented by a percent sign,
followed by two hexadecimal digits that give the ASCII character code for the character.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 54 of 448
6 EPC URI
This section specifies the "pure identity URI" form of the EPC, or simply the "EPC URI." Before TDS 2.0, the EPC URI was the preferred way
within an information system to denote a specific physical object. Starting in TDS 2.0 and EPCIS 2.0 / CBV 2.0, there is now recognition
```
that a GS1 Digital Link URI (or a constrained subset of these, specifically at instance-level granularity and without additional data attributes)
```
is an equivalent way to denote a specific physical object within business applications and traceability data, as discussed in further detail in
section 4.4.
The EPC URI is a string having the following form:
```
urn:epc:id:scheme:component1.component2.…
```
where scheme names an EPC scheme, and component1, component2, and following parts are the remainder of the EPC whose precise
form depends on which EPC scheme is used. The available EPC schemes are specified below in Figure 7 in Section 6.3.
An example of a specific EPC URI is the following, where the scheme is sgtin:
```
urn:epc:id:sgtin:9521141.012345.4711
```
Each EPC scheme provides a namespace of identifiers that can be used to identify physical objects of a particular type. Collectively, the EPC
URIs from all schemes are unique identifiers for any type of physical object.
6.1 Use of the EPC URI
The structure of the EPC URI guarantees worldwide uniqueness of the EPC across all types of physical objects and applications. In order to
preserve worldwide uniqueness, each EPC URI must be used in its entirety when a unique identifier is called for, and not broken into
constituent parts nor the urn:epc:id: prefix abbreviated or dropped.
When asking the question "do these two data structures refer to the same physical object?", where each data structure uses an EPC URI to
refer to a physical object, the question may be answered simply by comparing the full EPC URI strings as specified in [RFC3986], Section
6.2. In most cases, the "simple string comparison" method suffices, though if a URI contains percent-encoding triplets the hexadecimal
digits may require case normalisation as described in [RFC3986], Section 6.2.2.1. The construction of the EPC URI guarantees uniqueness
across all categories of objects, provided that the URI is used in its entirety.
In other situations, applications may wish to exploit the internal structure of an EPC URI for purposes of filtering, selection, or distribution.
For example, an application may wish to query a database for all records pertaining to instances of a specific product identified by a GTIN.
This amounts to querying for all EPCs whose GS1 Company Prefix and item reference components match a given value, disregarding the
```
serial number component. Another example is found in the Object Name Service (ONS) [ONS], which uses the first component of an EPC to
```
delegate a query to a "local ONS" operated by an individual company. This allows the ONS system to scale in a way that would be quite
difficult if all ONS records were stored in a flat database maintained by a single organisation. Note that although GS1's ONS standard has
not yet been deprecated or withdrawn, it is no longer maintained and the infrastructure for ONS is no longer supported by GS1 Global
Office. The GS1 Digital Link standard [GS1DL] specifies not only a Web URI syntax for GS1 identifiers but also a resolver / resolution
capability for linking a GS1 Digital Link URI to one or more sources of relevant information and services, as a modern successor to ONS.
While the internal structure of the EPC may be exploited for filtering, selection, and distribution as illustrated above, it is essential that the
EPC URI be used in its entirety when used as a unique identifier.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 55 of 448
6.2 Assignment of EPCs to physical objects
The act of allocating a new EPC and associating it with a specific physical object is called "commissioning." It is the responsibility of
```
applications and business processes that commission EPCs to ensure that the same EPC is never assigned to two different physical objects;
```
that is, to ensure that commissioned EPCs are unique. Typically, commissioning applications will make use of databases that record which
EPCs have already been commissioned and which are still available. For example, in an application that commissions SGTINs by assigning
serial numbers sequentially, such a database might record the last serial number used for each base GTIN.
Because visibility data and other business data that refers to EPCs may continue to exist long after a physical object ceases to exist, an EPC
is ideally never reused to refer to a different physical object, even if the reuse takes place after the original object ceases to exist. There are
```
certain situations, however, in which this is not possible; some of these are noted below. Therefore, applications that process historical data
```
using EPCs should be prepared for the possibility that an EPC may be reused over time to refer to different physical objects, unless the
application is known to operate in an environment where such reuse is prevented.
Seven of the EPC schemes specified herein correspond to GS1 keys, and so EPCs from those schemes are used to identify physical objects
that have a corresponding GS1 key. When assigning these types of EPCs to physical objects, all relevant GS1 rules must be followed in
addition to the rules specified herein. This includes the GS1 General Specifications [GS1GS], the GTIN Management Standard, and so on. In
particular, an EPC of this kind may only be commissioned by the licensee of the GS1 Company Prefix that is part of the EPC, or has been
delegated the authority to do so by the GS1 Company Prefix licensee.
6.3 EPC URI syntax
This section specifies the syntax of an EPC URI.
The formal grammar for the EPC URI is as follows:
EPC-URI =
SGTIN-URI /
SSCC-URI /
SGLN-URI /
GRAI-URI /
GIAI-URI /
GSRN-URI /
GDTI-URI /
CPI-URI /
SGCN-URI /
GINC-URI /
GSIN-URI /
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 56 of 448
ITIP-URI /
UPUI-URI /
PGLN-URI /
GID-URI /
DOD-URI /
ADI-URI /
BIC-URI /
IMOVN-URI
where the various alternatives on the right hand side are specified in the sections that follow.
Each EPC URI scheme is specified in one of the following subsections, as follows:
Figure 6-1 EPC Schemes and Where the Pure Identity Form is Defined
EPC Scheme Specified In Corresponding GS1 key Typical use
```
sgtin Section 6.3.1 GTIN (with added serial
```
```
number)
```
Trade item
sscc Section 6.3.2 SSCC Logistics unit
```
sgln Section 6.3.3 GLN (with or without
```
```
additional extension)
```
Location2
```
grai Section 6.3.4 GRAI (serial number
```
```
mandatory)
```
Returnable asset
giai Section 6.3.5 GIAI Fixed asset
gsrn Section 6.3.6 GSRN – Recipient Hospital admission or
club membership
gsrnp Section 6.3.7 GSRN – Provider Medical caregiver or
loyalty club
```
gdti Section 6.3.8 GDTI (serial number
```
```
mandatory)
```
Document
2 While GLNs may be used to identify both locations and parties, the SGLN corresponds only to AI 414, which [GS1GS] specifies is to be used to
identify locations, and not parties.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 57 of 448
EPC Scheme Specified In Corresponding GS1 key Typical use
cpi Section 6.3.9 [none] Technical industries
```
(e.g. automotive sector)
```
for unique identification
of parts and
components
```
sgcn Section 6.3.10 GCN (serial number
```
```
mandatory)
```
Coupon
ginc Section 6.3.11 GINC Logical grouping of
goods intended for
transport as a whole,
assigned by a freight
forwarder
gsin Section 6.3.12 GSIN Logical grouping of
logistic units travelling
under one despatch
advice and/or bill of
lading
```
itip Section 6.3.13 AI (8006) combined with AI
```
```
(21)
```
One of multiple pieces
comprising, and
subordinate to, a whole
```
(which is, in turn,
```
identified by an SGTIN or
the combination of AIs 01
- 21).
upui Section 6.3.14 GTIN and TPX Pack identification to
combat illicit trade
```
pgln Section 6.3.15 Party GLN – AI (417) Identification of economic
```
```
operator; identification of
```
owning party or possessing
party in the Chain of
```
Custody (CoC) / Chain of
```
```
Ownership (CoO)
```
gid Section 6.3.16 [none] Unspecified
usdod Section 6.3.17 [none] US Dept of Defense
supply chain
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 58 of 448
EPC Scheme Specified In Corresponding GS1 key Typical use
adi Section 6.3.18 [none] Aerospace and Defense
sector for unique
identification of aircraft
and other parts and
items
bic Section 6.3.19 [none] Intermodal shipping
containers
imovn Section 6.3.20 [none] Vessel identificaton
Note that no new Pure Identity EPC URI formats are defined for the new EPC schemes and binary encodings introduced in TDS 2.0.
```
6.3.1 Serialised Global Trade Item Number (SGTIN)
```
The Serialised Global Trade Item Number EPC scheme is used to assign a unique identity to an instance of a trade item, such as a specific
instance of a product or SKU.
General syntax:
```
urn:epc:id:sgtin:CompanyPrefix.ItemRefAndIndicator.SerialNumber
```
```
Example:
```
```
urn:epc:id:sgtin:9521141.012345.4711
```
```
Grammar:
```
SGTIN-URI = %s"urn:epc:id:sgtin:" SGTINURIBody
```
SGTINURIBody = 2(PaddedNumericComponent ".") GS3A3Component
```
```
The number of characters in the two PaddedNumericComponent fields must total 13 (not including any of the dot characters).
```
The Serial Number field of the SGTIN-URI is expressed as a GS3A3Component, which permits the representation of all characters permitted
in the Application Identifier 21 Serial Number according to the GS1 General Specifications. SGTIN-URIs that are derived from 96-bit tag
```
encodings, however, will have Serial Numbers that consist only of digits and which have no leading zeros (unless the entire serial number
```
```
consists of a single zero digit). These limitations are described in the encoding procedures, and in Section 12.3.1.
```
The SGTIN consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity or its delegates. This is the same as the GS1 Company Prefix digits within a
GS1 GTIN key. See Section 7.3.2 for the case of a GTIN-8.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 59 of 448
■ The Item Reference, assigned by the managing entity to a particular object class. The Item Reference as it appears in the EPC URI is derived
```
from the GTIN by concatenating the Indicator Digit of the GTIN (or a zero pad character, if the EPC URI is derived from a GTIN-8, GTIN-12, or
```
```
GTIN-13) and the Item Reference digits, and treating the result as a single numeric string. See Section 7.3.2 for the case of a GTIN-8.
```
■ The Serial Number, assigned by the managing entity to an individual object. The serial number is not part of the GTIN, but is formally a part of
the SGTIN.
```
6.3.2 Serial Shipping Container Code (SSCC)
```
The Serial Shipping Container Code EPC scheme is used to assign a unique identity to a logistics handling unit, such as the aggregate
contents of a shipping container or a pallet load.
General syntax:
```
urn:epc:id:sscc:CompanyPrefix.SerialReference
```
```
Example:
```
```
urn:epc:id:sscc:9521141.1234567890
```
```
Grammar:
```
SSCC-URI = %s"urn:epc:id:sscc:" SSCCURIBody
```
SSCCURIBody = PaddedNumericComponent "." PaddedNumericComponent
```
```
The number of characters in the two PaddedNumericComponent fields must total 17 (not including any of the dot characters).
```
The SSCC consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity. This is the same as the GS1 Company Prefix digits within a GS1 SSCC key.
■ The Serial Reference, assigned by the managing entity to a particular logistics handling unit. The Serial Reference as it appears in the EPC URI
is derived from the SSCC by concatenating the Extension Digit of the SSCC and the Serial Reference digits, and treating the result as a single
numeric string.
```
6.3.3 Global Location Number With or Without Extension (SGLN)
```
The SGLN EPC scheme is used to assign a unique identity to a physical location, such as a specific building or a specific unit of shelving
within a warehouse.
General syntax:
```
urn:epc:id:sgln:CompanyPrefix.LocationReference.Extension
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 60 of 448
```
Example:
```
```
urn:epc:id:sgln:9521141.12345.400
```
```
Grammar:
```
SGLN-URI = %s"urn:epc:id:sgln:" SGLNURIBody
```
SGLNURIBody = PaddedNumericComponent "." PaddedNumericComponentOrEmpty "." GS3A3Component
```
```
The number of characters in the two PaddedNumericComponent fields must total 12 (not including any of the dot characters).
```
The Extension field of the SGLN-URI is expressed as a GS3A3Component, which permits the representation of all characters permitted in
the Application Identifier 254 Extension according to the GS1 General Specifications. SGLN-URIs that are derived from 96-bit tag encodings,
```
however, will have Extensions that consist only of digits and which have no leading zeros (unless the entire extension consists of a single
```
```
zero digit). These limitations are described in the encoding procedures, and in Section 12.3.1.
```
The SGLN consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity. This is the same as the GS1 Company Prefix digits within a GS1 GLN key.
■ The Location Reference, assigned uniquely by the managing entity to a specific physical location.
■ The GLN Extension, assigned by the managing entity to an individual unique location. If the entire GLN Extension is just a single zero digit, it
indicates that the SGLN stands for a GLN, without an extension.
```
Non-Normative: Explanation (non-normative): Note that the letter "S" in the term "SGLN" does not stand for "serialised" as
```
it does in SGTIN. This is because a GLN without an extension also identifies a unique location, as opposed to a class of locations, and
so both GLN and GLN with extension may be considered as "serialised" identifiers. The term SGLN merely distinguishes the EPC form,
which can be used either for a GLN by itself or GLN with extension, from the term GLN which always refers to the unextended GLN
identifier. The letter "S" does not stand for anything.
```
6.3.4 Global Returnable Asset Identifier (GRAI)
```
The Global Returnable Asset Identifier EPC scheme is used to assign a unique identity to a specific returnable asset, such as a reusable
shipping container or a pallet skid.
General syntax:
```
urn:epc:id:grai:CompanyPrefix.AssetType.SerialNumber
```
```
Example:
```
```
urn:epc:id:grai:9521141.12345.400
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 61 of 448
```
Grammar:
```
GRAI-URI = %s"urn:epc:id:grai:" GRAIURIBody
```
GRAIURIBody = PaddedNumericComponent "." PaddedNumericComponentOrEmpty "." GS3A3Component
```
```
The number of characters in the two PaddedNumericComponent fields must total 12 (not including any of the dot characters).
```
The Serial Number field of the GRAI-URI is expressed as a GS3A3Component, which permits the representation of all characters permitted
in the Serial Number according to the GS1 General Specifications. GRAI-URIs that are derived from 96-bit tag encodings, however, will have
```
Serial Numbers that consist only of digits and which have no leading zeros (unless the entire serial number consists of a single zero digit).
```
These limitations are described in the encoding procedures, and in Section 12.3.1.
The GRAI consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity. This is the same as the GS1 Company Prefix digits within a GS1 GRAI key.
■ The Asset Type, assigned by the managing entity to a particular class of asset.
■ The Serial Number, assigned by the managing entity to an individual object. Because an EPC always refers to a specific physical object rather
than an asset class, the serial number is mandatory in the GRAI-EPC.
```
6.3.5 Global Individual Asset Identifier (GIAI)
```
The Global Individual Asset Identifier EPC scheme is used to assign a unique identity to a specific asset, such as a forklift or a computer.
General syntax:
```
urn:epc:id:giai:CompanyPrefix.IndividualAssetReference
```
```
Example:
```
```
urn:epc:id:giai:9521141.12345400
```
```
Grammar:
```
GIAI-URI = %s"urn:epc:id:giai:" GIAIURIBody
```
GIAIURIBody = PaddedNumericComponent "." GS3A3Component
```
The Individual Asset Reference field of the GIAI-URI is expressed as a GS3A3Component, which permits the representation of all characters
permitted in the Serial Number according to the GS1 General Specifications. GIAI-URIs that are derived from 96-bit tag encodings,
```
however, will have Serial Numbers that consist only of digits and which have no leading zeros (unless the entire serial number consists of a
```
```
single zero digit). These limitations are described in the encoding procedures, and in Section 12.3.1.
```
The GIAI consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity. The Company Prefix is the same as the GS1 Company Prefix digits within a
GS1 GIAI key.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 62 of 448
■ The Individual Asset Reference, assigned uniquely by the managing entity to a specific asset.
```
6.3.6 Global Service Relation Number – Recipient (GSRN)
```
The Global Service Relation Number EPC scheme is used to assign a unique identity to a service recipient.
General syntax:
```
urn:epc:id:gsrn:CompanyPrefix.ServiceReference
```
```
Example:
```
```
urn:epc:id:gsrn:9521141.1234567890
```
```
Grammar:
```
GSRN-URI = %s"urn:epc:id:gsrn:" GSRNURIBody
```
GSRNURIBody = PaddedNumericComponent "." PaddedNumericComponent
```
```
The number of characters in the two PaddedNumericComponent fields must total 17 (not including
```
```
any of the dot characters).
```
The GSRN consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity. This is the same as the GS1 Company Prefix digits within a GS1 GSRN key.
■ The Service Reference, assigned by the managing entity to a particular service recipient.
```
6.3.7 Global Service Relation Number – Provider (GSRNP)
```
```
The Global Service Relation Number – Provider (GSRNP) EPC scheme is used to assign a unique identity to a service provider.
```
General syntax:
```
urn:epc:id:gsrnp:CompanyPrefix.ServiceReference
```
```
Example:
```
```
urn:epc:id:gsrnp:9521141.1234567890
```
```
Grammar:
```
GSRNP-URI = %s"urn:epc:id:gsrnp:" GSRNURIBody
```
GSRNPURIBody = PaddedNumericComponent "." PaddedNumericComponent
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 63 of 448
```
The number of characters in the two PaddedNumericComponent fields must total 17 (not including any of the dot characters).
```
The GSRNP consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity. This is the same as the GS1 Company Prefix digits within a GS1 GSRN key.
■ The Service Reference, assigned by the managing entity to a particular service provider.
```
6.3.8 Global Document Type Identifier (GDTI)
```
The Global Document Type Identifier EPC scheme is used to assign a unique identity to a specific document, such as land registration
papers, an insurance policy, and others.
General syntax:
```
urn:epc:id:gdti:CompanyPrefix.DocumentType.SerialNumber
```
```
Example:
```
```
urn:epc:id:gdti:9521141.12345.400
```
```
Grammar:
```
GDTI-URI = %s"urn:epc:id:gdti:" GDTIURIBody
```
GDTIURIBody = PaddedNumericComponent "." PaddedNumericComponentOrEmpty "." GS3A3Component
```
The number of characters in the first PaddedNumericComponent field and the PaddedNumericComponentOrEmpty field must total 12
```
(not including any of the dot characters).
```
The Serial Number field of the GDTI-URI is expressed as a GS3A3Component, which permits the representation of all characters permitted
in the Serial Number according to the GS1 General Specifications. GDTI-URIs that are derived from 96-bit tag encodings, however, will have
```
Serial Numbers that have no leading zeros (unless the entire serial number consists of a single zero digit). These limitations are described in
```
the encoding procedures, and in Section 12.3.1.
The GDTI consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity. This is the same as the GS1 Company Prefix digits within a GS1 GDTI key.
■ The Document Type, assigned by the managing entity to a particular class of document.
■ The Serial Number, assigned by the managing entity to an individual document. Because an EPC always refers to a specific document rather
than a document class, the serial number is mandatory in the GDTI-EPC.
```
6.3.9 Component / Part Identifier (CPI)
```
```
The Component / Part EPC identifier is designed for use by the technical industries (including the automotive sector) for the unique
```
identification of parts or components.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 64 of 448
The CPI EPC construct provides a mechanism to directly encode unique identifiers in RFID tags and to use the URI representations at other
layers of the GS1 System Architecture.
General syntax:
```
urn:epc:id:cpi:CompanyPrefix.ComponentPartReference.Serial
```
```
Example:
```
```
urn:epc:id:cpi:9521141.123ABC.123456789
```
```
urn:epc:id:cpi:9521141.123456.123456789
```
```
Grammar:
```
CPI-URI = %s"urn:epc:id:cpi:" CPIURIBody
```
CPIURIBody = PaddedNumericComponent "." CPRefComponent "." NumericComponent
```
The Component / Part Reference field of the CPI-URI is expressed as a CPRefComponent, which permits the representation of all
characters permitted in the Component / Part Reference according to the GS1 General Specifications. CPI-URIs that are derived from 96-bit
tag encodings, however, will have Component / Part References that consist only of digits, with no leading zeros, and whose length is less
than or equal to 15 minus the length of the GS1 Company Prefix. These limitations are described in the encoding procedures, and in
Section 12.3.1.
The CPI consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity or its delegates.
■ The Component/Part Reference, assigned by the managing entity to a particular object class.
■ The Serial Number, assigned by the managing entity to an individual object.
The managing entity or its delegates ensure that each CPI is issued to no more than one physical component or part. Typically this is
achieved by assigning a component/part reference to designate a collection of instances of a part that share the same form, fit or function
and then issuing serial number values uniquely within each value of component/part reference in order to distinguish between such
instances.
```
6.3.10 Serialised Global Coupon Number (SGCN)
```
The Global Coupon Number EPC scheme is used to assign a unique identity to a coupon.
General syntax:
```
urn:epc:id:sgcn:CompanyPrefix.CouponReference.SerialComponent
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 65 of 448
```
Example:
```
```
urn:epc:id:sgcn:4012345.67890.04711
```
```
Grammar:
```
SGCN-URI = %s"urn:epc:id:sgcn:" SGCNURIBody
```
SGCNURIBody = PaddedNumericComponent "." PaddedNumericComponentOrEmpty "." PaddedNumericComponent
```
The number of characters in the first PaddedNumericComponent field and the PaddedNumericComponentOrEmpty field must total 12
```
(not including any of the dot characters).
```
The Serial Component field of the SGCN-URI is expressed as a PaddedNumericComponent, which may contain up to 12 digits, including
leading zeros, as per the GS1 General Specifications. The SGCN consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity. This is the same as the GS1 Company Prefix digits within a GS1 GCN key.
■ The Coupon Reference, assigned by the managing entity for the coupon.
■ The Serial Component, assigned by the managing entity to a unique instance of the coupon. Because an EPC always refers to a specific coupon
rather than a coupon class, the serial number is mandatory in the SGCN-EPC.
```
6.3.11 Global Identification Number for Consignment (GINC)
```
```
The Global Identification Number for Consignment EPC scheme is used to assign a unique identity to a logical grouping of goods (one or
```
```
more physical entities) that has been consigned to a freight forwarder and is intended to be transported as a whole.
```
General syntax:
```
urn:epc:id:ginc:CompanyPrefix.ConsignmentReference
```
```
Example:
```
```
urn:epc:id:ginc:9521141.xyz3311cba
```
```
Grammar:
```
GINC-URI = %s"urn:epc:id:ginc:" GINCURIBody
```
GINCURIBody = PaddedNumericComponent "." GS3A3Component
```
The Consignment Reference field of the GINC-URI is expressed as a GS3A3Component, which permits the representation of all characters
permitted in the Serial Number according to the GS1 General Specifications.
The GINC consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity. The Company Prefix is the same as the GS1 Company Prefix digits within a
GS1 GINC key.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 66 of 448
■ The Consignment Reference, assigned uniquely by the freight forwarder.
```
6.3.12 Global Shipment Identification Number (GSIN)
```
The Global Shipment Identification Number EPC scheme is used to assign a unique identity to a logical grouping of logistic units for the
```
purpose of a transport shipment from that consignor (seller) to the consignee (buyer).
```
General syntax:
```
urn:epc:id:gsin:CompanyPrefix.ShipperReference
```
```
Example:
```
```
urn:epc:id:gsin:9521141.123456789
```
```
Grammar:
```
GSIN-URI = %s"urn:epc:id:gsin:" GSINURIBody
```
GSINURIBody = PaddedNumericComponent "." PaddedNumericComponent
```
```
The number of characters in the two PaddedNumericComponent fields must total 16 (not including the dot character).
```
The GSIN consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity. This is the same as the GS1 Company Prefix digits within a GS1 GSIN key.
```
■ The Shipper Reference, assigned by the consignor (seller) of goods.
```
```
6.3.13 Individual Trade Item Piece (ITIP)
```
```
The Individual Trade Item Piece EPC scheme is used to assign a unique identity to a subordinate element of a trade item (e.g., left and right
```
```
shoes, suit trousers and jacket, DIY trade item consisting of several physical units), the latter of which comprises multiple pieces.
```
General syntax:
```
urn:epc:id:itip:CompanyPrefix.ItemRefAndIndicator.Piece.Total.SerialNumber
```
```
Example:
```
```
urn:epc:id:itip:9521141.012345.01.02.987
```
```
Grammar:
```
ITIP-URI = %s"urn:epc:id:itip:" ITIPURIBody
```
ITIPURIBody = 4(PaddedNumericComponent ".") GS3A3Component
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 67 of 448
```
The number of characters in the first two PaddedNumericComponent fields must total 13 (not including any of the dot characters).
```
```
The number of characters in each of the last two PaddedNumericComponent fields must be exactly 2 (not including any of the dot
```
```
characters).
```
```
The combined number of characters in the four PaddedNumericComponent fields must total 17 (not including any of the dot characters).
```
The Serial Number field of the ITIP-URI is expressed as a GS3A3Component, which permits the representation of all characters permitted in
the Application Identifier 21 Serial Number according to the GS1 General Specifications. ITIP-URIs that are derived from 110-bit tag
```
encodings, however, will have Serial Numbers that consist only of digits and which have no leading zeros (unless the entire serial number
```
```
consists of a single zero digit). These limitations are described in the encoding procedures, and in Section 12.3.1.
```
The ITIP consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity or its delegates. This is the same as the GS1 Company Prefix digits within a
GS1 GTIN key. See Section 7.3.2 for the case of a GTIN-8.
■ The Item Reference, assigned by the managing entity to a particular object class. The Item Reference as it appears in the EPC URI is derived
```
from the GTIN by concatenating the Indicator Digit of the GTIN (or a zero pad character, if the EPC URI is derived from a GTIN-8, GTIN-12, or
```
```
GTIN-13) and the Item Reference digits, and treating the result as a single numeric string. See Section 7.3.2 for the case of a GTIN-8.
```
■ The Piece Number
■ The Total Quantity of Pieces subordinate to the GTIN
■ The Serial Number, assigned by the managing entity to an individual object. The serial number is not part of the GTIN, but is formally a part of
both the SGTIN and the ITIP.
```
6.3.14 Unit Pack Identifier (UPUI)
```
The Unit Pack Identifier EPC scheme is used to uniquely identify an individual item for tobacco traceability in accordance with EU 2018/574.
General syntax:
```
urn:epc:id:upui:CompanyPrefix.ItemRefAndIndicator.TPX
```
```
Example:
```
```
urn:epc:id:upui:9521141.089456.51qIgY)%3C%26Jp3*j7'SDB
```
```
Grammar:
```
UPUI-URI = %s"urn:epc:id:upui:" UPUI-URIBody
```
UPUI-URIBody = 2(PaddedNumericComponent ".") GS3A3Component
```
```
The number of characters in the first two PaddedNumericComponent fields must total 13 (not including any of the dot characters).
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 68 of 448
The TPX field of the UPUI-URI is expressed as a GS3A3Component, which permits the representation of all characters permitted in
```
Application Identifier (235), Third Party Controlled, Serialised Extension of GTIN, according to the GS1 General Specifications.
```
The UPUI consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity or its delegates. This is the same as the GS1 Company Prefix digits within a
GS1 GTIN key. See Section 7.3.2 for the case of a GTIN-8.
■ The Item Reference, assigned by the managing entity to a particular object class. The Item Reference as it appears in the EPC URI is derived
```
from the GTIN by concatenating the Indicator Digit of the GTIN (or a zero pad character, if the EPC URI is derived from a GTIN-8, GTIN-12, or
```
```
GTIN-13) and the Item Reference digits, and treating the result as a single numeric string. See Section 7.3.2 for the case of a GTIN-8.
```
■ The Third Party Controlled, Serialised Extension of GTIN, assigned by a third party managing entity to an individual object to uniquely
identify an individual item for tobacco traceability in accordance with EU 2018/574.
```
6.3.15 Global Location Number of Party (PGLN)
```
The PGLN EPC scheme is used to assign a unique identity to a party, such as a an economic operator or a cost center.
General syntax:
```
urn:epc:id:pgln:CompanyPrefix.PartyReference
```
```
Example:
```
```
urn:epc:id:pgln:9521141.89012
```
```
Grammar:
```
PGLN-URI = %s"urn:epc:id:pgln:" PGLNURIBody
```
PGLNURIBody = PaddedNumericComponent "." PaddedNumericComponentOrEmpty
```
The number of characters in the first PaddedNumericComponent field and the PaddedNumericComponentOrEmpty field must total 12
```
(not including any of the dot characters).
```
The PGLN consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity. This is the same as the GS1 Company Prefix digits within a GS1 GLN key.
■ The Party Reference, assigned uniquely by the managing entity to a specific party.
```
6.3.16 General Identifier (GID)
```
The General Identifier EPC scheme is independent of any specifications or identity scheme outside TDS.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 69 of 448
General syntax:
```
urn:epc:id:gid:ManagerNumber.ObjectClass.SerialNumber
```
```
Example:
```
```
urn:epc:id:gid:95100000.12345.400
```
```
Grammar:
```
GID-URI = %s"urn:epc:id:gid:" GIDURIBody
```
GIDURIBody = 2(NumericComponent ".") NumericComponent
```
The GID consists of the following elements:
```
■ The General Manager Number identifies an organisational entity (essentially a company, manager or other organisation) that is responsible for
```
maintaining the numbers in subsequent fields – Object Class and Serial Number. Note that a General Manager Number is not a GS1 Company
Prefix. A General Manager Number may only be used in GID EPCs. NOTE that General Manager Number issuance has been discontinued,
effective June 2023.
■ The Object Class is used by an EPC managing entity to identify a class or "type" of thing. These object class numbers, of course, must be unique
within each General Manager Number domain.
■ Finally, the Serial Number code, or serial number, is unique within each object class. In other words, the managing entity is responsible for
assigning unique, non-repeating serial numbers for every instance within each object class.
```
6.3.17 US Department of Defense Identifier (DOD)
```
The US Department of Defense identifier is defined by the United States Department of Defense. This tag data construct may be used to
encode 96-bit Class 1 tags for shipping goods to the United States Department of Defense by a supplier who has already been assigned a
```
CAGE (Commercial and Government Entity) code.
```
At the time of this writing, the details of what information to encode into these fields is explained in a document titled "United States
Department of Defense Suppliers' Passive RFID Information Guide" [USDOD].
Note that the DoD Guide explicitly recognises the value of cross-branch, globally applicable standards, advising that "suppliers that are
EPCglobal subscribers and possess a unique [GS1] Company Prefix may use any of the identity types and encoding instructions described in
the EPC™ Tag Data Standards document to encode tags."
General syntax:
```
urn:epc:id:usdod:CAGECodeOrDODAAC.SerialNumber
```
```
Example:
```
```
urn:epc:id:usdod:2S194.12345678901
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 70 of 448
```
Grammar:
```
DOD-URI = %s"urn:epc:id:usdod:" DODURIBody
```
DODURIBody = CAGECodeOrDODAAC "." DoDSerialNumber
```
```
CAGECodeOrDODAAC = CAGECode / DODAAC
```
```
CAGECode = 5(CAGECodeOrDODAACChar)
```
```
DODAAC = 6(CAGECodeOrDODAACChar)
```
```
DoDSerialNumber = NumericComponent
```
```
CAGECodeOrDODAACChar = Digit / %x41-48 / %x4A-4E / %x50-5A ; 0-9 A-H J-N P-Z
```
```
6.3.18 Aerospace and Defense Identifier (ADI)
```
The variable-length Aerospace and Defense EPC identifier is designed for use by the aerospace and defense sector for the unique
```
identification of parts or items. The existing unique identifier constructs are defined in the Air Transport Association (ATA) Spec 2000
```
standard [SPEC2000], and the US Department of Defense Guide to Uniquely Identifying items [UID]. The ADI EPC construct provides a
mechanism to directly encode such unique identifiers in RFID tags and to use the URI representations in EPCIS and ALE.
Within the Aerospace & Defense sector identification constructs supported by the ADI EPC, companies are uniquely identified by their
```
Commercial And Government Entity (CAGE) code or by their Department of Defense Activity Address Code (DODAAC). The NATO CAGE
```
```
(NCAGE) code is issued by NATO / Allied Committee 135 and is structurally equivalent to a CAGE code (five character uppercase
```
```
alphanumeric excluding capital letters I and O) and is non-colliding with CAGE codes issued by the US Defense Logistics Information Service
```
```
(DLIS). Note that in the remainder of this section, all references to CAGE apply equally to NCAGE.
```
ATA Spec 2000 defines that a unique identifier may be constructed through the combination of the CAGE code or DODAAC together with
```
either:
```
```
■ A serial number (SER) that is assigned uniquely within the CAGE code or DODAAC; or
```
```
■ An original part number (PNO) that is unique within the CAGE code or DODAAC and a sequential serial number (SEQ) that is uniquely assigned
```
within that original part number.
```
The US DoD Guide to Uniquely Identifying Items defines a number of acceptable methods for constructing unique item identifiers (UIIs).
```
The UIIs that can be represented using the Aerospace and Defense EPC identifier are those that are constructed through the combination of
a CAGE code or DODAAC together with either:
```
■ a serial number that is unique within the enterprise identifier. (UII Construct #1)
```
```
■ an original part number and a serial number that is unique within the original part number (a subset of UII Construct #2)
```
Note that the US DoD UID guidelines recognise a number of unique identifiers based on GS1 identifier keys as being valid UIDs. In
```
particular, the SGTIN (GTIN + Serial Number), GIAI, and GRAI with full serialisation are recognised as valid UIDs. These may be
```
```
represented in EPC form using the SGTIN, GIAI, and GRAI EPC schemes as specified in Sections 6.3.1, 6.3.5, and 6.3.4, respectively; the
```
ADI EPC scheme is not used for this purpose. Conversely, the US DoD UID guidelines also recognise a wide range of enterprise identifiers
```
issued by various issuing agencies other than those described above; such UIDs do not have a corresponding EPC representation.
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 71 of 448
For purposes of identification via RFID of those aircraft parts that are traditionally not serialised or not required to be serialised for other
purposes, the ADI EPC scheme may be used for assigning a unique identifier to a part. In this situation, the first character of the serial
number component of the ADI EPC SHALL be a single '#' character. This is used to indicate that the serial number does not correspond to
the serial number of a traditionally serialised part because the '#' character is not permitted to appear within the values associated with
either the SER or SEQ text element identifiers in ATA Spec 2000 standard.
For parts that are traditionally serialised / required to be serialised for purposes other than having a unique RFID identifier, and for all usage
within US DoD UID guidelines, the '#' character SHALL NOT appear within the serial number element.
The ATA Spec 2000 standard recommends that companies serialise uniquely within their CAGE code. For companies who do serialise
uniquely within their CAGE code or DODAAC, a zero-length string SHALL be used in place of the Original Part Number element when
constructing an EPC.
General syntax:
```
urn:epc:id:adi:CAGECodeOrDODAAC.OriginalPartNumber.Serial
```
```
Examples:
```
```
urn:epc:id:adi:2S194..12345678901
```
```
urn:epc:id:adi:W81X9C.3KL984PX1.2WMA52
```
```
Grammar:
```
ADI-URI = %s"urn:epc:id:adi:" ADIURIBody
```
ADIURIBody = CAGECodeOrDODAAC "." ADIComponent "." ADIExtendedComponent
```
```
ADIComponent = 0*ADIChar
```
```
ADIExtendedComponent = 0*1"%23" 1*ADIChar
```
```
ADIChar = UpperAlpha / Digit / OtherADIChar
```
```
OtherADIChar = "-" / "%2F"
```
CAGECodeOrDODAAC is defined in Section 6.3.17.
```
6.3.19 BIC Container Code (BIC)
```
```
ISO 6346 is an international standard covering the coding, identification and marking of intermodal (shipping) containers used
```
within containerized intermodal freight transport. The standard establishes a visual identification system for every container that includes a
```
unique serial number (with check digit), the owner, a country code, a size, type and equipment category as well as any operational marks.
```
```
The standard is managed by the International Container Bureau (BIC).
```
```
(source: https://en.wikipedia.org/wiki/ISO_6346#Identification_System )
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 72 of 448
The BIC consists of the following elements:
■ The owner code consists of three capital letters of the Latin alphabet to indicate the owner or principal operator of the container. Such code
needs to be registered at the Bureau International des Conteneurs in Paris to ensure uniqueness worldwide.
■ The equipment category identifier consists of one of the following capital letters of the Latin alphabet:
□ U for all freight containers
□ J for detachable freight container-related equipment
□ Z for trailers and chassis
■ The serial number consists of 6 numeric digits, assigned by the owner or operator, uniquely identifying the container within that
owner/operator's fleet.
■ The check digit consists of one numeric digit providing a means of validating the recording and transmission accuracies of the owner code and
serial number.
```
The individual elements of the BIC are not separated by dots (".") in the EPC URI syntax.
```
General syntax:
```
urn:epc:id:bic:BICContainerCode
```
```
Example:
```
```
urn:epc:id:bic:CSQU3054383
```
```
Grammar:
```
BIC-URI = %s"urn:epc:id:bic:" BICURIBody
```
BICURIBody = OwnerCode EquipCatId SerialNumber CheckDigit
```
```
OwnerCode = 3(OwnerCodeChar)
```
```
EquipCatId = CatIdChar
```
```
SerialNumber = 6(Digit)
```
```
CheckDigit = Digit
```
```
OwnerCodeChar = %x41-48 / %x4A-4E / %x50-5A ; A-H J-N P-Z
```
```
CatIdChar = "J" / "U" / "Z"
```
```
6.3.20 IMO Vessel Number (IMOVN)
```
```
The IMO (International Maritime Organization) ship identification number scheme was introduced in 1987 through adoption of resolution
```
```
A.600(15), as a measure aimed at enhancing "maritime safety, and pollution prevention and to facilitate the prevention of maritime fraud".
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 73 of 448
It aimed at assigning a permanent number to each ship for identification purposes. That number would remain unchanged upon transfer of
```
the ship to other flag(s) and would be inserted in the ship's certificates. When made mandatory, through SOLAS regulation XI/3 (adopted in
```
```
1994), specific criteria of passenger ships of 100 gross tonnage and upwards and all cargo ships of 300 gross tonnage and upwards were
```
agreed.
SOLAS regulation XI-1/3 requires ships' identification numbers to be permanently marked in a visible place either on the ship's hull or
superstructure. Passenger ships should carry the marking on a horizontal surface visible from the air. Ships should also be marked with
their ID numbers internally.
This number is assigned to the total portion of the hull enclosing the machinery space and is the determining factor, should additional
sections be added.
The IMO number is never reassigned to another ship and is shown on the ship’s certificates.
```
(source: http://www.imo.org/en/OurWork/MSAS/Pages/IMO-identification-number-scheme.aspx)
```
The IMOVN consists of the following element:
■ a unique, seven-digit vessel number.
General syntax:
```
urn:epc:id:imovn:IMOvesselNumber
```
```
Example:
```
```
urn:epc:id:imovn:9176187
```
```
Grammar:
```
IMOVN-URI = %s"urn:epc:id:imovn:" IMOVNURIBody
```
IMOVNURIBody = VesselNumber
```
```
VesselNumber = 7(Digit)
```
6.4 EPC Class URI Syntax
This section specifies the syntax of an EPC Class URI.
The formal grammar for the EPC class URI is as follows:
EPCClass-URI = LGTIN-URI
where the various alternatives on the right hand side are specified in the sections that follow.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 74 of 448
Each EPC Class URI scheme is specified in one of the following subsections, as follows:
Table 6-1 EPC Class Schemes and Where the Pure Identity Form is Defined
EPC Class
Scheme
Specified In Corresponding GS1 key Typical use
lgtin Section 6.4.1 GTIN + Batch or Lot Number Class of objects
belonging to a given
batch or lot
```
6.4.1 GTIN + Batch/Lot (LGTIN)
```
The GTIN+ Batch/Lot scheme is used to denote a class of objects belonging to a given batch or lot of a given GTIN.
General syntax:
```
urn:epc:class:lgtin:CompanyPrefix.ItemRefAndIndicator.Lot
```
```
Example:
```
```
urn:epc:class:lgtin:4012345.012345.998877
```
```
Grammar:
```
LGTIN-URI = %s"urn:epc:class:lgtin:" LGTINURIBody
```
LGTINURIBody = 2(PaddedNumericComponent ".") GS3A3Component
```
```
The number of characters in the two PaddedNumericComponent fields must total 13 (not including any of the dot characters).
```
The Lot field of the LGTIN-URI is expressed as a GS3A3Component, which permits the representation of all characters permitted in the
```
Application Identifier (10) Batch or Lot Number according to the GS1 General Specifications.
```
The LGTIN consists of the following elements:
■ The GS1 Company Prefix, assigned by GS1 to a managing entity or its delegates. This is the same as the GS1 Company Prefix digits within a
GS1 GTIN key. See Section 7.3.2 for the case of a GTIN-8.
■ The Item Reference and Indicator, assigned by the managing entity to a particular object class. The Item Reference and Indicator as it
```
appears in the EPC URI is derived from the GTIN by concatenating the Indicator Digit of the GTIN (or a zero pad character, if the EPC URI is
```
```
derived from a GTIN-8, GTIN-12, or GTIN-13) and the Item Reference digits, and treating the result as a single numeric string. See Section 7.3.2
```
for the case of a GTIN-8.
■ The Batch or Lot Number, assigned by the managing entity to an distinct batch or lot of a class of objects. The batch or lot number is not part
of the GTIN, but is used to distinguish individual groupings of the same class of objects from each other.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 75 of 448
7 Correspondence between EPCs and GS1 Keys
```
As discussed in Section 4.3, there is a well-defined relationship between Electronic Product Codes (EPCs) and seven keys (plus the
```
```
component / part identifier) defined in the GS1 General Specifications [GS1GS]. This section specifies the correspondence between EPCs
```
and GS1 keys.
```
7.1 The GS1 Company Prefix (GCP) in EPC encodings
```
The correspondence between EPCs and GS1 keys relies on identifying the portion of a GS1 key that is the GS1 Company Prefix. The GS1
```
Company Prefix (GCP) is a 4- to 12-digit number assigned by a GS1 Member Organisation to a managing entity, and the managing entity is
```
free to create GS1 keys using that GCP. For purposes of the EPC Tag Data Standard, a 4- or 5-digit GCP is treated as a block of 100 6-digit
GCPs or a block of 10 6-digit GCPs, respectively. In the EPC URI, the GCP is encoded in the CompanyPrefix component, which SHALL include
the 4- or 5-digit GCP and the following 2 or 1 digits of the GS1 key, as though it were a 6-digit GCP. This value is then encoded into the EPC
```
binary encodings using Partition Value 6 (binary: 110).
```
7.2 Determining length of the EPC CompanyPrefix component for individually assigned GS1 Keys
```
In some instances, a GS1 Member Organisation assigns an individually assigned (AKA "single issue" or "one off") GS1 key, such as a
```
complete GTIN, GLN, or other key, to a subscribing organisation. In such cases, a subscribing organisation SHALL NOT use the digits
comprising a particular individually assigned key to construct any other kind of GS1 key. For example, if a subscribing organisation is issued
an individually assigned GLN, it SHALL NOT create SSCCs using the 12 digits of the individually assigned GLN as though it were a 12-digit
GS1 Company Prefix.
```
Note that an individually assigned key will generally resolve (e.g., via GEPIR) back to the issuing MO—as the GCP in question has been
```
assigned by the MO to itself for the purpose of generating individually assigned keys—rather than to the organisation to which the key was
issued. The allocation of individually assigned keys, based on a common GCP, to disparate subscribing organisations who have no particular
relationship to each other, effectively prevents use of the CompanyPrefix component of EPC encodings for purposes of
filtering/correlation/querying to the level of an individual organisation.
7.2.1 Individually assigned GTINs
When encoding an individually assigned GTIN as an EPC, the GTIN-12, GTIN-13 or GTIN-8 issued by the MO must first be converted to a
14-digit number by prepending two, one or six leading zeroes, respectively, to the individually assigned GTIN, as specified in sections and
7.3.1 and 7.3.2.
```
The individually assigned GTIN, after any necessary padding to increase its length to 14 digits, is stripped of its check digit (which is omitted
```
```
from all EPC encodings) and indicator digit or leading zero, and SHALL be contained in the CompanyPrefix component of the EPC, whose
```
length SHALL be fixed at 12 digits for an individually assigned GTIN. For a GTIN-12, GTIN-13 or GTIN-8, the ItemRefAndIndicator
component of the resulting SGTIN EPC is a single zero digit. For a GTIN-14, the ItemRefAndIndicator component of the resulting SGTIN
EPC consists of the GTIN-14's leading zero or indicator digit.
Note that these rules also apply to individually assigned GTINs assigned by third parties with the permission of GS1.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 76 of 448
```
Syntax:
```
```
urn:epc:id:sgtin:CompanyPrefix.ItemRefAndIndicator.SerialNumber
```
```
Example:
```
```
GS1 element string: (01)09526567890126(21)4711
```
EPC URI: urn:epc:id:sgtin:952656789012.0.4711
```
The corresponding EPC Binary encoding (SGTIN-96 and SGTIN-198) uses Partition Value 0, per Table 14-2 (SGTIN Partition Table).
```
7.2.2 Individually assigned GLNs
```
When encoding an individually assigned GLN as an EPC, the entire individually assigned GLN (stripped of its check digit, which is omitted
```
```
from EPC encodings) occupies the CompanyPrefix component of the EPC, whose length is fixed at 12 digits.
```
For the resulting SGLN EPC, the LocationReference component is a zero-length string. The Extension component of the SGLN EPC reflects
```
the value of the GLN extension component, AI (254); if the input GS1 element string did not include a GLN extension component (AI 254),
```
```
the Extension component of the SGLN EPC comprises a single zero digit (‘0’).
```
```
Note that these rules also apply to individually assigned GLNs (e.g., national business numbers) assigned by third parties with the
```
permission of GS1.
```
Syntax:
```
```
urn:epc:id:sgln:CompanyPrefix..Extension
```
```
Example (without extension):
```
```
GS1 element string: (414)9526567890126
```
EPC URI: urn:epc:id:sgln:952656789012..0
```
Example (with extension):
```
```
GS1 element string: (414)9526567890126(254)4711
```
EPC URI: urn:epc:id:sgln:952656789012..4711
```
The corresponding EPC Binary encoding (SGLN-96 and SGLN-195) uses Partition Value 0, per Table 14-7 (SGLN Partition Table).
```
7.2.3 Other individually assigned GS1 Keys
```
Other individually assigned GS1 Keys (e.g., SSCC, GIAI) should be encoded as EPCs with CompanyPrefix components that are 12 digits in
```
length.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 77 of 448
In such cases, a subscribing organisation SHALL NOT use the digits comprising a particular individually assigned key to construct any other
GS1 key. For example, if a subscribing organisation is issued an individually assigned SSCC, it SHALL NOT create additional SSCCs using the
12 digits of the individually assigned SSCC as though it were a 12-digit GCP.
```
Example (SSCC):
```
```
GS1 element string: (00)095265678901234568
```
EPC URI: urn:epc:id:sscc:952656789012.03456
```
Example (GIAI):
```
```
GS1 element string: (8004)952656789012345678901234567890
```
EPC URI: urn:epc:id:giai:952656789012.345678901234567890
The corresponding EPC Binary encoding uses Partition Value 0, per the respective Partition Table in section 14.
```
7.3 Serialised Global Trade Item Number (SGTIN)
```
```
The SGTIN EPC (Section 6.3.1) does not correspond directly to any GS1 key, but instead corresponds to a combination of a GTIN key plus a
```
serial number. The serial number in the SGTIN is defined to be equivalent to AI 21 in the GS1 General Specifications.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 78 of 448
```
The correspondence between the SGTIN EPC URI and a GS1 element string consisting of a GTIN key (AI 01) and a serial number (AI 21) is
```
depicted graphically below:
Figure 7-1 Correspondence between SGTIN EPC URI and GS1 element string
```
(Note that in the case of a GTIN-12 or GTIN-13, a zero pad character takes the place of the Indicator Digit in the figure above.)
```
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:sgtin:d2 …d(L+1) .d1d(L+2)d(L+3) …d13 .s1s2 …sK
```
```
GS1 element string: (01)d1d2 …d14 (21)s1s2 …sK
```
where 1 ≤ K ≤ 20.
To find the GS1 element string corresponding to an SGTIN EPC URI:
1. Number the digits of the first two components of the EPC as shown above. Note that there will always be a total of 13 digits.
2. Number the characters of the serial number (third) component of the EPC as shown above. Each si corresponds to either a single
character or to a percent-escape triplet consisting of a % character followed by two hexadecimal digit characters.
3. Calculate the check digit d14 = (10 – ((3(d1 + d3 + d5 + d7 + d9 + d11 + d13 ) + (d2 + d4 + d6 + d8 + d10 + d12 )) mod 10)) mod 10.
4. Arrange the resulting digits and characters as shown for the GS1 element string. If any si in the EPC URI is a percent-escape triplet
```
%xx, in the GS1 element string replace the triplet with the corresponding character according to Table A-1 (For a given percent-escape
```
```
triplet %xx, find the row of Table A-1 that contains xx in the "Hex Value" column; the "Graphic symbol" column then gives the
```
```
corresponding character to use in the GS1 element string.)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 79 of 448
```
To find the EPC URI corresponding to a GS1 element string that includes both a GTIN (AI 01) and a serial number (AI 21):
```
1. Number the digits and characters of the GS1 element string as shown above.
2. Except for a GTIN-8, determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an
external table of company prefixes. See Section 7.3.2 for the case of a GTIN-8.
3. Arrange the digits as shown for the EPC URI. Note that the GTIN check digit d14 is not included in the EPC URI. For each serial number
character si, replace it with the corresponding value in the "URI Form" column of Table A-1 – either the character itself or a percent-
escape triplet if si is not a legal URI character.
```
Example:
```
EPC URI: urn:epc:id:sgtin:9521141.012345.32a%2Fb
```
GS1 element string: (01)09521141123454(21)32a/b
```
```
In this example, the slash (/) character in the serial number must be represented as an escape triplet in the EPC URI.
```
7.3.1 GTIN-12 and GTIN-13
To find the EPC URI corresponding to the combination of a GTIN-12 or GTIN-13 and a serial number, first convert the GTIN-12 or GTIN-13
to a 14-digit number by adding two or one leading zero characters, respectively, as shown in [GS1GS] Section 3.3.2.
```
Example:
```
GTIN-12: 614141123452
Corresponding 14-digit number: 00614141123452
Corresponding SGTIN-EPC: urn:epc:id:sgtin:0614141.012345.Serial
```
Example:
```
GTIN-13: 9521141890127
Corresponding 14-digit number: 09521141890127
Corresponding SGTIN-EPC: urn:epc:id:sgtin:9521141.089012.Serial
7.3.2 GTIN-8
A GTIN-8 is a special case of the GTIN that is used to identify small trade items.
```
The GTIN-8 code consists of eight digits N 1 , N2…N8 , where the first digits N 1 to NL are the GS1-8 Prefix (where L = 1, 2, or 3), the next digits
```
NL+1 to N7 are the Item Reference, and the last digit N 8 is the check digit. The GS1-8 Prefix is a one-, two-, or three-digit index number,
administered by the GS1 Global Office. It does not identify the origin of the item. The Item Reference is assigned by the GS1 Member
Organisation. The GS1 Member Organisations provide procedures for obtaining GTIN-8s.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 80 of 448
To find the EPC URI corresponding to the combination of a GTIN-8 and a serial number, the following procedure SHALL be used. For the
purpose of the procedure defined above in Section 7.2.3, the GS1 Company Prefix portion of the EPC shall be constructed by prepending
```
five zeros to the first three digits of the GTIN-8; that is, the GS1 Company Prefix portion of the EPC is eight digits and shall be
```
00000N1 N2 N3 . The Item Reference for the procedure shall be the remaining GTIN-8 digits apart from the check digit, that is, N 4 to N7 . The
Indicator Digit for the procedure shall be zero.
```
Example:
```
GTIN-8: 95010939
Corresponding SGTIN-EPC: urn:epc:id:sgtin:00000950.01093.Serial
7.3.3 RCN-8
An RCN-8 is an 8-digit code beginning with GS1-8 Prefixes 0 or 2, as defined in [GS1GS] Section 2.1.11.1. These are reserved for company
internal numbering, and are not GTIN-8 codes. RCN-8 codes SHALL NOT be used to construct SGTIN EPCs, and the procedure for GTN-8
codes does not apply.
```
7.3.4 Company Internal Numbering (GS1 Prefixes 04 and 0001 – 0007)
```
```
The GS1 General Specifications reserve codes beginning with either 04 or 0001 through 0007 for company internal numbering. (See
```
```
[GS1GS], Sections 2.1.11.2 and 2.1.11.3.)
```
These numbers SHALL NOT be used to construct SGTIN EPCs. A future version of TDS may specify normative rules for using Company Internal
Numbering codes in EPCs.
```
7.3.5 Restricted Circulation (GS1 Prefixes 02 and 20 – 29)
```
The GS1 General Specifications reserve codes beginning with either 02 or 20 through 29 for restricted circulation for geopolitical areas
```
defined by GS1 member organisations and for variable measure trade items. (See [GS1GS], Sections 2.1.11.1 and 2.1.11.1.4)
```
These numbers SHALL NOT be used to construct SGTIN EPCs. A future version of TDS may specify normative rules for using Restricted
Circulation codes in EPCs.
```
7.3.6 Coupon Code Identification for Restricted Distribution (GS1 Prefixes 981-984 and 99)
```
Coupons may be identified by constructing codes according to Sections 2.6.1-2.6.3 of the GS1 General Specifications. The resulting
numbers begin with GS1 Prefixes 981-984 and 99. Strictly speaking, however, a coupon is not a trade item, and these coupon codes are not
actually trade item identification numbers.
Therefore, coupon codes for restricted distribution SHALL NOT be used to construct SGTIN EPCs.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 81 of 448
```
7.3.7 Refund Receipt (GS1 Prefix 980)
```
Section 2.6.4 of the GS1 General Specification specifies the construction of codes to represent refund receipts, such as those created by
bottle recycling machines for redemption at point-of-sale. The resulting number begins with GS1 Prefix 980. Strictly speaking, however, a
refund receipt is not a trade item, and these refund receipt codes are not actually trade item identification numbers.
Therefore, refund receipt codes SHALL NOT be used to construct SGTIN EPCs.
```
7.3.8 ISBN, ISMN, and ISSN (GS1 Prefixes 977, 978, or 979)
```
The GS1 General Specifications provide for the use of a 13-digit identifier to represent International Standard Book Number, International
Standard Music Number, and International Standard Serial Number codes. The resulting code is a GTIN whose GS1 Prefix is 977, 978, or
979.
7.3.8.1 ISBN and ISMN
```
ISBN and ISMN codes are used for books and printed music, respectively. The codes are defined by ISO (ISO 2108 for ISBN and ISO 10957
```
```
for ISMN) and administered by the International ISBN Agency (http://www.isbn-international.org/) and affiliated national registration
```
```
agencies. ISMN is a separate organisation (http://www.ismn-international.org/) but its management and coding structure are similar to the
```
ones of ISBN.
While these codes are not assigned by GS1, they have a very similar internal structure that readily lends itself to similar treatment when
creating EPCs. An ISBN code consists of the following parts, shown below with the corresponding concept from the GS1 system:
```
Prefix Element + Registrant Group Element = GS1 Prefix (978 or 979 plus more digits)
```
Registrant Element = Remainder of GS1 Company Prefix
Publication Element = Item Reference
Check Digit = Check Digit
The Registrant Group Elements are assigned to ISBN registration agencies, who in turn assign Registrant Elements to publishers, who in
turn assign Publication Elements to individual publication editions. This exactly parallels the construction of GTIN codes. As in GTIN, the
various components are of variable length, and as in GTIN, each publisher knows the combined length of the Registrant Group Element and
Registrant Element, as the combination is assigned to the publisher. The total length of the "978" or "979" Prefix Element, the Registrant
Group Element, and the Registrant Element is in the range of 6 to 12 digits, which is exactly the range of GS1 Company Prefix lengths
permitted in the SGTIN EPC. The ISBN and ISMN can thus be used to construct SGTINs as specified in this standard.
To find the EPC URI corresponding to the combination of an ISBN or ISMN and a serial number, the following procedure SHALL be used. For
the purpose of the procedure defined above in Section 7.2.3, the GS1 Company Prefix portion of the EPC shall be constructed by
```
concatenating the ISBN/ISMN Prefix Element (978 or 979), the Registrant Group Element, and the Registrant Element. The Item Reference
```
for the procedure shall be the digits of the ISBN/ISMN Publication Element. The Indicator Digit for the procedure shall be zero.
```
Example:
```
```
ISBN: 978-81-7525-766-5
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 82 of 448
Corresponding SGTIN-EPC: urn:epc:id:sgtin:978817525.0766.Serial
7.3.8.2 ISSN
The ISSN is the standardised international code which allows the identification of any serial publication, including electronic serials,
```
independently of its country of publication, of its language or alphabet, of its frequency, medium, etc. The code is defined by ISO (ISO
```
```
3297) and administered by the International ISSN Agency (http://www.issn.org/).
```
The ISSN is a GTIN starting with the GS1 prefix 977. The ISSN structure does not allow it to be expressed in an SGTIN format. Therefore,
pending formal requirements emerging from the serial publication sector, it is not currently possible to create an SGTIN on the basis of an
ISSN.
```
7.4 Serial Shipping Container Code (SSCC)
```
```
The SSCC EPC (Section 6.3.2) corresponds directly to the SSCC key defined in Sections 2.2.1 and 3.3.1 of the GS1 General Specifications
```
[GS1GS].
```
The correspondence between the SSCC EPC URI and a GS1 element string consisting of an SSCC key (AI 00) is depicted graphically below:
```
Figure 7-2 Correspondence between SSCC EPC URI and GS1 element string
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:sscc:d2d3…d(L+1) .d1d(L+2)d(L+3) …d17
```
```
GS1 element string: (00)d1d2 …d18
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 83 of 448
To find the GS1 element string corresponding to an SSCC EPC URI:
1. Number the digits of the two components of the EPC as shown above. Note that there will always be a total of 17 digits.
2. Calculate the check digit d18 = (10 – ((3(d1 + d3 + d5 + d7 + d9 + d11 + d13 + d15 + d17) + (d2 + d4 + d6 + d8 + d10 + d12 +
```
d14 + d16)) mod 10)) mod 10.
```
3. Arrange the resulting digits and characters as shown for the GS1 element string.
```
To find the EPC URI corresponding to a GS1 element string that includes an SSCC (AI 00):
```
1. Number the digits and characters of the GS1 element string as shown above.
2. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
3. Arrange the digits as shown for the EPC URI. Note that the SSCC check digit d18 is not included in the EPC URI.
```
Example:
```
EPC URI: urn:epc:id:sscc:9521141.1234567890
```
GS1 element string: (00)195211412345678900
```
```
7.5 Global Location Number With or Without Extension (SGLN)
```
```
The SGLN EPC (Section 6.3.3) corresponds either directly to a Global Location Number key (GLN) as specified in Sections 2.4.4 and 3.7.9 of
```
the GS1 General Specifications [GS1GS], or to the combination of a GLN key plus an extension number as specified in Section 3.5.11 of
[GS1GS]. An extension number of zero is reserved to indicate that an SGLN EPC denotes an unextended GLN, rather than a GLN plus
```
extension. (See Section 6.3.3 for an explanation of the letter "S" in "SGLN.")
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 84 of 448
```
The correspondence between the SGLN EPC URI and a GS1 element string consisting of a GLN key (AI 414) without an extension is depicted
```
graphically below:
Figure 7-3 Correspondence between SGLN EPC URI without extension and GS1 element string
```
The correspondence between the SGLN EPC URI and a GS1 element string consisting of a GLN key (AI 414) together with an extension (AI
```
```
254) is depicted graphically below:
```
Figure 7-4 Correspondence between SGLN EPC URI with extension and GS1 element string
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 85 of 448
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:sgln:d1d2 …dL .d(L+1)d(L+2) …d12 .s1s2 …sK
```
```
GS1 element string: (414)d1d2 …d13 (254)s1s2 …sK
```
To find the GS1 element string corresponding to an SGLN EPC URI:
1. Number the digits of the first two components of the EPC as shown above. Note that there will always be a total of 12 digits.
2. Number the characters of the Extension (third) component of the EPC as shown above. Each si corresponds to either a single character
or to a percent-escape triplet consisting of a % character followed by two hexadecimal digit characters.
3. Calculate the check digit d13 = (10 – ((3(d2 + d4 + d6 + d8 + d10 + d12 ) + (d1+ d3 + d5 + d7 + d9 + d11)) mod 10)) mod 10.
4. Arrange the resulting digits and characters as shown for the GS1 element string. If any si in the EPC URI is a percent-escape triplet
```
%xx, in the GS1 element string replace the triplet with the corresponding character according to Table A-1 (For a given percent-escape
```
```
triplet %xx, find the row of Table A-1 that contains xx in the "Hex Value" column; the "Graphic symbol" column then gives the
```
```
corresponding character to use in the GS1 element string.). If the serial number consists of a single character si and that character is
```
```
the digit zero (‘0’), omit the extension from the GS1 element string.
```
```
To find the EPC URI corresponding to a GS1 element string that includes a GLN (AI 414), with or without an accompanying
```
```
extension (AI 254):
```
1. Number the digits and characters of the GS1 element string as shown above.
2. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 86 of 448
3. Arrange the digits as shown for the EPC URI. Note that the GLN check digit d13 is not included in the EPC URI. For each serial number
character si, replace it with the corresponding value in the "URI Form" column of Table A-1 – either the character itself or a percent-
```
escape triplet if si is not a legal URI character. If the input GS1 element string did not include an extension (AI 254), use a single zero
```
```
digit (‘0’) as the entire serial number s1s2 …sK in the EPC URI.
```
```
Example (without extension):
```
EPC URI: urn:epc:id:sgln:9521141.12345.0
```
GS1 element string: (414)9521141123454
```
```
Example (with extension):
```
EPC URI: urn:epc:id:sgln:9521141.12345.32a%2Fb
```
GS1 element string: (414)9521141123454(254)32a/b
```
```
In this example, the slash (/) character in the serial number must be represented as an escape triplet in the EPC URI.
```
```
7.6 Global Returnable Asset Identifier (GRAI)
```
```
The GRAI EPC (Section 6.3.4) corresponds directly to a serialised GRAI key defined in Sections 2.3.1 and 3.9.3 of the GS1 General
```
Specifications [GS1GS]. Because an EPC always identifies a specific physical object, only GRAI keys that include the optional serial number
have a corresponding GRAI EPC. GRAI keys that lack a serial number refer to asset classes rather than specific assets, and therefore do not
```
have a corresponding EPC (just as a GTIN key without a serial number does not have a corresponding EPC).
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 87 of 448
Figure 7-5 Correspondence between GRAI EPC URI and GS1 element string
```
Note that the GS1 element string includes an extra zero (‘0’) digit following the Application Identifier (8003). This zero digit is extra
```
padding in the element string, and is not part of the GRAI key itself.
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:grai:d1d2 …dL .d(L+1)d(L+2) …d12 .s1s2 …sK
```
```
GS1 element string: (8003)0d1d2 …d13s1s2 …sK
```
To find the GS1 element string corresponding to a GRAI EPC URI:
1. Number the digits of the first two components of the EPC as shown above. Note that there will always be a total of 12 digits.
2. Number the characters of the serial number (third) component of the EPC as shown above. Each si corresponds to either a single
character or to a percent-escape triplet consisting of a % character followed by two hexadecimal digit characters.
3. Calculate the check digit d13 = (10 – ((3(d2 + d4 + d6 + d8 + d10 + d12 ) + (d1+ d3 + d5 + d7 + d9 + d11)) mod 10)) mod 10.
4. Arrange the resulting digits and characters as shown for the GS1 element string. If any si in the EPC URI is a percent-escape triplet
```
%xx, in the GS1 element string replace the triplet with the corresponding character according to Table A-1 (For a given percent-escape
```
```
triplet %xx, find the row of Table A-1 that contains xx in the "Hex Value" column; the "Graphic symbol" column then gives the
```
```
corresponding character to use in the GS1 element string.).
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 88 of 448
```
To find the EPC URI corresponding to a GS1 element string that includes a GRAI (AI 8003):
```
1. If the number of characters following the (8003) application identifier is less than or equal to 14, stop: this element string does not
have a corresponding EPC because it does not include the optional serial number.
2. Number the digits and characters of the GS1 element string as shown above.
3. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
4. Arrange the digits as shown for the EPC URI. Note that the GRAI check digit d13 is not included in the EPC URI. For each serial number
character si, replace it with the corresponding value in the "URI Form" column of Table A-1 – either the character itself or a percent-
escape triplet if si is not a legal URI character.
```
Example:
```
EPC URI: urn:epc:id:grai:9521141.12345.32a%2Fb
```
GS1 element string: (8003)0952114112345432a/b
```
```
In this example, the slash (/) character in the serial number must be represented as an escape triplet in the EPC URI.
```
```
7.7 Global Individual Asset Identifier (GIAI)
```
```
The GIAI EPC (Section 6.3.5) corresponds directly to the GIAI key defined in Sections 2.3.2 and 3.9.4 of the GS1 General Specifications
```
[GS1GS].
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 89 of 448
```
The correspondence between the GIAI EPC URI and a GS1 element string consisting of a GIAI key (AI 8004) is depicted graphically below:
```
Figure 7-6 Correspondence between GIAI EPC URI and GS1 element string
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
EPC URI: urn:epc:id:giai:d1d2 …dL .s1s2 …sK
```
GS1 element string: (8004)d1d2 …dLs1s2 …sK
```
To find the GS1 element string corresponding to a GIAI EPC URI:
1. Number the characters of the two components of the EPC as shown above. Each si corresponds to either a single character or to a
percent-escape triplet consisting of a % character followed by two hexadecimal digit characters.
2. Arrange the resulting digits and characters as shown for the GS1 element string. If any si in the EPC URI is a percent-escape triplet
```
%xx, in the GS1 element string replace the triplet with the corresponding character according to Table A-1 (For a given percent-escape
```
```
triplet %xx, find the row of Table A-1 that contains xx in the "Hex Value" column; the "Graphic symbol" column then gives the
```
```
corresponding character to use in the GS1 element string.)
```
```
To find the EPC URI corresponding to a GS1 element string that includes a GIAI (AI 8004):
```
1. Number the digits and characters of the GS1 element string as shown above.
2. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 90 of 448
3. Arrange the digits as shown for the EPC URI. For each serial number character si, replace it with the corresponding value in the "URI
Form" column of Table A-1 – either the character itself or a percent-escape triplet if si is not a legal URI character.
EPC URI: urn:epc:id:giai:9521141.32a%2Fb
```
GS1 element string: (8004)952114132a/b
```
```
In this example, the slash (/) character in the serial number must be represented as an escape triplet in the EPC URI.
```
```
7.8 Global Service Relation Number – Recipient (GSRN)
```
```
The GSRN EPC (Section 6.3.6) corresponds directly to the GSRN – Recipient key defined in Sections 2.5.2 and 3.9.14 of the GS1 General
```
Specifications [GS1GS].
```
The correspondence between the GSRN EPC URI and a GS1 element string consisting of a GSRN key (AI 8018) is depicted graphically
```
```
below:
```
Figure 7-7 Correspondence between GSRN EPC URI and GS1 element string
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:gsrn:d1d2 …dL .d(L+1)d(L+2) …d17
```
```
GS1 element string: (8018)d1d2 …d18
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 91 of 448
To find the GS1 element string corresponding to a GSRN EPC URI:
1. Number the digits of the two components of the EPC as shown above. Note that there will always be a total of 17 digits.
2. Calculate the check digit d18 = (10 – ((3(d1 + d3 + d5 + d7 + d9 + d11 + d13 + d15 + d17 ) + (d2 + d4 + d6 + d8 + d10 + d12 + d14 + d16 ))
```
mod 10)) mod 10.
```
3. Arrange the resulting digits and characters as shown for the GS1 element string.
```
To find the EPC URI corresponding to a GS1 element string that includes a GSRN – Recipient (AI 8018):
```
1. Number the digits and characters of the GS1 element string as shown above.
2. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
3. Arrange the digits as shown for the EPC URI. Note that the GSRN check digit d18 is not included in the EPC URI.
```
Example:
```
EPC URI: urn:epc:id:gsrn:9521141.1234567890
```
GS1 element string: (8018)952114112345678906
```
```
7.9 Global Service Relation Number – Provider (GSRNP)
```
```
The GSRNP EPC (Section 6.3.6) corresponds directly to the GSRN – Provider key defined in Sections 2.5.1 and 3.9.14 of the GS1 General
```
Specifications [GS1GS].
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 92 of 448
```
The correspondence between the GSRNP EPC URI and a GS1 element string consisting of a GSRN – Provider key (AI 8017) is depicted
```
graphically below:
Figure 7-8 Correspondence between GSRNP EPC URI and GS1 element string
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:gsrnp:d1d2 …dL .d(L+1)d(L+2) …d17
```
```
GS1 element string: (8017)d1d2 …d18
```
To find the GS1 element string corresponding to a GSRNP EPC URI:
1. Number the digits of the two components of the EPC as shown above. Note that there will always be a total of 17 digits.
2. Calculate the check digit d18 = (10 – ((3(d1 + d3 + d5 + d7 + d9 + d11 + d13 + d15 + d17 ) + (d2 + d4 + d6 + d8 + d10 + d12 + d14 + d16 ))
```
mod 10)) mod 10.
```
3. Arrange the resulting digits and characters as shown for the GS1 element string.
```
To find the EPC URI corresponding to a GS1 element string that includes a GSRN – Provider (AI 8017):
```
1. Number the digits and characters of the GS1 element string as shown above.
2. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
3. Arrange the digits as shown for the EPC URI. Note that the GSRN check digit d18 is not included in the EPC URI.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 93 of 448
```
Example:
```
EPC URI: urn:epc:id:gsrnp:9521141.1234567890
```
GS1 element string: (8017)952114112345678906
```
```
7.10 Global Document Type Identifier (GDTI)
```
```
The GDTI EPC (Section 6.3.7) corresponds directly to a serialised GDTI key defined in Sections 2.6.9 and 3.5.10 of the GS1 General
```
Specifications [GS1GS]. Because an EPC always identifies a specific physical object, only GDTI keys that include the optional serial number
have a corresponding GDTI EPC. GDTI keys that lack a serial number refer to document classes rather than specific documents, and
```
therefore do not have a corresponding EPC (just as a GTIN key without a serial number does not have a corresponding EPC).
```
Figure 7-9 Correspondence between GDTI EPC URI and GS1 element string
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:gdti:d1d2 …dL .d(L+1)d(L+2) …d12 .s1s2 …sK
```
```
GS1 element string: (253)d1d2 …d13s1s2 …sK
```
To find the GS1 element string corresponding to a GDTI EPC URI:
1. Number the digits of the first two components of the EPC as shown above. Note that there will always be a total of 12 digits.
2. Number the characters of the serial number (third) component of the EPC as shown above. Each si corresponds to either a single
character or to a percent-escape triplet consisting of a % character followed by two hexadecimal digit characters.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 94 of 448
3. Calculate the check digit d13 = (10 – ((3(d2 + d4 + d6 + d8 + d10 + d12 ) + (d1+ d3 + d5 + d7 + d9 + d11)) mod 10)) mod 10.
4. Arrange the resulting digits and characters as shown for the GS1 element string. If any si in the EPC URI is a percent-escape triplet
```
%xx, in the GS1 element string replace the triplet with the corresponding character according to Table A-1 (For a given percent-escape
```
```
triplet %xx, find the row of Table A-1 that contains xx in the "Hex Value" column; the "Graphic symbol" column then gives the
```
```
corresponding character to use in the GS1 element string.).
```
```
To find the EPC URI corresponding to a GS1 element string that includes a GDTI (AI 253):
```
1. If the number of characters following the (253) application identifier is less than or equal to 13, stop: this element string does not have a
corresponding EPC because it does not include the optional serial number.
2. Number the digits and characters of the GS1 element string as shown above.
3. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
4. Arrange the digits as shown for the EPC URI. Note that the GDTI check digit d13 is not included in the EPC URI. For each serial number
character si, replace it with the corresponding value in the "URI Form" column of Table A-1 – either the character itself or a percent-
escape triplet if si is not a legal URI character.
```
Example:
```
EPC URI: urn:epc:id:gdti:9521141.12345.006847
```
GS1 element string: (253)9521141123454006847
```
```
7.11 Component and Part Identifier (CPI)
```
```
The CPI EPC (Section 6.3.9) does not correspond directly to any GS1 key, but instead corresponds to a combination of two data elements
```
defined in sections 3.9.10 and 3.9.11 of the GS1 General Specifications [GS1GS].
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 95 of 448
```
The correspondence between the CPI EPC URI and a GS1 element string consisting of a Component / Part Identifier (AI 8010) and a
```
```
Component / Part serial number (AI 8011) is depicted graphically below:
```
Figure 7-10 Correspondence between CPI EPC URI and GS1 element string
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:cpi:d1d2 …dL .d(L+1)d(L+2) …dN .s1s2 …sK
```
```
GS1 element string: (8010)d1d2 …dN (8011)s1s2 …sK
```
where 1 ≤ N ≤ 30 and 1 ≤ K ≤ 12.
To find the GS1 element string corresponding to a CPI EPC URI:
1. Number the digits of the three components of the EPC as shown above. Each di in the second component corresponds to either a single
character or to a percent-escape triplet consisting of a % character followed by two hexadecimal digit characters.
2. Arrange the resulting digits and characters as shown for the GS1 element string. If any di in the EPC URI is a percent-escape triplet
```
%xx, in the GS1 element string replace the triplet with the corresponding character according to Table G-1 (G). (For a given percent-
```
```
escape triplet %xx, find the row of Table G-1 that contains xx in the "Hex Value" column; the "Graphic symbol" column then gives the
```
```
corresponding character to use in the GS1 element string.)
```
```
To find the EPC URI corresponding to a GS1 element string that includes both a Component / Part Identifier (AI 8010) and a
```
```
Component / Part Serial Number (AI 8011):
```
1. Number the digits and characters of the GS1 element string as shown above.
2. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 96 of 448
3. Arrange the characters as shown for the EPC URI. For each component/part character di, replace it with the corresponding value in the
```
"URI Form" column of Table G-1 (G) – either the character itself or a percent-escape triplet if di is not a legal URI character.
```
```
Example:
```
EPC URI: urn:epc:id:cpi:9521141.5PQ7%2FZ43.12345
```
GS1 element string: (8010)95211415PQ7/Z43(8011)12345
```
```
Spaces have been added to the GS1 element string for clarity, but they are not normally present. In this example, the slash (/) character in
```
the component/part reference must be represented as an escape triplet in the EPC URI.
```
7.12 Serialised Global Coupon Number (SGCN)
```
```
The SGCN EPC (Section 6.3.10) corresponds directly to a serialised GCN key defined in Sections 2.6.1 and 3.5.12 of the GS1 General
```
Specifications [GS1GS]. Because an EPC always identifies a specific physical or digital object, only SGCN keys that include the serial number
have a corresponding SGCN EPC. GCN keys that lack a serial number refer to coupon classes rather than specific coupons, and therefore do
not have a corresponding EPC.
Figure 7-11 Correspondence between SGCN EPC URI and GS1 element string
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:sgcn:d1d2 …dL .d(L+1)d(L+2) …d12 .s1s2 …sK
```
```
GS1 element string: (255)d1d2 …d13s1s2 …sK
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 97 of 448
To find the GS1 element string corresponding to a SGCN EPC URI:
1. Number the digits of the first two components of the EPC as shown above. Note that there will always be a total of 12 digits.
2. Number the characters of the serial number (third) component of the EPC as shown above. Each si is a digit character.
3. Calculate the check digit d13 = (10 – ((3(d2 + d4 + d6 + d8 + d10 + d12 ) + (d1+ d3 + d5 + d7 + d9 + d11)) mod 10)) mod 10.
4. Arrange the resulting digits as shown for the GS1 element string.
```
To find the EPC URI corresponding to a GS1 element string that includes a GCN (AI 255):
```
1. If the number of characters following the (255) application identifier is less than or equal to 13, stop: this element string does not have
a corresponding EPC because it does not include the optional serial number.
2. Number the digits and characters of the GS1 element string as shown above.
3. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
4. Arrange the digits as shown for the EPC URI. Note that the GCN check digit d13 is not included in the EPC URI.
```
Example:
```
EPC URI: urn:epc:id:sgcn:9521141.67890.04711
```
GS1 element string: (255)952114167890904711
```
```
7.13 Global Identification Number for Consignment (GINC)
```
```
The GINC EPC (Section 6.5.1) corresponds directly to the GINC key defined in Sections 2.2.2 and 3.7.2 of the GS1 General Specifications
```
[GS1GS].
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 98 of 448
```
The correspondence between the GINC EPC URI and a GS1 element string consisting of a GINC key (AI 401) is depicted graphically below:
```
Figure 7-12 Correspondence between GINC EPC URI and GS1 element string
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
EPC URI: urn:epc:id:ginc:d1d2 …dL .s1s2 …sK
```
GS1 element string: (401)d1d2 …dLs1s2 …sK
```
To find the GS1 element string corresponding to a GINC EPC URI:
1. Number the characters of the two components of the EPC as shown above. Each si corresponds to either a single character or to a
percent-escape triplet consisting of a % character followed by two hexadecimal digit characters.
2. Arrange the resulting digits and characters as shown for the GS1 element string. If any si in the EPC URI is a percent-escape triplet
```
%xx, in the GS1 element string replace the triplet with the corresponding character according to Table A-1 (For a given percent-escape
```
```
triplet %xx, find the row of Table A-1 that contains xx in the "Hex Value" column; the "Graphic symbol" column then gives the
```
```
corresponding character to use in the GS1 element string.)
```
```
To find the EPC URI corresponding to a GS1 element string that includes a GINC (AI 401):
```
1. Number the digits and characters of the GS1 element string as shown above.
2. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
3. Arrange the digits as shown for the EPC URI. For each serial number character si, replace it with the corresponding value in the "URI
Form" column of Table A-1 – either the character itself or a percent-escape triplet if si is not a legal URI character.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 99 of 448
```
Example:
```
EPC URI: urn:epc:id:ginc:9521141.xyz47%2F11
```
GS1 element string: (401)9521141xyz47/11
```
```
In this example, the slash (/) character in the serial number must be represented as an escape triplet in the EPC URI.
```
```
7.14 Global Shipment Identification Number (GSIN)
```
```
The GSIN EPC (Section 6.5.2) corresponds directly to the GSIN key defined in Sections 2.2.3 and 3.7.3 of the GS1 General Specifications
```
[GS1GS].
```
The correspondence between the GSIN EPC URI and a GS1 element string consisting of an GSIN key (AI 402) is depicted graphically below:
```
Figure 7-13 Correspondence between GSIN EPC URI and GS1 element string
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:gsin:d1d2…dL .d(L+1)d(L+2)d(L+3) …d16
```
```
GS1 element string: (402)d1d2 …d17
```
To find the GS1 element string corresponding to an GSIN EPC URI:
1. Number the digits of the two components of the EPC as shown above. Note that there will always be a total of 16 digits.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 100 of 448
2. Calculate the check digit d17 = (10 – (((d1 + d3 + d5 + d7 + d9 + d11 + d13 + d15 ) + 3(d2 + d4 + d6 + d8 + d10 + d12 + d14 + d16 )) mod
```
10)) mod 10.
```
Arrange the resulting digits and characters as shown for the GS1 element string.
1. To find the EPC URI corresponding to a GS1 element string that includes a GSIN (AI 402):
2. Number the digits and characters of the GS1 element string as shown above.
3. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
4. Arrange the digits as shown for the EPC URI. Note that the GSIN check digit d17 is not included in the EPC URI.
```
Example:
```
EPC URI: urn:epc:id:gsin:9521141.123456789
```
GS1 element string: (402)95211411234567892
```
```
7.15 Individual Trade Item Piece (ITIP)
```
```
The ITIP EPC (Section 6.3.13) does not correspond directly to any GS1 key, but instead corresponds to a combination of AIs (8006) and
```
```
(21).
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 101 of 448
```
The correspondence between the ITIP EPC URI and a GS1 element string consisting of AI (8006) and AI (21) is depicted graphically below:
```
Figure 7-14 Correspondence between ITIP EPC URI and GS1 element string
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:itip:d2 …d(L+1) .d1d(L+2)d(L+3) …d13 . ) .d1d2.d1d2 .s1s2 …sK
```
```
GS1 element string: (8006)d1d2 …d18 (21)s1s2 …sK
```
where 1 ≤ K ≤ 20.
To find the GS1 element string corresponding to an ITIP EPC URI:
1. Number the digits of the first four components of the EPC as shown above. Note that there will always be a total of 17 digits.
2. Number the characters of the serial number (seventh) component of the EPC as shown above. Each si corresponds to either a single
character or to a percent-escape triplet consisting of a % character followed by two hexadecimal digit characters.
3. Calculate the check digit d14 = (10 – ((3(d1 + d3 + d5 + d7 + d9 + d11 + d13 ) + (d2 + d4 + d6 + d8 + d10 + d12 )) mod 10)) mod 10.
4. Arrange the resulting digits and characters as shown for the GS1 element string. If any si in the EPC URI is a percent-escape triplet
```
%xx, in the GS1 element string replace the triplet with the corresponding character according to Table A-1 (For a given percent-escape
```
```
triplet %xx, find the row of Table A-1 that contains xx in the "Hex Value" column; the "Graphic symbol" column then gives the
```
```
corresponding character to use in the GS1 element string.)
```
```
To find the EPC URI corresponding to a GS1 element string that includes both AI (8006) and AI (21):
```
1. Number the digits and characters of the GS1 element string as shown above.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 102 of 448
Except for a GTIN-8, determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an
external table of company prefixes. See Section 7.3.2 for the case of a GTIN-8.
2. Arrange the digits as shown for the EPC URI. Note that the GTIN check digit d14 is not included in the EPC URI. For each serial number
character si, replace it with the corresponding value in the "URI Form" column of Table A-1 – either the character itself or a percent-
escape triplet if si is not a legal URI character.
```
Example:
```
EPC URI: urn:epc:id:itip:9521141.012345.04.04.32a%2Fb
```
GS1 element string: (8006)095211411234540404(21)32a/b
```
```
In this example, the slash (/) character in the serial number must be represented as an escape triplet in the EPC URI.
```
```
7.16 Unit Pack Identifier (UPUI)
```
```
The UPUI EPC (Section 6.3.14) does not correspond directly to any GS1 key, but instead corresponds to a combination of a GTIN key plus a
```
```
Third Party Controlled, Serialised Extension of GTIN (TPX), as specified in the GS1 General Specifications [GS1GS].
```
```
The correspondence between the UPUI EPC URI and a GS1 element string consisting of a GTIN key (AI 01) and a Third Party Controlled,
```
```
Serialised Extension of GTIN (AI 235) is depicted graphically below:
```
Figure 7-15 Correspondence between UPUI EPC URI and GS1 element string
```
(Note that in the case of a GTIN-12 or GTIN-13, a zero pad character takes the place of the Indicator Digit in the figure above.)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 103 of 448
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:upui:d2 …d(L+1) .d1d(L+2)d(L+3) …d13 .s1s2 …sK
```
```
GS1 element string: (01)d1d2 …d14 (235)s1s2 …sK
```
where 1 ≤ K ≤ 28.
To find the GS1 element string corresponding to a UPUI EPC URI:
1. Number the digits of the first two components of the EPC as shown above. Note that there will always be a total of 13 digits.
2. Number the characters of the third component (TPX) of the EPC as shown above. Each si corresponds to either a single character or to
a percent-escape triplet consisting of a % character followed by two hexadecimal digit characters.
3. Calculate the check digit d14 = (10 – ((3(d1 + d3 + d5 + d7 + d9 + d11 + d13 ) + (d2 + d4 + d6 + d8 + d10 + d12 )) mod 10)) mod 10.
4. Arrange the resulting digits and characters as shown for the GS1 element string. If any si in the EPC URI is a percent-escape triplet
```
%xx, in the GS1 element string replace the triplet with the corresponding character according to Table A-1 (For a given percent-escape
```
```
triplet %xx, find the row of Table A-1 that contains xx in the "Hex Value" column; the "Graphic symbol" column then gives the
```
```
corresponding character to use in the GS1 element string.)
```
```
To find the EPC URI corresponding to a GS1 element string that includes both a GTIN (AI 01) and a Third Party Controlled,
```
```
Serialised Extension of GTIN (AI 235):
```
1. Number the digits and characters of the GS1 element string as shown above.
2. Except for a GTIN-8, determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an
external table of company prefixes. See Section 7.3.2 for the case of a GTIN-8.
3. Arrange the digits as shown for the EPC URI. Note that the GTIN check digit d14 is not included in the EPC URI. For each serial number
character si, replace it with the corresponding value in the "URI Form" column of Table A-1 – either the character itself or a percent-
escape triplet if si is not a legal URI character.
```
Example:
```
```
EPC URI: urn:epc:id:upui:9521141.089456.51qIgY)%3C%26Jp3*j7'SDB
```
```
GS1 element string: (01)09521141894569(235)51qIgY)<&Jp3*j7'SDB
```
```
In this example, the ‘less than’ (<) and ampersand (&) characters in the serial number must be represented as an escape triplet in the EPC
```
URI.
```
7.17 Global Location Number of Party (PGLN)
```
```
The PGLN EPC (Section 6.3.15) corresponds directly to the Global Location Number of a Party (PARTY) as specified in the GS1 General
```
Specifications [GS1GS].
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 104 of 448
```
The correspondence between the PGLN EPC URI and a GS1 element string consisting of a GLN Party key (AI 417) is depicted graphically
```
```
below:
```
Figure 7-16 Correspondence between PGLN EPC URI without extension and GS1 element string
Formally, the correspondence is defined as follows. Let the EPC URI and the GS1 element string be written as follows:
```
EPC URI: urn:epc:id:pgln:d1d2 …dL .d(L+1)d(L+2) …d12 .s1s2 …sK
```
```
GS1 element string: (417)d1d2 …d13
```
To find the GS1 element string corresponding to an PGLN EPC URI:
1. Number the digits of the first two components of the EPC as shown above. Note that there will always be a total of 12 digits.
2. Calculate the check digit d13 = (10 – ((3(d2 + d4 + d6 + d8 + d10 + d12 ) + (d1+ d3 + d5 + d7 + d9 + d11)) mod 10)) mod 10.
3. Arrange the resulting digits as shown for the GS1 element string.
```
To find the EPC URI corresponding to a GS1 element string that includes a GLN (AI 417):
```
1. Number the digits and characters of the GS1 element string as shown above.
2. Determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an external table of
company prefixes.
3. Arrange the digits as shown for the EPC URI. Note that the GLN check digit d13 is not included in the EPC URI.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 105 of 448
```
Example:
```
EPC URI: urn:epc:id:pgln:9521141.89012
```
GS1 element string: (417)9521141890127
```
```
7.18 GTIN + batch/lot (LGTIN)
```
```
The LGTIN EPC Class (Section 6.3.1) does not correspond directly to any GS1 key, but instead corresponds to a combination of a GTIN key
```
plus a Batch/Lot Number. The Batch/Lot Number in the LGTIN is defined to be equivalent to AI 10 in the GS1 General Specifications.
```
The correspondence between the LGTIN EPC Class URI and a GS1 element string consisting of a GTIN key (AI 01) and a Batch/Lot Number
```
```
(AI 10) is depicted graphically below:
```
Figure 7-17 Correspondence between LGTIN EPC Class URI and GS1 element string
```
(Note that in the case of a GTIN-12 or GTIN-13, a zero pad character takes the place of the Indicator Digit in the figure above.)
```
Formally, the correspondence is defined as follows. Let the EPC Class URI and the GS1 element string be written as follows:
```
EPC Class URI: urn:epc:class:lgtin:d2d3 …d(L+1).d1d(L+2)d(L+3) …d13 .s1s2 …sK
```
```
GS1 element string: (01)d1d2 …d14 (10)s1s2 …sK
```
where 1 ≤ K ≤ 20.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 106 of 448
To find the GS1 element string corresponding to an LGTIN EPC Class URI:
1. Number the digits of the first two components of the URI as shown above. Note that there will always be a total of 13 digits.
2. Number the characters of the Batch/Lot Number (third) component of the URI as shown above. Each si corresponds to either a single
character or to a percent-escape triplet consisting of a % character followed by two hexadecimal digit characters.
3. Calculate the check digit d14 = (10 – ((3(d1 + d3 + d5 + d7 + d9 + d11 + d13 ) + (d2 + d4 + d6 + d8 + d10 + d12 )) mod 10)) mod 10.
4. Arrange the resulting digits and characters as shown for the GS1 element string. If any si in the URI is a percent-escape triplet %xx, in
```
the GS1 element string replace the triplet with the corresponding character according to Table A-1 (For a given percent-escape triplet
```
```
%xx, find the row of Table A-1 that contains xx in the "Hex Value" column; the "Graphic symbol" column then gives the corresponding
```
```
character to use in the GS1 element string.)
```
```
To find the EPC Class URI corresponding to a GS1 element string that includes both a GTIN (AI 01) and a Batch/Lot Number
```
```
(AI 10):
```
1. Number the digits and characters of the GS1 element string as shown above.
2. Except for a GTIN-8, determine the number of digits L in the GS1 Company Prefix. This may be done, for example, by reference to an
external table of company prefixes. See Section 7.3.2 for the case of a GTIN-8.
3. Arrange the digits as shown for the EPC Class URI. Note that the GTIN check digit d14 is not included in the EPC Class URI. For each
serial number character si, replace it with the corresponding value in the "URI Form" column of Table A-1 – either the character itself or
a percent-escape triplet if si is not a legal URI character.
```
Example:
```
EPC Class URI: urn:epc:class:lgtin:9521141.712345.32a%2Fb
```
GS1 element string: (01)79521141123453(10) 32a/b
```
```
In this example, the slash (/) character in the serial number must be represented as an escape triplet in the EPC Class URI.
```
For GTIN-12, GTIN-13, GTIN-8 and other forms of the GTIN, see the subsections of Section 7.1. The considerations in those sections apply
in an analogous manner to LGTIN.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 107 of 448
8 URIs for EPC Pure identity patterns
Certain software applications need to specify rules for filtering lists of EPC pure identities according to various criteria. This specification
provides a Pure Identity Pattern URI form for this purpose. A Pure Identity Pattern URI does not represent a single EPC, but rather refers to
a set of EPCs. A typical Pure Identity Pattern URI looks like this:
```
urn:epc:idpat:sgtin:0652642.*.*
```
This pattern refers to any EPC SGTIN, whose GS1 Company Prefix is 0652642, and whose Item Reference and Serial Number may be
anything at all. The tag length and filter bits are not considered at all in matching the pattern to EPCs.
The new EPC schemes defined in TDS v2.0 have not defined an equivalent EPC Pure Identity URI syntax nor a corresponding EPC Pure
```
Identity Pattern URI syntax; instead the encoding/decoding is between the binary string and the corresponding GS1 element string, GS1
```
Digital Link URI or equivalently, the set of GS1 Application Identifiers and their values, as shown in Figure 1.
```
In general, there is a Pure Identity Pattern URI scheme corresponding to each Pure Identity EPC URI scheme (Section 6.3), whose syntax is
```
```
essentially identical except that any number of fields starting at the right may be a star (*). This is more restrictive than EPC Tag Pattern
```
```
URIs (Section 13), in that the star characters must occupy adjacent rightmost fields and the range syntax is not allowed at all.
```
The pure identity pattern URI for the DoD Construct is as follows:
```
urn:epc:idpat:usdod:CAGECodeOrDODAACPat.serialNumberPat
```
```
with similar restrictions on the use of star (*).
```
8.1 Syntax
The grammar for Pure Identity Pattern URIs is given below.
```
IDPatURI = %s"urn:epc:idpat:" IDPatBody
```
```
IDPatBody =
```
GIDIDPatURIBody /
SGTINIDPatURIBody /
SGLNIDPatURIBody /
GIAIIDPatURIBody /
SSCCIDPatURIBody /
GRAIIDPatURIBody /
GSRNIDPatURIBody /
GSRNPIDPatURIBody /
GDTIIDPatURIBody /
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 108 of 448
SGCNIDPatURIBody /
GINCIDPatURIBody /
GSINIDPatURIBody /
DODIDPatURIBody /
ADIIDPatURIBody /
CPIIDPatURIBody /
ITIPIDPartURIBody /
UPUIIDPatURIBody/
PGLNIDPatURIBody
```
GIDIDPatURIBody = %s"gid:" GIDIDPatURIMain
```
```
GIDIDPatURIMain =
```
```
2(NumericComponent ".") NumericComponent
```
```
/ 2(NumericComponent ".") "*"
```
/ NumericComponent ".*.*"
/ "*.*.*"
```
SGTINIDPatURIBody = %s"sgtin:" SGTINPatURIMain
```
```
SGTINPatURIMain =
```
```
2(PaddedNumericComponent ".") GS3A3Component
```
```
/ 2(PaddedNumericComponent ".") "*"
```
/ PaddedNumericComponent ".*.*"
/ "*.*.*"
```
GRAIIDPatURIBody = %s"grai:" SGLNGRAIIDPatURIMain
```
```
SGLNIDPatURIBody = %s"sgln:" SGLNGRAIIDPatURIMain
```
```
SGLNGRAIIDPatURIMain =
```
PaddedNumericComponent "." PaddedNumericComponentOrEmpty "." GS3A3Component
/ PaddedNumericComponent "." PaddedNumericComponentOrEmpty ".*"
/ PaddedNumericComponent ".*.*"
/ "*.*.*"
```
SSCCIDPatURIBody = %s"sscc:" SSCCIDPatURIMain
```
```
SSCCIDPatURIMain =
```
PaddedNumericComponent "." PaddedNumericComponent
/ PaddedNumericComponent ".*"
/ "*.*"
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 109 of 448
```
GIAIIDPatURIBody = %s"giai:" GIAIIDPatURIMain
```
```
GIAIIDPatURIMain =
```
PaddedNumericComponent "." GS3A3Component
/ PaddedNumericComponent ".*"
/ "*.*"
```
GSRNIDPatURIBody = %s"gsrn:" GSRNIDPatURIMain
```
```
GSRNPIDPatURIBody = %s"gsrnp:" GSRNIDPatURIMain
```
```
GSRNIDPatURIMain =
```
PaddedNumericComponent "." PaddedNumericComponent
/ PaddedNumericComponent ".*"
/ "*.*"
```
GDTIIDPatURIBody = %s"gdti:" GDTIIDPatURIMain
```
```
GDTIIDPatURIMain =
```
PaddedNumericComponent "." PaddedNumericComponentOrEmpty "." GS3A3Component
/ PaddedNumericComponent "." PaddedNumericComponentOrEmpty ".*"
/ PaddedNumericComponent ".*.*"
/ "*.*.*"
```
CPIIDPatURIBody = %s"cpi:" CPIIDPatMain
```
```
CPIIDPatMain =
```
PaddedNumericComponent "." CPRefComponent "." NumericComponent
/ PaddedNumericComponent "." CPRefComponent ".*"
/ PaddedNumericComponent ".*.*"
/ "*.*.*"
```
SGCNIDPatURIBody = %s"sgcn:" SGCNIDPatURIMain
```
```
SGCNIDPatURIMain =
```
PaddedNumericComponent "." PaddedNumericComponentOrEmpty "." PaddedNumericComponent
/ PaddedNumericComponent "." PaddedNumericComponentOrEmpty ".*"
/ PaddedNumericComponent ".*.*"
/ "*.*.*"
```
GINCIDPatURIBody = %s"ginc:" GINCIDPatURIMain
```
```
GINCIDPatURIMain =
```
PaddedNumericComponent "." GS3A3Component
/ PaddedNumericComponent ".*"
/ "*.*"
```
GSINIDPatURIBody = %s"gsin:" GSINIDPatURIMain
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 110 of 448
```
GSINIDPatURIMain =
```
PaddedNumericComponent "." PaddedNumericComponent
/ PaddedNumericComponent ".*"
/ "*.*"
```
ITIPIDPatURIBody = %s"itip:" ITIPPatURIMain
```
```
ITIPPatURIMain =
```
```
4(PaddedNumericComponent ".") GS3A3Component
```
```
/ 4(PaddedNumericComponent ".") "*"
```
```
/ 2(PaddedNumericComponent ".") "*.*.*"
```
/ PaddedNumericComponent ".*.*.*.*"
/ "*.*.*.*.*"
```
UPUIIDPatURIBody = %s"upui:" UPUIPatURIMain
```
```
UPUIPatURIMain =
```
```
2(PaddedNumericComponent ".") GS3A3Component
```
```
/ 2(PaddedNumericComponent ".") "*"
```
/ PaddedNumericComponent ".*.*"
/ "*.*.*"
```
PGLNIDPatURIBody = %s"pgln:" PGLNPatURIMain
```
```
PGLNPatURIMain =
```
```
2(PaddedNumericComponent ".")
```
/ PaddedNumericComponent ".*"
/ "*.*"
```
DODIDPatURIBody = %s"usdod:" DODIDPatMain
```
```
DODIDPatMain =
```
CAGECodeOrDODAAC "." DoDSerialNumber
/ CAGECodeOrDODAAC ".*"
/ "*.*"
```
ADIIDPatURIBody = %s"adi:" ADIIDPatMain
```
```
ADIIDPatMain =
```
CAGECodeOrDODAAC "." ADIComponent "." ADIExtendedComponent
/ CAGECodeOrDODAAC "." ADIComponent ".*"
/ CAGECodeOrDODAAC ".*.*"
/ "*.*.*"
```
BICIDPatURIBody = %s"bic:" BICIDPatMain
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 111 of 448
```
BICIDPatMain = BICURIBody / "*"
```
```
IMOVNIDPatURIBody = %s"imovn:" IMOVNPatMain
```
```
IMOVNPatMain = VesselNumber / "*"
```
8.2 Semantics
```
The meaning of a Pure Identity Pattern URI (urn:epc:idpat:) is formally defined as denoting a set of a set of pure identity EPCs,
```
respectively.
The set of EPCs denoted by a specific Pure Identity Pattern URI is defined by the following decision procedure, which says whether a given
Pure Identity EPC URI belongs to the set denoted by the Pure Identity Pattern URI.
Let urn:epc:idpat:Scheme:P1.P2...Pn be a Pure Identity Pattern URI. Let urn:epc:id:Scheme:C1.C2...Cn be a Pure Identity
```
EPC URI, where the Scheme field of both URIs is the same. The number of components (n) depends on the value of Scheme.
```
First, any Pure Identity EPC URI component Ci is said to match the corresponding Pure Identity Pattern URI component Pi if:
```
■ Pi is a NumericComponent, and Ci is equal to Pi; or
```
```
■ Pi is a PaddedNumericComponent, and Ci is equal to Pi both in numeric value as well as in length; or
```
```
■ Pi is a GS3A3Component, ADIExtendedComponent, ADIComponent, or CPRefComponent and Ci is equal to Pi, character for character;
```
or
```
■ Pi is a CAGECodeOrDODAAC, and Ci is equal to Pi; or
```
```
■ Pi is a StarComponent (and Ci is anything at all)
```
Then the Pure Identity EPC URI is a member of the set denoted by the Pure Identity Pattern URI if and only if Ci matches Pi for all 1 ≤ i
≤ n.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 112 of 448
9 Memory Organisation of Gen 2 RFID tags
9.1 Types of Tag Data
RFID Tags, particularly Gen 2 RFID tags, may carry data of three different kinds:
■ Business Data: Information that describes the physical object to which the tag is affixed. This information includes the EPC that uniquely
identifies the physical object, and may also include other data elements carried on the tag. This information is what business applications act
upon, and so this data is commonly transferred between the data capture level and the business application level in a typical implementation
architecture. Most standardised business data on an RFID tag is equivalent to business data that may be found in other data carriers, such as
```
barcodes. Business data can also include sensor data (e.g., as encoded in the XPC bits).
```
■ Control Information: Information that is used by data capture applications to help control the process of interacting with tags. Control
Information includes data that helps a capturing application filter out tags from large populations to increase read efficiency, special handling
information that affects the behaviour of capturing application, information that controls tag security features, and so on. Control Information is
typically not passed directly to business applications, though Control Information may influence how a capturing application presents business
data to the business application level. Unlike Business Data, Control Information has no equivalent in barcodes or other data carriers.
■ Tag Manufacture Information: Information that describes the Tag itself, as opposed to the physical object to which the tag is affixed. Tag
Manufacture information includes a manufacturer ID and a code that indicates the tag model. It may also include information that describes tag
capabilities, as well as a unique serial number assigned at manufacture time. Usually, Tag Manufacture Information is like Control Information in
that it is used by capture applications but not directly passed to business applications. In some applications, the unique serial number that may
be a part of Tag Manufacture Information is used in addition to the EPC, and so acts like Business Data. Like Control Information, Tag
Manufacture Information has no equivalent in barcodes or other data carriers.
It should be noted that these categories are slightly subjective, and the lines may be blurred in certain applications. However, they are
useful for understanding how TDS is structured, and are a good guide for their effective and correct use.
The following table summarises the information above.
Table 9-1 Kinds of Data on a Gen 2 RFID Tag
Information
type
Description Where on Gen 2 Tag Where typically used Bar Code
Equivalent
Business Data Describes the
physical object to
which the tag is
affixed.
```
EPC Bank (excluding PC
```
and XPC bits, and filter
```
value within EPC)
```
User Memory Bank
Data Capture layer and
Business Application layer
```
Yes: GS1 keys,
```
Application
```
Identifiers (AIs)
```
Control
Information
Facilitates
efficient tag
interaction
Reserved Bank
EPC Bank: PC and XPC
bits, and filter value
within EPC
Data Capture layer No
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 113 of 448
Information
type
Description Where on Gen 2 Tag Where typically used Bar Code
Equivalent
Tag
Manufacture
Information
Describes the tag
itself, as opposed
to the physical
object to which
the tag is affixed
TID Bank Data Capture layer
Unique tag manufacture
serial number may reach
Business Application layer
No
9.2 Gen 2 Tag Memory Map
```
Binary data structures defined in TDS are intended for use in RFID Tags, particularly in UHF Class 1 Gen 2 tags (also known as ISO/IEC
```
```
18000-63 [ISO18000-63] tags). The air interface standard [UHFC1G2] specifies the structure of memory on Gen 2 tags, as shown in Figure
```
9-1. Specifically, it specifies that memory in these tags consists of four separately addressable banks, numbered 00, 01, 10, and 11. It also
specifies the intended use of each bank, and constraints upon the content of each bank dictated by the behaviour of the air interface. For
```
example, the layout and meaning of the Reserved bank (bank 00), which contains passwords that govern certain air interface commands, is
```
fully specified in [UHFC1G2].
```
For those memory banks and memory locations that have no special meaning to the air interface (i.e., are "just data" as far as the air
```
```
interface is concerned), TDS normatively specifies the content and meaning of these memory locations.
```
Following the convention established in [UHFC1G2], memory addresses are described using hexadecimal bit addresses, where each bank
begins with bit 00 h and extends upward to as many bits as each bank contains, the capacity of each bank being constrained in some
respects by [UHFC1G2] but ultimately may vary with each tag make and model. Bit 00 h is considered the most significant bit of each bank,
and when binary fields are laid out into tag memory the most significant bit of any given field occupies the lowest-numbered bit address
occupied by that field.
```
NOTE: For reasons of TDS 1.x continuity, with respect to individual fields, the least significant bit of individual TDS 1.x fields is numbered
```
zero. For example, the TDS 1.x-era specification of Access Password is a 32-bit unsigned integer consisting of bits b31b30 …b0 , where b31 is
```
the most significant bit and b0 is the least significant bit. When the Access Password is stored at address 20 h – 3F h (inclusive) in the
```
Reserved bank of a Gen 2 tag, the most significant bit b31 is stored at tag address 20h and the least significant bit b0 is stored at address
3Fh.
```
NOTE: Encodings new to TDS 2.0 are described counting bits from left to right.
```
The following figure shows the layout of memory on a Gen 2 tag, The colours indicate the type of data following the categorisation in Figure
1.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 114 of 448
Figure 9-1 Gen 2 Tag Memory Map
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 115 of 448
The following table describes the fields in the memory map above.
Table 9-2 Gen 2 Memory Map
Bank Bits Field Description Category Where Specified
Bank 00
```
(Reserved)
```
00 h –
1Fh
Kill
Passwd
A 32-bit password that must be
presented to the tag in order to
complete the Gen 2 "kill" command.
Control
Info
[UHFC1G2]
20 h –
2Fh
Access
Passwd
A 32-bit password that must be
presented to the tag in order to
perform privileged operations
Control
Info
[UHFC1G2]
Bank 01
```
(EPC)
```
00 h –
0Fh
CRC A 16-bit Cyclic Redundancy Check
computed over the contents of the
EPC bank.
Control
Info
[UHFC1G2]
10 h –
1Fh
```
PC Bits Protocol Control bits (see below) Control
```
Info
```
(see below)
```
20 h –
end
EPC Electronic Product Code, plus filter
value and any optionally included
```
"AIDC data" (normatively specified in
```
```
TDS 2.0) appended to the EPC itself.
```
Note that the DSGTIN+ and
DSGTIN++ schemes support the
expression of a prioritised date field
ahead of the GTIN within their binary
encoding.
```
Note that all ‘++’ schemes (including
```
```
SGTIN++ and DSGTIN++) support
```
the expression of a custom domain
name or hostname after the serial
number within their binary encoding.
The EPC is then zero-filled to the
word boundary.
The Electronic Product code is a
globally unique identifier for the
physical object to which the tag is
affixed. The filter value provides a
means to improve tag read efficiency
by selecting a subset of tags of
interest.
Business
Data
```
(except
```
filter value,
which is
Control
```
Info)
```
The EPC is
defined in
Sections 6, 7, and
13. The filter
values are
defined in
Section 10.
210 h –
21Fh
XPC Bits Extended Protocol Control bits. If bit
16 h of the EPC bank is set to one,
```
then bits 210 h – 21Fh (inclusive)
```
contain additional protocol control
bits as specified in [UHFC1G2]
Control
Info
[UHFC1G2]
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 116 of 448
Bank Bits Field Description Category Where Specified
Bank 10
```
(TID)
```
00 h –
end
TID Bits Tag Identification bits, which provide
information about the tag itself, as
opposed to the physical object to
which the tag is affixed.
Tag Manu-
facture Info
Section 16
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 117 of 448
Bank Bits Field Description Category Where Specified
Bank 11
```
(User)
```
00 h –
end
DSFID Logically, the content of user memory
is a set of name-value pairs, where
the name part is an OID [ASN.1] and
the value is a character string.
Physically, the first few bits are a
Data Storage Format Identifier as
specified in ISO/IEC 15961
[ISO15961] and ISO/IEC 15962
[ISO15962]. The DSFID specifies the
format for the remainder of the user
memory bank. The DSFID is typically
eight bits in length, but may be
extended further as specified in
[ISO15961].
When the DSFID specifies Access
Method 2, the format of the
remainder of user memory is "Packed
Objects" as specified in Section 17.
This format is recommended for use
in EPC applications. The physical
encoding in the Packed Objects data
format is as a sequence of "Packed
Objects," where each Packed Object
includes one or more name-value
pairs whose values are compacted
together.
When the DSFID specifies Access
Method 17, the format of the
remainder of user memory after the
```
8-bit DSFID (set to 00010001) is an
```
ISO/IEC 20248 DigSig
```
(digital signature data structure)
```
consisting of:
```
Domain Authority ID (DAID) = 8 bits
```
```
(set to 11111110) +44 bits to encode
```
```
the GS1 Party GLN (417) of the
```
organisation that is accountable for
the signature,
```
Certificate ID (CID) = 16 bits,
```
Signature and timestamp = 256+20
bits. A 20 bit timestamp supports a
signing period of one year, with a
resolution of minutes.
Business
Data
[ISO15961],
[ISO15962],
Section 17
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 118 of 448
```
The following figure illustrates in greater detail the first few bits of the EPC Bank (Bank 01), and in particular shows the various fields within
```
```
the Protocol Control bits (bits 10 h – 1F h, inclusive).
```
```
Figure 9-2 Gen 2 Protocol Control (PC) Bits Memory Map
```
XPC Indicator
```
(XI)
```
CRC
000F101415 16 17181Fh
h h hh h h hhh
Length Attribute/ AFI
EPC
Binary
Encoding
[+AIDC data ]
Zero Fill
to the
word
boundary
20
Toggle - always zero for EPC
```
Protocol Control (PC) bits
```
NSI
```
User Memory Indicator (UMI) in Gen2v2 tags and earlier
```
```
Read User Memory Indicator (RUM) in Gen2v3 and later
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 119 of 448
9.3 PC bits
The following table specifies the meaning of the PC bits:
```
Table 9-3 Gen 2 Protocol Control (PC) Bits Memory Map
```
Bits Field Name Description
```
10 h – 14 h L4-L0 Length Represents the number of 16-bit words comprising the EPC field (below), beginning with
```
the 8-bit, EPC Binary Header at 20h and including any optional "AIDC data"
```
(normatively specified in TDS 2.0) appended to the EPC itself.
```
For this reason, the EPC and any optional "AIDC data" appended to the EPC itself
have a practical upper limit of 464 bits on tags which support XPC_W1, or 496 bits
on tags which do not support XPC_W1.
Note that the DSGTIN+ scheme enables a prioritised date value to be encoded before
the GTIN in the binary encoding.
```
Note that the ‘++’ EPC schemes (including SGTIN++ and DSGTIN++) enable a custom
```
domain name or hostname to be encoded after the serial number in the binary
encoding.
See Section 15.1.1 regarding the encoding of this field.
15 h UMI
```
(Gen2v2 tags
```
```
and earlier)
```
```
User Memory Indicator (for Gen2v2 tags and earlier)
```
Bit 15h may be fixed by the Tag manufacturer or computed by the Tag.
If UMI=0:
```
If fixed, the Tag does not have File_0 (User Memory) and is incapable of allocating
```
memory to it.
```
If computed, then File_0 (User Memory) is not allocated or does not contain data.
```
If UMI=1:
```
If fixed, the Tag has File 0 (User Memory) or is capable of allocating memory to it.
```
```
If computed, then File_0 (User Memory) is allocated and contains data.
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 120 of 448
Bits Field Name Description
RUM
```
(Gen2v3 tags
```
```
and later)
```
```
Read User Memory indicator (for Gen2v3 tags and later)
```
Bit 15 h indicates that a Tag has memory allocated to File_0 and, if the Interrogator
initiated the inventory round using a QueryX, that the Tag has encoded data in File_0. A
Tag shall compute RUM according to Table 6-17 of [UHFC1G2] regardless of the lock or
permalock status of EPC memory or the untraceability status of File_0.
```
If an Interrogator changes a Tag’s User Word Count (UWC) value (see [UHFC1G2]) or
```
changes the number of words allocated to File_0 memory, then a Tag’s RUM may be
incorrect until the Interrogator power-cycles the Tag. Additionally, RUM may change
```
without power cycling; for example, a Tag with memory allocated to File_0 and with
```
```
UWC=0 will have RUM=0 2 after QueryX begins initializing an inventory round, but after
```
a Write to the StoredPC, then RUM may change since the Tag may recompute its
StoredCRC.
16 h XI XPC W1 Indicator Indicates whether an XPC W1 is present for the specific circumstances described below.
If XI=0:
```
Either (i) Tag has no XPC_W1, or (ii) T=0 and either bits 210h–217h or bits 210h–218h
```
```
(at tag manufacturer's option) of EPC memory are all zero, or (iii) T=1 and bits 210h–
```
21Fh of EPC memory are all zero.
If XI=1:
```
Tag has an XPC_W1 and either (i) T=0 and at least one bit of 210h–217h or 210h–218h
```
```
(at tag manufacturer’s option) of EPC memory is nonzero, or (ii) T=1 and at least one
```
bit of 210h–21Fh of EPC memory is nonzero.
17 h T Numbering System Identifier
Toggle
If T=0:
Indicates a GS1 EPCglobal application, encoded in compliance with TDS.
If T=1:
Indicates a non-GS1 EPCglobal application, not encoded in compliance with TDS.
In particular, indicates that bits 18 h – 1Fh contain the ISO Application Family Identifier
```
(AFI) as defined in [ISO15961] and the remainder of the EPC bank contains a Unique
```
```
Item Identifier (UII) appropriate for that AFI.
```
```
18 h – 1Fh(if toggle=0)RFU (Gen2v2, Gen2v3 tags) or
```
```
Attribute bits (Gen v1.x tags)
```
Gen2 v1.x tags:
Bits that may guide the handling of the physical object to which the tag is affixed.
```
18 h – 1Fh(if toggle=1)AFI Application Family Identifier An Application Family Identifier that specifies a non-GS1 EPCglobal application, not
```
encoded in compliance with TDS, for which the remainder of the EPC bank contains a
```
Unique Item Identifier (UII) appropriate for that AFI.
```
```
(see [ISO15961])
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 121 of 448
```
Bits 17h – 1F h (inclusive) are collectively known as the Numbering System Identifier (NSI). It should be noted, however, that when the
```
```
toggle bit (bit 17h) is zero, the numbering system is always the Electronic Product Code (EPC), and bits 18 h – 1Fh contain the Attribute bits
```
whose purpose is completely unrelated to identifying the numbering system being used.
The Attribute bits are "control information" that may be used by capturing applications to guide the capture process. Attribute Bits may be
used to determine whether the physical object to which a tag is affixed requires special handling of any kind.
Attribute bits are available for all EPC types. The Attribute bit definitions specified here apply regardless of which EPC scheme is used.
Because Attribute bits are not part of the EPC, they are not included when the EPC is represented as a pure identity URI or as a GS1
Digital Link URI, nor should the Attribute bits be considered as part of the EPC by business applications. Capturing applications may,
however, read the Attribute bits and pass them upwards to business applications in some data field other than the EPC. It should be
recognised, however, that the purpose of the Attribute bits is to assist in the data capture and physical handling process, and in most cases
the Attribute bits will be of limited or no value to business applications. The Attribute bits are not intended to provide reliable master data or
product descriptive attributes for business applications to use.
9.4 XPC bits
```
The following table specifies the meaning of the XPC bits for tags whose Numbering System Identifier Toggle (T, bit 17h) is zero.
```
For tags whose Numbering System Identifier Toggle is non-zero, please refer to [ISO18000-63] for XPC bit assignments.
```
Table 9-4 Gen 2 Extended Protocol Control (XPC) Bits Memory Map
```
Bits Field Description Settings
210 h XEB XPC_W2 indicator 0: Tag has no XPC_W2 or all bits of XPC_W2 are zero-valued
1: Tag has an XPC_W2 and at least one bit of XPC_W2 is nonzero
211 h –
213 h
```
RFU Reserved for future use Annex L of Gen2 v2 permits using the ISO XPC bit definitions; accordingly, bits 211 h -217 h
```
might not be fixed zeroes. Specifically, bits 214 h to 217 h are used by sensor tags
214 h –
217 h
RFU
```
(Gen2v2 tagsand earlier)
```
214 h SA
```
(Gen2v3 tagsand later)
```
Sensor Alarm indicator 0: Tag is not reporting an alarm condition or does not support the SA flag
1: Tag is reporting an alarm condition
215 h SS
```
(Gen2v3 tagsand later)
```
Simple Sensor indicator 0: Tag does not have a Simple Sensor
1: Tag has a Simple Sensor
216 h FS
```
(Gen2v3 tagsand later)
```
Full Function Sensor indicator 0: Tag does not have a Full Function Sensor
1: Tag has a Full Function Sensor
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 122 of 448
Bits Field Description Settings
217 h SN
```
(Gen2v3 tagsand later)
```
Snapshot Sensor indicator 0: Tag does not have a Snapshot Sensor
1: Tag has a Snapshot Sensor
218 h B Battery-assisted passive
indicator
0: Tag is passive or does not support the B flag
1: Tag is battery-assisted
219 h C Computed response indicator 0: ResponseBuffer is empty or Tag does not support a ResponseBuffer
1: ResponseBuffer contains a response
21A h SLI SL indicator 0: Tag has a deasserted SL flag or does not support the SLI bit
1: Tag has an asserted SL flag
21Bh TN Tag Notification indicator 0: Tag does not assert a notification or does not support the TN bit
1: Tag asserts a notification
21C h U Untraceable indicator 0: Tag is traceable or does not support the U bit
1: Tag is untraceable
21D h K Killable indicator 0: Tag is not killable by Kill command or does not support the K bit
1: Tag can be killed by Kill command.
21Eh NR Non-Removable indicator 0: Tag is removable from its host item or does not support the NR bit
1: Tag is not removable from its host item
21Fh H Hazmat indicator 0: Tagged item is not hazardous material or Tag does not support the H bit
1: Tagged item is hazardous material
Hazardous materials are defined by government regulations. Generally, a hazardous material
```
(HazMat) is any item or agent (biological, chemical, radiological, and/or physical), which has
```
the potential to cause harm to humans, animals, or the environment, either by itself or
through interaction with other factors.
```
NOTE:
```
```
Per section 6.3.2.1.2.2 Protocol-control (PC) word (StoredPC and PacketPC) of Gen2v2:
```
```
"If a Tag has T=0, XI=0, implements an XPC_W1, and is not truncating then the Tag substitutes the 8 LSBs of XPC_W1 (i.e.
```
```
EPC memory 218h – 21Fh) for the 8 LSBs of the StoredPC (i.e. PC memory 18h – 1Fh) in its reply."
```
ALSO NOTE:
Gen2 Inventory operations do not use the READ, WRITE, or BLOCKWRITE commands for obtaining the contents of the EPC memory bank.
Instead, Gen2 Inventory operations use the ACK command, and the host will only receive the PacketPC, which combines info from both the
StoredPC and XPC_W1. The ACK command may also include the XPC_W1 in its entirety for a sensor tag.
```
Capture of the EPC memory bank (MB01) is a process that is optimized by the air protocol. As such, what is commonly referred to as the
```
```
"PC word" during capture is really the 8 most significant bits (MSBs) of the Protocol Control (PC) bits, concatenated with 8 least significant
```
```
bits (LSBs) of the Extended Protocol Control (XPC) bits when XI=0; when XI=1, the "PC word" during capture consists of all 16 PC bits,
```
along with all 16 XPC bits.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 123 of 448
10 Filter Value
The filter value is additional control information that may be included in the EPC memory bank of a Gen 2 tag. The intended use of the filter
value is to allow an RFID reader to select or deselect the tags corresponding to certain physical objects, to make it easier to read the
desired tags in an environment where there may be other tags present in the environment. For example, if the goal is to read the single tag
on a pallet, and it is expected that there may be hundreds or thousands of item-level tags present, the performance of the capturing
application may be improved by using the Gen 2 air interface to select the pallet tag and deselect the item-level tags.
```
Filter values are available for all EPC types except for the General Identifier (GID). There is a different set of standardised filter value values
```
associated with each type of EPC, as specified below.
It is essential to understand that the filter value is additional "control information" that is not part of the Electronic Product Code. The filter
value does not contribute to the unique identity of the EPC. For example, it is not permissible to attach two RFID tags to different physical
objects where both tags contain the same EPC, even if the filter values are different on the two tags.
Because the filter value is not part of the EPC, the filter value is not included when the EPC is represented as a pure identity URI, element
string or GS1 Digital Link URI, nor should the filter value be considered as part of the EPC by business applications. It is also important to
note that filter values can only be used within EPC RFID data carriers and there is no barcode equivalent. Nor should filter values be
confused with the indicator digit of a GTIN nor the extension digit of an SSCC.
Capturing applications may, however, read the filter value and pass it upwards to business applications in some data field other than the
EPC. It should be recognised, however, that the purpose of the filter values is to assist in the data capture process, and in most cases the
filter value will be of limited or no value to business applications. The filter value is not intended to provide a reliable packaging-level
indicator for business applications to use.
10.1 Use of "Reserved" and "All Others" Filter Values
In the following sections, filter values marked as "reserved" are reserved for assignment by GS1 in future versions of this specification.
Implementations of the encoding and decoding rules specified herein SHALL accept any value of the filter values, whether reserved or not.
Applications, however, SHOULD NOT direct an encoder to write a reserved value to a tag, nor rely upon a reserved value decoded from a
tag, as doing so may cause interoperability problems if a reserved value is assigned in a future revision to this specification.
Each EPC scheme includes a filter value identified as "All Others." This filter value means that the object to which the tag is affixed does not
match the description of any of the other filter values defined for that EPC scheme. In some cases, the "All Others" filter value may appear
on a tag that was encoded to conform to an earlier version of this specification, at which time no other suitable filter value was available.
When encoding a new tag, the filter value should be set to match the description of the object to which the tag is affixed, with "All Others"
being used only if a suitable filter value for the object is not defined in this specification.
10.2 Filter Values for SGTIN and DSGTIN+ / DSGTIN++ EPC Tags
The normative specifications for Filter Values for SGTIN EPC Tags are specified below.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 124 of 448
Table 10-1 SGTIN Filter Values
Type Filter Value Binary Value
```
All Others (see Section 10.1) 0 000
```
```
Point of Sale (POS) Trade Item 1 001
```
Full Case for Transport * 2 010
```
Reserved (see Section 10.1) 3 011
```
Inner Pack Trade Item Grouping for Handling 4 100
```
Reserved (see Section 10.1) 5 101
```
Unit Load ** 6 110
Unit inside Trade Item or component inside a product not
intended for individual sale
7 111
- When used as the EPC Filter Value for an SGTIN, "Full Case for Transport" denotes a case or carton whose composition of multiple POS
```
trade items is standardised via master data and can be consistently (re-) ordered in this configuration by referencing a single GTIN.
```
** When used as the EPC Filter Value for an SGTIN, "Unit Load" denotes one or more trade items contained on a pallet or other type of
```
load carrier (e.g. rolly, dolly, tote, garment rack, bag, sack, etc.) *, making them suitable for transport, stacking, and storage as a unit,
```
```
whose composition is standardised via master data and can be consistently (re-)ordered in this configuration by referencing a single GTIN.
```
10.3 Filter Values for SSCC EPC Tags
The normative specifications for Filter Values for SSCC EPC Tags are specified below.
Table 10-2 SSCC Filter Values
Type Filter Value Binary Value
```
All Others (see Section 10.1) 0 000
```
```
Reserved (see Section 10.1) 1 001
```
Full Case for Transport 2 010
```
Reserved (see Section 10.1) 3 011
```
```
Reserved (see Section 10.1) 4 100
```
```
Reserved (see Section 10.1) 5 101
```
Unit Load 6 110
```
Reserved (see Section 10.1) 7 111
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 125 of 448
10.4 Filter Values for SGLN EPC Tags
Table 10-3 SGLN Filter Values
Type Filter Value Binary Value
```
All Others (see Section 10.1) 0 000
```
```
Reserved (see Section 10.1) 1 001
```
```
Reserved (see Section 10.1) 2 010
```
```
Reserved (see Section 10.1) 3 011
```
```
Reserved (see Section 10.1) 4 100
```
```
Reserved (see Section 10.1) 5 101
```
```
Reserved (see Section 10.1) 6 110
```
```
Reserved (see Section 10.1) 7 111
```
10.5 Filter Values for GRAI EPC Tags
Table 10-4 GRAI Filter Values
Type Filter Value Binary Value
```
All Others (see Section 10.1) 0 000
```
```
Reserved (see Section 10.1) 1 001
```
```
Reserved (see Section 10.1) 2 010
```
```
Reserved (see Section 10.1) 3 011
```
```
Reserved (see Section 10.1) 4 100
```
```
Reserved (see Section 10.1) 5 101
```
```
Reserved (see Section 10.1) 6 110
```
```
Reserved (see Section 10.1) 7 111
```
10.6 Filter Values for GIAI EPC Tags
Table 10-5 GIAI Filter Values
Type Filter Value Binary Value
```
All Others (see Section 10.1) 0 000
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 126 of 448
Type Filter Value Binary Value
Rail Vehicle 1 001
```
Reserved (see Section 10.1) 2 010
```
```
Reserved (see Section 10.1) 3 011
```
```
Reserved (see Section 10.1) 4 100
```
```
Reserved (see Section 10.1) 5 101
```
```
Reserved (see Section 10.1) 6 110
```
```
Reserved (see Section 10.1) 7 111
```
10.7 Filter Values for GSRN and GSRNP EPC Tags
Table 10-6 GSRN and GSRNP Filter Values
Type Filter Value Binary Value
```
All Others (see Section 10.1) 0 000
```
```
Reserved (see Section 10.1) 1 001
```
```
Reserved (see Section 10.1) 2 010
```
```
Reserved (see Section 10.1) 3 011
```
```
Reserved (see Section 10.1) 4 100
```
```
Reserved (see Section 10.1) 5 101
```
```
Reserved (see Section 10.1) 6 110
```
```
Reserved (see Section 10.1) 7 111
```
10.8 Filter Values for GDTI EPC Tags
Table 10-7 GDTI Filter Values
Type Filter Value Binary Value
```
All Others (see Section 10.1) 0 000
```
Travel Document * 1 001
```
Reserved (see Section 10.1) 2 010
```
```
Reserved (see Section 10.1) 3 011
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 127 of 448
Type Filter Value Binary Value
```
Reserved (see Section 10.1) 4 100
```
```
Reserved (see Section 10.1) 5 101
```
```
Reserved (see Section 10.1) 6 110
```
```
Reserved (see Section 10.1) 7 111
```
- A Travel Document is an identity document issued by a government or international treaty organisation to facilitate the movement of
individuals across international boundaries.
10.9 Filter Values for CPI EPC Tags
Table 10-8 CPI Filter Values
Type Filter Value Binary Value
```
All Others (see Section 10.1) 0 000
```
```
Reserved (see Section 10.1) 1 001
```
```
Reserved (see Section 10.1) 2 010
```
```
Reserved (see Section 10.1) 3 011
```
```
Reserved (see Section 10.1) 4 100
```
```
Reserved (see Section 10.1) 5 101
```
```
Reserved (see Section 10.1) 6 110
```
```
Reserved (see Section 10.1) 7 111
```
10.10 Filter Values for SGCN EPC Tags
Table 10-9 SGCN Filter Values
Type Filter Value Binary Value
```
All Others (see Section 10.1) 0 000
```
```
Reserved (see Section 10.1) 1 001
```
```
Reserved (see Section 10.1) 2 010
```
```
Reserved (see Section 10.1) 3 011
```
```
Reserved (see Section 10.1) 4 100
```
```
Reserved (see Section 10.1) 5 101
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 128 of 448
Type Filter Value Binary Value
```
Reserved (see Section 10.1) 6 110
```
```
Reserved (see Section 10.1) 7 111
```
10.11 Filter Values for ITIP EPC Tags
Table 10-10 ITIP Filter Values
Type Filter Value Binary Value
```
All Others (see Section 10.1) 0 000
```
```
Reserved (see Section 10.1) 1 001
```
```
Reserved (see Section 10.1) 2 010
```
```
Reserved (see Section 10.1) 3 011
```
```
Reserved (see Section 10.1) 4 100
```
```
Reserved (see Section 10.1) 5 101
```
```
Reserved (see Section 10.1) 6 110
```
```
Reserved (see Section 10.1) 7 111
```
10.12 Filter Values for GID EPC Tags
The GID EPC scheme does not provide for the use of filter values.
10.13 Filter Values for DOD EPC Tags
Filter values for US DoD EPC Tags are as specified in [USDOD].
10.14 Filter Values for ADI EPC Tags
Table 10-11 ADI Filter Values
Type Filter Value Binary Value
```
All Others (see Section 10.1) 0 000000
```
Item, other than an item to which filter values 8 through 63
apply
1 000001
Carton 2 000010
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 129 of 448
Type Filter Value Binary Value
```
Reserved (see Section 10.1) 3 thru 5 000011 thru 000101
```
Pallet 6 000110
```
Reserved (see Section 10.1) 7 000111
```
Seat cushions 8 001000
Seat covers 9 001001
Seat belts 10 001010
Galley, Galley carts and other Galley Service Equipment 11 001011
Unit Load Devices, cargo containers 12 001100
```
Aircraft Security items (life vest boxes, rear lavatory walls,
```
```
lavatory ceiling access hatches)
```
13 001101
Life vests 14 001110
Oxygen generators 15 001111
Engine components 16 010000
Avionics 17 010001
```
Experimental ("flight test") equipment 18 010010
```
```
Other emergency equipment (smoke masks, PBE, crash axes,
```
```
medical kits, smoke detectors, flashlights, safety cards, etc.)
```
19 010011
```
Other rotables; e.g., line or base replaceable 20 010100
```
Other repairable 21 010101
Other cabin interior 22 010110
```
Other repair (exclude component); e.g., structure item repair 23 010111
```
```
Passenger Seats (structure) 24 011000
```
```
IFEs (In-Flight Entertainment) Systems 25 011001
```
```
Reserved (see Section 10.1) 26 thru 55 011010 thru 110111
```
```
Location Identifier (*) 56 111000
```
Documentation 57 111001
Tools 58 111010
Ground Support Equipment 59 111011
Other Non-flyable equipment 60 111100
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 130 of 448
Type Filter Value Binary Value
Reserved for internal company use 61 thru 63 111101 thru 111111
Non-Normative: When assigning filter values to tagged parts, the filter values chosen should be as specific as possible. For
```
example, a filter value of 17 (Avionics) is a better choice for a radar black box than the more general category of 20 (Other Rotables).
```
```
On the other hand, a filter value of 20 (Other Rotables) would be appropriate for a radar antenna in the nose cone of a plane since 17
```
```
(Avionics) would not be accurate.
```
```
Note: location identifier may act differently from an item "identifying" tag in that it identifies a location that may be
```
referenced by other items. Thus, an item might have an identification tag, but also a location tag. An example might be a particular
part of an aircraft or even the entire aircraft.
Non-Normative: One example of "location" could be a particular airplane "tail number". For example, Airline XYZ has a fleet
of 200 737s with the same interior configuration, and once you are inside of it, you can’t tell which particular 737 you are in. This
```
Airline wants to place RFID "location marker(s)" with the tail number encoded, and place them inside the passenger doors, or cargo
```
hold doors. The doors could end up having two tags, one is for the door itself, i.e. it has the door part number, serial number, and
things, and another tag is for "location" purpose.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 131 of 448
```
11 Attribute bits (refer to 9.3 and 9.4)
```
This contents of this section have now been subsumed into sections 9.3 and 9.4.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 132 of 448
12 EPC Tag URI and EPC Raw URI
The EPC memory bank of a Gen 2 tag contains a binary-encoded EPC, along with other control information. Applications do not normally
process binary data directly. An application wishing to read the EPC may receive the EPC as a Pure Identity EPC URI, as defined in
Section 6. In other situations, however, a capturing application may be interested in the control information on the tag as well as the EPC.
Also, an application that writes the EPC memory bank needs to specify the values for control information that are written along with the
EPC. In both of these situations, the EPC Tag URI and EPC Raw URI may be used.
For EPC schemes defined in TDS before TDS v2.0, the EPC Tag URI specifies both the EPC and the values of control information in the EPC
```
memory bank. It also specifies which of several variant binary coding schemes is to be used (e.g., the choice between SGTIN-96 and
```
```
SGTIN-198). As such, an EPC Tag URI completely and uniquely specifies the contents of the EPC memory bank for those EPC schemes for
```
which it is defined. The EPC Raw URI also specifies the complete contents of the EPC memory bank, but represents the memory contents as
```
a single decimal or hexadecimal numeral. The new EPC schemes defined in TDS v2.0 have not defined an equivalent EPC Tag URI syntax;
```
instead the encoding/decoding is between the binary string and the corresponding GS1 element string, GS1 Digital Link URI or equivalently,
the set of GS1 Application Identifiers and their values, as shown in Figure 1. It should also be noted that the new EPC schemes defined in
TDS 2.0 all permit the encoding of additional AIDC data after the EPC within the EPC/UII memory bank, as an alternative to encoding such
data in the user memory bank.
12.1 Structure of the EPC Tag URI and EPC Raw URI
The EPC Tag URI begins with urn:epc:tag:, and is used when the EPC memory bank contains a valid EPC. EPC Tag URIs resemble Pure
Identity EPC URIs, but with added control information. The EPC Raw URI begins with urn:epc:raw:, and is used when the EPC memory
```
bank does not contain a valid EPC. This includes situations where the toggle bit (bit 17 h) is set to one, as well as situations where the toggle
```
bit is set to zero but the remainder of the EPC bank does not conform to the coding rules specified in Section 14, either because the header
bits are unassigned or the remainder of the binary encoding violates a validity check for that header.
The following figure illustrates these URI forms.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 133 of 448
Figure 12-1 Illustration of EPC Tag URI and EPC Raw URI
The first form in the figure, the EPC Tag URI, is used for a valid EPC. It resembles the Pure Identity EPC URI, with the addition of optional
```
control information fields as specified in Section 12.2.2 and a (non-optional) filter value. The EPC scheme name (sgtin-96 in the example
```
```
above) specifies a particular binary encoding scheme, and so it includes the length of the encoding. This is in contrast to the Pure Identity
```
```
EPC URI which identifies an EPC scheme but not a specific binary encoding (e.g., sgtin but not specifically sgtin-96).
```
```
The EPC raw URI illustrated by the second example in the figure can be used whenever the toggle bit (bit 17 h) is zero, but is typically only
```
```
used if the first form cannot (that is, if the contents of the EPC bank cannot be decoded according to Section 14.3.9). It specifies the
```
contents of bit 20h onward as a single hexadecimal numeral. The number of bits in this numeral is determined by the "length" field in the
```
EPC bank of the tag (bits 10h – 14h ). (The grammar in Section 12.4 includes a variant of this form in which the contents are specified as a
```
```
decimal numeral. This form is deprecated.)
```
```
urn:epc:tag:[att=x01][xpc=x0004]:sgtin-96:3.9521141.012345.4711
```
```
urn:epc:raw:[att=x01][xpc=x0004]:96.x0123456890ABCDEF01234567
```
```
urn:epc:raw:[umi=1][xpc=x0004]:64.x31.x0123456890ABCDEF
```
EPC Tag URI
EPC Raw URI, toggle=0
EPC Raw URI, toggle=1
Control fields
```
(optional)
```
Filter value
Application Family
```
Identifier (AFI)
```
EPC Encoding Scheme
```
Name (includes
```
```
length)
```
Explicit
Length
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 134 of 448
```
The EPC Raw URI illustrated by the third example in the figure is used when the toggle bit (bit 17 h) is one. It is similar to the second form,
```
```
but with an additional field between the length and payload that reports the value of the AFI field (bits 18 h – 1Fh) as a hexadecimal
```
numeral.
Each of these forms is fully defined by the encoding and decoding procedures specified in Sections 14.3 and 14.4.
12.2 Control Information
The EPC Tag URI and EPC Raw URI specify the complete contents of the Gen 2 EPC memory bank, including control information such as
filter values and Attribute bits. This section specifies how control information is included in these URIs.
12.2.1 Filter Values
Filter values are only available when the EPC bank contains a valid EPC, and only then when the EPC is an EPC scheme other than GID. In
the EPC Tag URI, the filter value is indicated as an additional field following the scheme name and preceding the remainder of the EPC, as
illustrated below:
Figure 12-2 Illustration of Filter Value within EPC Tag URI
The filter value is a decimal integer. The allowed values of the filter value are specified in Section 10.
12.2.2 Other control information fields
Control information in the EPC bank apart from the filter values is stored separately from the EPC. Such information can be represented
both in the EPC Tag URI and the EPC Raw URI, using the name-value pair syntax described below.
In both URI forms, control field name-value pairs may occur following the urn:epc:tag: or urn:epc:raw:, as illustrated below:
```
urn:epc:tag:[att=x01][xpc=x0004]:sgtin-96:3.9521141.112345.400
```
```
urn:epc:raw:[att=x01][xpc=x0004]:96.x012345689ABCDEF01234567
```
```
urn:epc:id:sgtin:9521141.012345.4711EPC Pure Identity URI
```
```
urn:epc:tag:sgtin-96:3.9521141.012345.4711EPC Tag URI
```
Filter value
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 135 of 448
Each element in square brackets specifies the value of one control information field. An omitted field is equivalent to specifying a value of
zero. As a limiting case, if no control information fields are specified in the URI it is equivalent to specifying a value of zero for all fields. This
provides back-compatibility with earlier versions of TDS.
The available control information fields are specified in the following table.
Table 12-1 Control information fields
Field Syntax Description Read/Write
```
Attribute Bits [att=xNN] The value of the Attribute bits (bits 18 h –
```
```
1Fh ), as a two-digit hexadecimal numeral
```
NN.
This field is only available if the toggle bit
```
(bit 17 h ) is zero.
```
Read / Write
User Memory
Indicator
[umi=B] The value of the user memory indicator bit
```
(bit 15 h ). The value B is either the digit 0 or
```
the digit 1.
Read / Write
Note that certain Gen 2 Tags may ignore the value written to
this bit, and some may calculate the value of the bit from the
contents of user memory. See [UHFC1G2].
```
Extended PC Bits [xpc=xNNNN] The value of the XPC bits (bits 210 h -21Fh ) as
```
a four-digit hexadecimal numeral NNNN.
Read only
The user memory indicator and extended PC bits are calculated by the tag as a function of other information on the tag or based on
operations performed to the tag. Therefore, these fields cannot be written directly. When reading from a tag, any of the control information
fields may appear in the URI that results from decoding the EPC memory bank. When writing a tag, the umi and xpc fields will be ignored
when encoding the URI into the tag.
```
To aid in decoding, any control information fields that appear in a URI must occur in alphabetical order (the same order as in the table
```
```
above).
```
Non-Normative: Examples: The following examples illustrate the use of control information fields in the EPC Tag URI and
EPC Raw URI.
```
urn:epc:tag:sgtin-96:3.9521141.112345.400
```
```
This is a tag with an SGTIN EPC, filter bits = 3, the hazardous material Attribute bit set to zero, no user memory (user memory
```
```
indicator = 0), and not recommissioned (extended PC = 0). This illustrates back-compatibility with earlier versions of the Tag Data
```
Standard.
```
This is a tag with an SGTIN EPC, filter bits = 3, the hazardous material Attribute bit set to one, no user memory (user memory
```
```
indicator = 0), and not recommissioned (extended PC = 0). This URI might be specified by an application wishing to commission a tag
```
with the hazardous material bit set to one and the filter bits and EPC as shown.
```
urn:epc:raw:[att=x01][umi=1][xpc=x0004]:96.x1234567890ABCDEF01234567
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 136 of 448
```
This is a tag with toggle=0, random data in bits 20 h onward (not decodable as an EPC), the hazardous material Attribute bit set to
```
```
one, non-zero contents in user memory, and has been recommissioned (as indicated by the extended PC).
```
```
urn:epc:raw:[xpc=x0001]:96.xC1.x1234567890ABCDEF01234567
```
```
This is a tag with toggle=1, Application Family Indicator = C1 (hexadecimal), and has had its user memory killed (as indicated by the
```
```
extended PC).
```
12.3 EPC Tag URI and EPC Pure Identity URI
The Pure Identity EPC URI as defined in Section 6 is a representation of an EPC for use in information systems. The only information in a
Pure Identity EPC URI is the EPC itself. The EPC Tag URI, in contrast, contains additional information: it specifies the contents of all control
information fields in the EPC memory bank, and it also specifies which encoding scheme is used to encode the EPC into binary. Therefore, to
convert a Pure Identity EPC URI to an EPC Tag URI, additional information must be provided. Conversely, to extract a Pure Identity EPC URI
from an EPC Tag URI, this additional information is removed. The procedures in this section specify how these conversions are done.
12.3.1 EPC Binary Coding Schemes
For each EPC scheme as specified in Section 6, there are one or more corresponding EPC Binary Coding Schemes that determine how the
EPC is encoded into binary representation for use in RFID tags. When there is more than one EPC Binary Coding Scheme available for a
given EPC scheme, a user must choose which binary coding scheme to use. In general, the shorter binary coding schemes result in fewer
bits and therefore permit the use of less expensive RFID tags containing less memory, but are restricted in the range of serial numbers that
are permitted. The longer binary coding schemes allow for the full range of serial numbers permitted by the GS1 General Specifications, but
require more bits and therefore more expensive RFID tags. TDS 2.0 introduces several new EPC schemes and corresponding binary
encodings that support simpler encoding/decoding rules and efficient variable-length encoding using the most efficient character set for the
actual value being encoded. The new EPC schemes and binary encodings introduced in TDS 2.0 do not use partition tables and require no
```
knowledge of the length of the GS1 Company Prefix; this is intended to improve interoperability between EPC and other data carriers such
```
as 1D and 2D barcodes, in which the length of the GS1 Company Prefix is not considered to be significant.
For EPC schemes defined before TDS 2.0, it is important to note that two EPCs are the same if and only if the Pure Identity EPC URIs are
```
character for character identical. A long binary encoding (e.g., SGTIN-198) is not a different EPC from a short binary encoding (e.g., SGTIN-
```
```
96) if the GS1 Company Prefix, item reference with indicator, and serial numbers are identical. The new EPC binary encodings introduced in
```
TDS v2.0 do not define corresponding Pure Identity EPC URIs but their values are considered to be equivalent to those encoded in a short
```
binary encoding (e.g., SGTIN-96) or a long binary encoding (e.g., SGTIN-198) if they all correspond to the same canonical GS1 Digital Link
```
URI or the same GS1 element string, e.g. if the SGTIN-96, SGTIN-198, SGTIN+, SGTIN++, DSGTIN+ or DSGTIN++ all express the same
```
value for GTIN, AI (01) and Serial Number, AI (21).
```
All EPC schemes defined before TDS 2.0 remain valid in TDS 2.0. However, the new EPC schemes and binary encodings introduced in TDS
2.0 may be particularly suitable for the following scenarios:
1. When there is a desire/need to encode additional AIDC data after the EPC within the EPC/UII memory bank
2. When there is a desire or need to simplify encoding/decoding or difficulty in determining the length of a GS1 Company Prefix.
3. When there is a desire to use fewer bits than the maximum when using alphanumeric values with a constrained character set or
where a variable-length value is significantly shorter than its maximum permitted length. In such situations, the encoding indicators
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 137 of 448
and length indicators in the new EPC schemes may result in a lower total bit count than for the equivalent "long" EPC schemes
defined before TDS 2.0.
The following table enumerates the available EPC binary coding schemes, and indicates the limitations imposed on serial numbers.
Table 12-2 EPC Binary Coding Schemes and their limitations
EPC
Scheme
EPC Binary Coding
Scheme
EPC Bit
Count
Includes
Filter
Value
Serial number limitation
sgtin
sgtin-96 96
Yes
```
Numeric-only, no leading zeros, decimal value must be less than 2 38 (i.e., decimal value less
```
```
than or equal to 274,877,906,943).
```
sgtin-198 198
```
All values permitted by GS1 General Specifications (up to 20 alphanumeric characters)
```
sgtin+ Variable
up to 216
dsgtin+ Variable
up to 236
sgtin++ Variable
dsgtin++ Variable
sscc
sscc-96 96
```
Yes All values permitted by GS1 General Specifications (11 – 5 decimal digits including extensiondigit, depending on GS1 Company Prefix length)sscc+ 84
```
sscc++ Variable
sgln
```
sgln-96 96 Yes Numeric-only, no leading zeros, decimal value must be less than 2 41 (i.e., decimal value less
```
```
than or equal to 2,199,023,255,551).
```
sgln-195 195
```
Yes All values permitted by GS1 General Specifications (up to 20 alphanumeric characters)sgln+ Variableup to 212
```
sgln++ Variable
grai
```
grai-96 96 Yes Numeric-only, no leading zeros, decimal value must be less than 2 38 (i.e., decimal value less
```
```
than or equal to 274,877,906,943).
```
grai-170 170
```
Yes All values permitted by GS1 General Specifications (up to 16 alphanumeric characters)grai+ Variableup to 188
```
grai++ Variable
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 138 of 448
EPC
Scheme
EPC Binary Coding
Scheme
EPC Bit
Count
Includes
Filter
Value
Serial number limitation
giai
giai-96 96 Yes Numeric-only, no leading zeros, decimal value must be less than a limit that varies according
to the length of the GS1 Company Prefix. See Section 14.6.5.1.
giai-202 202
```
Yes All values permitted by GS1 General Specifications (up to 18 – 24 alphanumeric characters,depending on company prefix length)giai+ Variableup to 216
```
giai++ Variable
gsrn
gsrn-96 96
```
Yes All values permitted by GS1 General Specifications (11 – 5 decimal digits, depending on GS1Company Prefix length)gsrn+ 84
```
gsrn++ Variable
gsrnp
gsrnp-96 96
```
Yes All values permitted by GS1 General Specifications (11 – 5 decimal digits, depending on GS1Company Prefix length)gsrnp+ 84
```
gsrnp++ Variable
gdti
```
gdti-96 96 Yes Numeric-only, no leading zeros, decimal value must be less than 2 41 (i.e., decimal value less
```
```
than or equal to 2,199,023,255,551).
```
gdti-113
```
(DEPRECATED as of
```
```
TDS 1.9)
```
113
```
Yes All values permitted by GS1 General Specifications prior to [GS1GS12.0] (up to 17 decimaldigits, with or without leading zeros)
```
gdti-174 174
```
Yes All values permitted by GS1 General Specifications (up to 17 alphanumeric characters)gdti+ Variableup to 191
```
gdti++ Variable
sgcn
sgcn-96 96
Yes Numeric only, up to 12 decimal digits, with or without leading zeros.sgcn+ Variableup to 108
sgcn++ Variable
itip
```
itip-110 110 Yes Numeric-only, no leading zeros, decimal value must be less than 2 38 (i.e., decimal value less
```
```
than or equal to 274,877,906,943).
```
```
itip-212 212 Yes All values permitted by GS1 General Specifications (up to 20 alphanumeric characters)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 139 of 448
EPC
Scheme
EPC Binary Coding
Scheme
EPC Bit
Count
Includes
Filter
Value
Serial number limitation
itip+ Variable
up to 232
itip++ Variable
```
gid gid-96 96 No Numeric-only, no leading zeros, decimal value must be less than 2 36 (i.e., decimal value
```
```
must be less than or equal to 68,719,476,735).
```
usdod usdod-96 96 See "United States Department of Defense Supplier's Passive RFID Information Guide" [USDOD].
adi adi-var Variable Yes See Section 14.6.14.1
cpi
```
cpi-96 96 Yes Serial Number: Numeric-only, no leading zeros, decimal value must be less than 2 31 (i.e.,
```
```
decimal value less than or equal to 2,147,483,647).
```
The component/part reference is also limited to values that are numeric-only, with no leading
zeros, and whose length is less than or equal to 15 minus the length of the GS1 Company
Prefix
cpi-var Variable
```
Yes All values permitted by GS1 General Specifications (up to 12 decimal digits, no leadingzeros).cpi+ Variableup to 274
```
cpi++ Variable
Non-Normative: Explanation: For the SGTIN, SGLN, GRAI, and GIAI EPC schemes, the serial number according to the GS1
General Specifications is a variable length, alphanumeric string. This means that serial number 34, 034, 0034, etc, are all different
serial numbers, as are P34, 34P, 0P34, P034, and so forth. In order to provide for up to 20 alphanumeric characters, 140 bits are
required to encode the serial number within schemes such as SGTIN-198 that were defined before TDS 2.0. This is why the "long"
binary encodings all have such a large number of bits. Similar considerations apply to the GDTI EPC scheme, except that the GDTI
```
only allows digit characters (but still permits leading zeros). For the new EPC binary encodings introduced in TDS 2.0, instead of
```
allocating sufficient bit capacity to accommodate the maximum permitted length of serial number components and all permitted
characters, the new EPC schemes use encoding indicators and length indicators to enable fewer bits to be used if the actual value of a
```
serial number component is shorter than the maximum permitted length or if it uses a more constrained character set (e.g. only uses
```
```
numeric digits even where alphanumeric characters are permitted). This is explained in further detail in section 14.5.
```
In order to accommodate the very common 96-bit RFID tag, additional binary coding schemes are introduced that only require 96
bits. In order to fit within 96 bits, some serial numbers have to be excluded. The 96-bit encodings of SGTIN, SGLN, GRAI, GIAI, and
```
GDTI are limited to serial numbers that consist only of digits, which do not have leading zeros (unless the serial number consists in its
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 140 of 448
```
entirety of a single 0 digit), and whose value when considered as a decimal numeral is less than 2 B , where B is the number of bits
```
available in the binary coding scheme. The choice to exclude serial numbers with leading zeros was an arbitrary design choice at the
```
time the 96-bit encodings were first defined; for example, an alternative would have been to permit leading zeros, at the expense of
```
excluding other serial numbers. But it is impossible to escape the fact that in B bits there can be no more than 2 B different serial
numbers.
When decoding a "long" binary encoding defined before TDS 2.0 or any of the new EPC binary encodings introduced in TDS 2.0, it is
not permissible to strip off leading zeros when the binary encoding includes leading zero characters. Likewise, when encoding an EPC
into either the "short" or "long" form or new EPC binary encodings introduced in TDS 2.0, it is not permissible to strip off leading
zeros prior to encoding. This means that EPCs whose serial numbers have leading zeros can only be encoded in the "long" form or in
the new EPC binary encodings introduced in TDS 2.0, which are also capable of preserving leading zeros.
In certain applications, it is desirable for the serial number to always contain a specific number of characters. Reasons for this may
include wanting a predictable length for the EPC URI string, or for having a predictable size for a corresponding barcode encoding of
the same identifier. In certain barcode applications, this is accomplished through the use of leading zeros. If 96-bit tags are used,
however, the option to use leading zeros does not exist.
Therefore, in applications that both require 96-bit tags and require that the serial number be a fixed number of characters, it is
recommended that numeric serial numbers be used that are in the range 10 D ≤ serial < 10D+1 , where D is the desired number of
digits. For example, if 11-digit serial numbers are desired, an application can use serial numbers in the range 10,000,000,000
through 99,999,999,999. Such applications must take care to use serial numbers that fit within the constraints of 96-bit tags. For
example, if 12-digit serial numbers are desired for SGTIN-96 encodings, then the serial numbers must be in the range
100,000,000,000 through 274,877,906,943.
It should be remembered, however, that many applications do not require a fixed number of characters in the serial number, and so
```
all serial numbers from 0 through the maximum value (without leading zeros) may be used with 96-bit tags.
```
12.3.2 EPC Pure Identity URI to EPC Tag URI
```
Given:
```
■ An EPC Pure Identity URI as specified in Section 6.3. This is a string that matches the EPC-URI production of the grammar in Section 6.3.
■ A selection of a binary coding scheme to use. This is one of the binary coding schemes specified in the "EPC Binary Coding Scheme" column of
Table 12-2. The chosen binary coding scheme must be one that corresponds to the EPC scheme in the EPC Pure Identity URI.
■ A filter value, if the "Includes Filter Value" column of Table 12-2 indicates that the binary encoding includes a filter value.
■ The value of the Attribute bits.
■ The value of the user memory indicator.
```
Validation:
```
```
■ The serial number portion of the EPC (the characters following the rightmost dot character) must conform to any restrictions implied by the
```
selected binary coding scheme, as specified by the "Serial Number Limitation" column of Table 12-2.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 141 of 448
■ The filter value must be in the range 0 ≤ filter ≤ 7.
```
Procedure:
```
1. Starting with the EPC Pure Identity URI, replace the prefix urn:epc:id: with urn:epc:tag:.
2. Replace the EPC scheme name with the selected EPC binary coding scheme name. For example, replace sgtin with sgtin-96 or
sgtin-198.
3. If the selected binary coding scheme includes a filter value, insert the filter value as a single decimal digit following the rightmost colon
```
(":") character of the URI, followed by a dot (".") character.
```
4. If the Attribute bits are non-zero, construct a string [att=xNN],where NN is the value of the Attribute bits as a 2-digit hexadecimal
numeral.
5. If the user memory indicator is non-zero, construct a string [umi=1].
6. If Step 4 or Step 5 yielded a non-empty string, insert those strings following the rightmost colon (":") character of the URI, followed by
an additional colon character.
7. The resulting string is the EPC Tag URI.
12.3.3 EPC Tag URI to EPC Pure Identity URI
```
Given:
```
1. An EPC Tag URI as specified in Section 12. This is a string that matches the TagURI production of the grammar in Section 12.4.
```
Procedure:
```
1. Starting with the EPC Tag URI, replace the prefix urn:epc:tag: with urn:epc:id:.
2. Replace the EPC binary coding scheme name with the corresponding EPC scheme name. For example, replace sgtin-96 or sgtin-198
with sgtin.
3. If the coding scheme includes a filter value, remove the filter value (the digit following the rightmost colon character) and the following
```
dot (".") character.
```
4. If the URI contains one or more control fields as specified in Section 12.2.2, remove them and the following colon character.
5. The resulting string is the Pure Identity EPC URI.
12.4 Grammar
The following grammar specifies the syntax of the EPC Tag URI and EPC Raw URI. The grammar makes reference to grammatical elements
defined in Sections 5 and 6.3.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 142 of 448
```
TagOrRawURI = TagURI / RawURI
```
```
TagURI = %s"urn:epc:tag:" TagURIControlBody
```
```
TagURIControlBody = 0*1( ControlField+ ":" ) TagURIBody
```
```
TagURIBody = SGTINTagURIBody / SSCCTagURIBody / SGLNTagURIBody /
```
GRAITagURIBody / GIAITagURIBody / GDTITagURIBody /
GSRNTagURIBody / GSRNPTagURIBody / ITIPTagURIBody /
GIDTagURIBody / SGCNTagURIBody / DODTagURIBody /
ADITagUriBody / CPITagURIBody
```
SGTINTagURIBody = SGTINEncName ":" NumericComponent "." SGTINURIBody
```
```
SGTINEncName = %s"sgtin-96" / %s"sgtin-198"
```
```
SSCCTagURIBody = SSCCEncName ":" NumericComponent "." SSCCURIBody
```
```
SSCCEncName = %s"sscc-96"
```
```
SGLNTagURIBody = SGLNEncName ":" NumericComponent "." SGLNURIBody
```
```
SGLNEncName = %s"sgln-96" / %s"sgln-195"
```
```
GRAITagURIBody = GRAIEncName ":" NumericComponent "." GRAIURIBody
```
```
GRAIEncName = %s"grai-96" / %s"grai-170"
```
```
GIAITagURIBody = GIAIEncName ":" NumericComponent "." GIAIURIBody
```
```
GIAIEncName = %s"giai-96" / %s"giai-202"
```
```
GSRNTagURIBody = GSRNEncName ":" NumericComponent "." GSRNURIBody
```
```
GSRNEncName = %s"gsrn-96"
```
```
GSRNPEncName = %s"gsrnp-96"
```
```
GDTITagURIBody = GDTIEncName ":" NumericComponent "." GDTIURIBody
```
```
GDTIEncName = %s"gdti-96" / %s"gdti-113" / %s"gdti-174"
```
```
CPITagURIBody = CPIEncName ":" NumericComponent "." CPIURIBody
```
```
CPIEncName = %s"cpi-96" / %s"cpi-var"
```
```
SGCNTagURIBody = SGCNEncName ":" NumericComponent "." SGCNURIBody
```
```
SGCNEncName = %s"sgcn-96"
```
```
ITIPTagURIBody = ITIPEncName ":" NumericComponent "." ITIPURIBody
```
```
ITIPEncName = %s"itip-110" / %s"itip-212"
```
```
GIDTagURIBody = GIDEncName ":" GIDURIBody
```
```
GIDEncName = %s"gid-96"
```
```
DODTagURIBody = DODEncName ":" NumericComponent "." DODURIBody
```
```
DODEncName = %s"usdod-96"
```
```
ADITagURIBody = ADIEncName ":" NumericComponent "." ADIURIBody
```
```
ADIEncName = %s"adi-var"
```
```
RawURI = %s"urn:epc:raw:" RawURIControlBody
```
```
RawURIControlBody = 0*1( ControlField+ ":") RawURIBody
```
```
RawURIBody = DecimalRawURIBody / HexRawURIBody / AFIRawURIBody
```
```
DecimalRawURIBody = NonZeroComponent "." NumericComponent
```
```
HexRawURIBody = NonZeroComponent ".x" HexComponentOrEmpty
```
```
AFIRawURIBody = NonZeroComponent ".x" HexComponent ".x" HexComponentOrEmpty
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 143 of 448
```
ControlField = "[" ControlName "=" ControlValue "]"
```
```
ControlName = %s"att" / %s"umi" / %s"xpc"
```
```
ControlValue = BinaryControlValue / HexControlValue
```
```
BinaryControlValue = "0" / "1"
```
```
HexControlValue = %s"x" HexComponent
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 144 of 448
13 URIs for EPC Tag Encoding patterns
Certain software applications need to specify rules for filtering lists of tags according to various criteria. This specification provides an EPC
Tag Pattern URI for this purpose. An EPC Tag Pattern URI does not represent a single tag encoding, but rather refers to a set of tag
encodings. A typical pattern looks like this:
```
urn:epc:pat:sgtin-96:3.0652642.[102400-204700].*
```
This pattern refers to any tag containing a 96-bit SGTIN EPC Binary Encoding, whose Filter field is 3, whose GS1 Company Prefix is
0652642, whose Item Reference is in the range 102400 ≤ itemReference ≤ 204700, and whose Serial Number may be anything at all.
In general, for all EPC schemes defined before TDS v2.0, there is an EPC Tag Pattern URI scheme corresponding to each of those EPC
```
Binary Encoding schemes, whose syntax is essentially identical except that ranges or the star (*) character may be used in each field.
```
The new EPC schemes defined in TDS v2.0 have not defined an equivalent EPC Tag URI syntax nor a corresponding EPC Tag Pattern URI
```
syntax; instead the encoding/decoding is between the binary string and the corresponding GS1 element string, GS1 Digital Link URI or
```
equivalently, the set of GS1 Application Identifiers and their values, as shown in Figure 1
For the SGTIN, SSCC, SGLN, GRAI, GIAI, GSRN, GDTI, SGCN and ITIP patterns, the pattern syntax slightly restricts how wildcards and
```
ranges may be combined. Only two possibilities are permitted for the CompanyPrefix field. One, it may be a star (*), in which case the
```
```
following field (ItemReference, SerialReference, LocationReference, AssetType,IndividualAssetReference,
```
```
ServiceReference, DocumentType, CouponReference, Piece or Total) must also be a star. Two, it may be a specific company
```
prefix, in which case the following field may be a number, a range, or a star. A range may not be specified for the CompanyPrefix.
Non-Normative: Explanation: Because the company prefix is variable length, a range may not be specified, as the range
might span different lengths. When a particular company prefix is specified, however, it is possible to match ranges or all values of
the following field, because its length is fixed for a given company prefix. The other case that is allowed is when both fields are a star,
```
which works for all tag encodings because the corresponding tag fields (including the Partition field, where present) are simply
```
ignored.
The pattern URI for the DoD Construct is as follows:
```
urn:epc:pat:usdod-96:filterPat.CAGECodeOrDODAACPat.serialNumberPat
```
```
where filterPat is either a filter value, a range of the form [lo-hi], or a * character; CAGECodeOrDODAACPat is either a CAGE
```
```
Code/DODAAC or a * character; and serialNumberPat is either a serial number, a range of the form [lo-hi], or a * character.
```
```
The pattern URI for the Aerospace and Defense (ADI) identifier is as follows:
```
```
urn:epc:pat:adi-var:filterPat.CAGECodeOrDODAACPat.partNumberPat.serialNumberPat
```
```
where filterPat is either a filter value, a range of the form [lo-hi], or a * character; CAGECodeOrDODAACPat is either a CAGE
```
```
Code/DODAAC or a * character; partNumberPat is either an empty string, a part number, or a * character; and serialNumberPat is
```
either a serial number or a * character.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 145 of 448
```
The pattern URI for the Component / Part (CPI) identifier is as follows:
```
```
urn:epc:pat:cpi-96:filterPat.CPI96PatBody.serialNumberPat
```
or
```
urn:epc:pat:cpi-var:filterPat.CPIVarPatBody
```
```
where filterPat is either a filter value, a range of the form [lo-hi], or a * character; CPI96PatBody is either *.* or a GS1 Company
```
```
Prefix followed by a dot and either a numeric component/part number, a range in the form[lo-hi], or a * character; serialNumberPat
```
```
is either a serial number or a * character or a range in the form[lo-hi]; and CPIVarPatBody is either *.*.* or a GS1 Company Prefix
```
followed by a dot followed by a component/part reference followed by a dot followed by either a component/part serial number, a range in
the form[lo-hi]or a * character.
13.1 Syntax
The syntax of EPC Tag Pattern URIs is defined by the grammar below.
```
PatURI = %s"urn:epc:pat:" PatBody
```
```
PatBody =
```
GIDPatURIBody /
SGTINPatURIBody /
SGTINAlphaPatURIBody /
SGLNGRAI96PatURIBody /
SGLNGRAIAlphaPatURIBody /
SSCCPatURIBody /
GIAI96PatURIBody /
GIAIAlphaPatURIBody /
GSRNPatURIBody /
GSRNPPatURIBody /
GDTIPatURIBody /
CPIVarPatURIBody /
SGCNPatURIBody /
ITIPPatURIBody /
USDOD96PatURIBody /
ITIP212PatURIBody /
ADIVarPatURIBody /
CPI96PatURIBody
```
GIDPatURIBody = %s"gid-96:" 2(PatComponent ".") PatComponent
```
```
SGTIN96PatURIBody = %s"sgtin-96:" PatComponent "." GS1PatBody "." PatComponent
```
```
SGTINAlphaPatURIBody = %s"sgtin-198:" PatComponent "." GS1PatBody "." GS3A3PatComponent
```
```
SGLNGRAI96PatURIBody = SGLNGRAI96TagEncName ":" PatComponent "." GS1EpatBody "." PatComponent
```
```
SGLNGRAI96TagEncName = %s"sgln-96" / %s"grai-96"
```
```
SGLNGRAIAlphaPatURIBody = SGLNGRAIAlphaTagEncName ":" PatComponent "." GS1EpatBody "." GS3A3PatComponent
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 146 of 448
```
SGLNGRAIAlphaTagEncName = %s"sgln-195" / %s"grai-170"
```
```
SSCCPatURIBody = %s"sscc-96:" PatComponent "." GS1PatBody
```
```
GIAI96PatURIBody = %s"giai-96:" PatComponent "." GS1PatBody
```
```
GIAIAlphaPatURIBody = %s"giai-202:" PatComponent "." GS1GS3A3PatBody
```
```
GSRNPatURIBody = %s"gsrn-96:" PatComponent "." GS1PatBody
```
```
GSRNPPatURIBody = %s"gsrnp-96:" PatComponent "." GS1PatBody
```
```
GDTIPatURIBody = GDTI96PatURIBody / GDTI113PatURIBody/ GDTI174PatURIBody
```
```
GDTI96PatURIBody = %s"gdti-96:" PatComponent "." GS1EpatBody "." PatComponent
```
```
GDTI113PatURIBody = %s"gdti-113:" PatComponent "." GS1EpatBody "." PaddedNumericOrStarComponent
```
```
GDTI174PatURIBody = %s"gdti-174:" PatComponent "." GS1EpatBody "." GS3A3PatComponent
```
```
CPI96PatURIBody = %s"cpi-96:" PatComponent "." GS1PatBody "." PatComponent
```
```
CPIVarPatURIBody = %s"cpi-var:" PatComponent "." CPIVarPatBody
```
```
CPIVarPatBody = "*.*.*"
```
/ PaddedNumericComponent "." CPRefComponent "." PatComponent
```
SGCNPatURIBody = SGCN96PatURIBody
```
```
SGCN96PatURIBody = %s"sgcn-96:" PatComponent "." GS1EpatBody "." PaddedNumericOrStarComponent
```
```
ITIP110PatURIBody = %s"itip-110:" PatComponent "." GS1PatBody "." PatComponent "." PatComponent "."
```
PatComponent
```
ITIP212PatURIBody = %s"itip-212:" PatComponent "." GS1PatBody "." PatComponent "." PatComponent "."
```
GS3A3PatComponent
```
USDOD96PatURIBody = %s"usdod-96:" PatComponent "." CAGECodeOrDODAACPat "." PatComponent
```
```
ADIVarPatURIBody = %s"adi-var:" PatComponent "." CAGECodeOrDODAACPat "." ADIPatComponent "."
```
ADIExtendedPatComponent
```
PaddedNumericOrStarComponent = PaddedNumericComponent / StarComponent
```
```
GS1PatBody = "*.*" / ( PaddedNumericComponent "." PaddedPatComponent )
```
```
GS1EpatBody = "*.*" / ( PaddedNumericComponent "." PaddedOrEmptyPatComponent )
```
```
GS1GS3A3PatBody = "*.*" / ( PaddedNumericComponent "." GS3A3PatComponent )
```
```
PatComponent = NumericComponent / StarComponent / RangeComponent
```
```
PaddedPatComponent = PaddedNumericComponent / StarComponent / RangeComponent
```
```
PaddedOrEmptyPatComponent = PaddedNumericComponentOrEmpty
```
/ StarComponent
/ RangeComponent
```
GS3A3PatComponent = GS3A3Component / StarComponent
```
```
CAGECodeOrDODAACPat = CAGECodeOrDODAAC / StarComponent
```
```
ADIPatComponent= ADIComponent / StarComponent
```
```
ADIExtendedPatComponent = ADIExtendedComponent / StarComponent
```
```
StarComponent = "*"
```
```
RangeComponent = "[" NumericComponent "-" NumericComponent "]"
```
For a RangeComponent to be legal, the numeric value of the first NumericComponent must be less than or equal to the numeric value of
the second NumericComponent.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 147 of 448
13.2 Semantics
```
The meaning of an EPC Tag Pattern URI (urn:epc:pat:) is formally defined as denoting a set of EPC Tag URIs.
```
The set of EPCs denoted by a specific EPC Tag Pattern URI is defined by the following decision procedure, which says whether a given EPC
Tag URI belongs to the set denoted by the EPC Tag Pattern URI.
Let urn:epc:pat:EncName:P1.I..Pn be an EPC Tag Pattern URI. Let urn:epc:tag:EncName:IC2...Cn be an EPC Tag URI, where
```
the EncName field of both URIs is the same. The number of components (n) depends on the value of EncName.
```
First, any EPC Tag URI component Ci is said to match the corresponding EPC Tag Pattern URI component Pi if:
```
■ Pi is a NumericComponent, and Ci is equal to Pi; or
```
```
■ Pi is a PaddedNumericComponent, and Ci is equal to Pi both in numeric value as well as in length; or
```
```
■ Pi is a GS3A3Component, ADIExtendedComponent, ADIComponent, or CPRefComponent and Ci is equal to Pi, character for character; or
```
```
■ Pi is a CAGECodeOrDODAAC, and Ci is equal to Pi; or
```
```
■ Pi is a RangeComponent [lo-hi], and lo ≤ Ci ≤ hi; or
```
```
■ Pi is a StarComponent (and Ci is anything at all)
```
Then the EPC Tag URI is a member of the set denoted by the EPC Pattern URI if and only if Ci matches Pi for all 1 ≤ i ≤ n.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 148 of 448
14 EPC Binary Encoding
```
This section specifies how EPC Tag URIs or element strings (GS1 Application Identifiers and their values) are encoded into binary strings,
```
```
and conversely how a binary string is decoded into an EPC Tag URI (if possible) or element string (GS1 Application Identifiers and their
```
```
values). The binary strings defined by the encoding and decoding procedures in this section are suitable for use in the EPC memory bank of
```
a Gen 2 tag.
```
The general structure of an EPC Binary Encoding as used on a tag is as a string of bits (i.e., a binary representation), consisting of a fixed
```
length header followed by a series of fields whose overall length, structure, and function are determined by the header value. The assigned
header values are specified in Section 14.2. Both the encoding and decoding procedures are driven by coding tables specified in
Section 14.6. Each coding table specifies, for a given header value, the structure of the fields following the header.
EPC schemes are defined for most of the globally unique instance identifiers that can be constructed using GS1 identification keys – so not
only for GTIN but also SSCC, GRAI, GIAI etc. However, binary encodings have only been defined for those where there is a strong case for
```
encoding an EPC in an RFID data carrier (e.g. for a serialised product instance or for a logistic unit, asset physical location) but not for
```
organisations nor for groupings of logistic units that correspond to consignments or shipments.
TDS 2.0 introduces alternative modernised EPC binary encodings for all EPC schemes based on GS1 identifiers, for which a binary encoding
was already defined in TDS 1.13. These new EPC binary encodings have much simpler translation to/from GS1 element strings on
barcodes, with no need to know the length of the GS1 Company Prefix, no omission of the check digit and no rearrangement of the indicator
digit of the GTIN nor the extension digit of the SSCC. The encoding/decoding is between the binary string and the corresponding GS1
element string, GS1 Digital Link URI or equivalently, the set of GS1 Application Identifiers and their values, as shown in Figure 1. These new
EPC binary encodings all have names ending '+', to denote that they also offer the option of encoding additional +AIDC data after the EPC
binary string. No EPC Tag URI syntax is defined for any of the new EPC schemes introduced in TDS 2.0, so instead of referring to Sections
14.3 and 14.4 for the encoding and decoding procedures, Section 14.5 explains the encoding and decoding procedures for the new EPC
schemes introduced in TDS v2.0 and should be read in conjunction with the relevant binary coding table from Section 14.6, which provides
```
the binary coding tables for all EPC schemes (old and new). A requirement for TDS 2.0 conformance is that implementations of decoders
```
SHALL support all of the new encoding and decoding methods in Section 14.5. Implementers of encoders SHALL support all of the new
encoding methods in Section 14.5 that are explicitly mentioned within columns b or i of Table F in Section 15.3.
The older EPC schemes defined before TDS 2.0 remain valid and for these EPC schemes, the complete procedure for encoding an EPC Tag
URI into the binary contents of the EPC memory bank of a Gen 2 tag is specified in Section 15.1.1. The procedure in Section 15.1.1 uses the
```
procedure defined below in Section 14.3 (encoding URI to binary) to do the bulk of the work. Conversely, the complete procedure for
```
```
decoding the binary contents of the EPC memory bank of a Gen 2 tag into an EPC Tag URI (or EPC Raw URI, if necessary) is specified in
```
```
Section 15.2.2. The procedure in Section 15.2.2 uses the procedure defined below in Section 14.4 (decoding binary to URI) to do the bulk of
```
the work.
14.1 Overview of Binary Encoding
To convert an EPC Tag URI to the EPC Binary Encoding, follow the procedure specified in Section 14.3, which is summarised as follows.
First, the appropriate coding table is selected from the EPC Binary coding tables specified in Section 14.6. The correct coding table is the
one whose "URI Template" entry matches the given EPC Tag URI. Each column in the coding table corresponds to a bit field within the final
binary encoding. Within each column, a "Coding Method" is specified that says how to calculate the corresponding bits of the binary
encoding, given some portion of the URI as input. The encoding details for each "Coding Method" are given in subsections of Section 14.3.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 149 of 448
To convert an EPC Binary Encoding into an EPC Tag URI, follow the procedure specified in Section 14.4, which is summarised as follows.
```
First, the most significant eight bits are looked up in the table of EPC binary headers (Table 14-1 in Section 14.2). This identifies the EPC
```
coding scheme, which in turn selects a coding table from among those specified in Section 14.6. Each column in the coding table
corresponds to a bit field in the input binary encoding. Within each column, a "Coding Method" is specified that says how to calculate a
corresponding portion of the output URI, given that bit field as input. The decoding details for each "Coding Method" are given in
subsections of Section 14.4.
14.2 EPC Binary Headers
```
As already noted, the general structure of an EPC Binary Encoding as used on a tag is as a string of bits (i.e., a binary representation),
```
consisting of a fixed length, 8 bit, header followed by a series of fields whose overall length, structure, and function are determined by the
```
header value. For future expansion purpose, a header value of 11111111 is defined, to indicate that longer headers beyond 8 bits is used;
```
this provides for future expansion so that more than 256 header values may be accommodated by using longer headers. Therefore, the
present specification provides for up to 255 8-bit headers, plus a currently undetermined number of longer headers.
Non-Normative: Back-compatibility note: In earlier versions of TDS, the header was of variable length, using a tiered
approach in which a zero value in each tier indicated that the header was drawn from the next longer tier. For the encodings defined
in the earlier specification, headers were either 2 bits or 8 bits. Given that a zero value is reserved to indicate a header in the next
```
longer tier, the 2-bit header had 3 possible values (01, 10, and 11, not 00), and the 8-bit header had 63 possible values (recognising
```
```
that the first 2 bits must be 00 and 00000000 is reserved to allow headers that are longer than 8 bits). The 2-bit headers were only
```
used in conjunction with certain 64-bit EPC Binary Encodings.
```
In more recent versions of TDS, the tiered header approach has been abandoned. Also, all 64-bit encodings (including all encodings
```
```
that used 2-bit headers) have been deprecated, and should not be used in new applications.
```
The encoding schemes defined in this version of TDS are shown in Table 14-1. The table also indicates currently unassigned header values
```
that are "Reserved for Future Use" (RFU). All header values that had been reserved for legacy 64-bit encodings, defined in prior versions of
```
the EPC Tag Data Standard, were sunset, effective 1 July, 2009, as previously announced by EPCglobal on 1 July, 2006.
Table 14-1 EPC Binary Header Values
Header Value
```
(binary)
```
Header Value
```
(hexadecimal)
```
Encoding
```
Length (bits)
```
Coding Scheme
0000 0000 00 NA Unprogrammed Tag
0000 0001
0000 001x
0000 01xx
01
02,03
04,05
06,07
NA
NA
NA
NA
Reserved for Future Use
Reserved for Future Use
Reserved for Future Use
Reserved for Future Use
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 150 of 448
Header Value
```
(binary)
```
Header Value
```
(hexadecimal)
```
Encoding
```
Length (bits)
```
Coding Scheme
0000 1000 08 Reserved for Future Use
0000 1001 09 Reserved for Future Use
0000 1010 0A Reserved for Future Use
0000 1011 0B Reserved for Future Use
0000 1100
to
0000 1111
0C
to
0F
Reserved for Future Use
0001 0000
to
0010 1011
10
to
2B
NA
NA
Reserved for Future Use
0010 1100 2C 96 GDTI-96
0010 1101 2D 96 GSRN-96
0010 1110 2E 96 GSRNP-96
0010 1111 2F 96 USDoD-96
0011 0000 30 96 SGTIN-96
0011 0001 31 96 SSCC-96
0011 0010 32 96 SGLN-96
0011 0011 33 96 GRAI-96
0011 0100 34 96 GIAI-96
0011 0101 35 96 GID-96
0011 0110 36 198 SGTIN-198
0011 0111 37 170 GRAI-170
0011 1000 38 202 GIAI-202
0011 1001 39 195 SGLN-195
```
0011 1010 3A 113 GDTI-113 (DEPRECATED as of TDS 1.9)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 151 of 448
Header Value
```
(binary)
```
Header Value
```
(hexadecimal)
```
Encoding
```
Length (bits)
```
Coding Scheme
0011 1011 3B Variable ADI-var
0011 1100 3C 96 CPI-96
0011 1101 3D Variable CPI-var
0011 1110 3E 174 GDTI-174
0011 1111 3F 96 SGCN-96
0100 0000 40 110 ITIP-110
0100 0001 41 212 ITIP-212
0100 0010
to
0111 1111
42
to
7F
Reserved for Future Use
1000 0000
to
1011 1111
80
to
BF
Reserved for Future Use
1100 0000
to
1100 1101
C0
to
CD
Reserved for Future Use
1100 1110 CE Reserved for Future Use
1100 1111
to
1110 0001
CF
to
E1
Reserved for Future Use
1110 0010 E2 E2 remains PERMANENTLY RESERVED to avoid
confusion with the first eight bits of TID memory
```
(Section 16).
```
1110 0011
to
1110 0101
E3
to
E5
Reserved for Future Use
1110 0110 E6 variable CPI++
1110 0111 E7 variable GSRN++
1110 1000 E8 variable GSRNP++
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 152 of 448
Header Value
```
(binary)
```
Header Value
```
(hexadecimal)
```
Encoding
```
Length (bits)
```
Coding Scheme
1110 1001 E9 variable SGLN++
1110 1010 EA variable GDTI++
1110 1011 EB variable GRAI++
1110 1100 EC variable SGCN++
1110 1101 ED variable ITIP++
1110 1110 EE variable GIAI++
1110 1111 EF variable SSCC++
1111 0000 F0 variable CPI+
1111 0001 F1 variable GRAI+
1111 0010 F2 variable SGLN+
1111 0011 F3 variable ITIP+
1111 0100 F4 84 GSRN+
1111 0101 F5 84 GSRNP+
1111 0110 F6 variable GDTI+
1111 0111 F7 variable SGTIN+
1111 1000 F8 variable SGCN+
1111 1001 F9 84 SSCC+
1111 1010 FA variable GIAI+
1111 1011 FB variable DSGTIN+
1111 1100 FC variable DSGTIN++
1111 1101 FD variable SGTIN++
1111 1110 FE Reserved for Future Use
1111 FF NA Reserved for Future Use
```
(expressly reserved for headers longer than 8 bits)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 153 of 448
14.3 Encoding procedure
```
The following procedure encodes an EPC Tag URI into a bit string containing the encoded EPC and the filter value (for EPC schemes that
```
```
have a filter value and for EPC schemes for which an EPC Tag URI is defined; no EPC Tag URI format is defined for new EPC schemes
```
introduced in TDS 2.0 – for those schemes, the starting point for encoding is the corresponding GS1 element string or equivalently, the set
```
of GS1 Application Identifiers and their values. For all new EPC schemes introduced in TDS 2.0, please refer to section 14.5 instead). This
```
bit string is suitable for storing in the EPC memory bank of a Gen 2 Tag beginning at bit 20h. See Section 15.1.1 for the complete procedure
```
for encoding the entire EPC memory bank, including control information that resides outside of the encoded EPC. (The procedure in
```
```
Section 15.1.1 uses the procedure below as a subroutine.)
```
```
Given:
```
■ An EPC Tag URI of the form urn:epc:tag:scheme:remainder
```
Yields:
```
```
■ A bit string containing the EPC binary encoding of the specified EPC Tag URI, containing the encoded EPC together with the filter value (if
```
```
applicable); OR
```
■ An exception indicating that the EPC Tag URI could not be encoded.
```
Procedure:
```
1. Use the scheme to identify the coding table for this URI scheme. If no such scheme exists, stop: this URI is not syntactically legal.
2. Confirm that the URI syntactically matches the URI template associated with the coding table. If not, stop: this URI is not syntactically
legal.
3. Read the coding table left-to-right, and construct the encoding specified in each column to obtain a bit string. If the "Coding Segment
Bit Count" row of the table specifies a fixed number of bits, the bit string so obtained will always be of this length. The method for
encoding each column depends on the "Coding Method" row of the table. If the "Coding Method" row specifies a specific bit string, use
that bit string for that column. Otherwise, consult the following sections that specify the encoding methods. If the encoding of any
segment fails, stop: this URI cannot be encoded.
4. Concatenate the bit strings from Step 3 to form a single bit string. If the overall binary length specified by the scheme is of fixed length,
then the bit string so obtained will always be of that length. The position of each segment within the concatenated bit string is as
specified in the "Bit Position" row of the coding table. Section 15.1.1 specifies the procedure that uses the result of this step for
encoding the EPC memory bank of a Gen 2 tag.
The following sections specify the procedures to Ie used in Step 3.
14.3.1 "Integer" Encoding Method
The Integer encoding method is used for a segment that appears as a decimal integer in the URI, and as a binary integer in the binary
encoding.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 154 of 448
```
Input:
```
The input to the encoding method is the URI portion indicated in the "URI portion" row of the encoding table, a character string with no dot
```
(".") characters.
```
Validity Test:
The input character string must satisfy the following:
■ It must match the grammar for NumericComponent as specified in Section 5.
```
■ The value of the string SHALL be considered as a decimal integer (i.e., leading zeros are not permitted) and SHALL be less than 2b, where b is
```
the value specified in the "Coding Segment Bit Count" row of the encoding table.
If any of the above tests fails, the encoding of the URI fails.
```
Output:
```
```
The encoding of this segment is a b-bit integer (padded to the left with zero bits as necessary), where b is the value specified in the "Coding
```
Segment Bit Count" row of the encoding table, whose value is the value of the input character string considered as a decimal integer.
14.3.2 "String" Encoding method
The String encoding method is used for a segment that appears as an alphanumeric string in the URI, and as an ISO/IEC 646 [ISO646]
```
(ASCII) encoded bit string in the binary encoding.
```
```
Input:
```
The input to the encoding method is the URI portion indicated in the "URI portion" row of the encoding table, a character string with no dot
```
(".") characters.
```
Validity Test:
The input character string must satisfy the following:
■ It must match the grammar for GS3A3Component as specified in Section 5.
```
■ For each portion of the string that matches the Escape production of the grammar specified in Section 5 (that is, a 3-character sequence
```
```
consisting of a % character followed by two hexadecimal digits), the two hexadecimal characters following the % character must map to one of the
```
82 allowed characters specified in Table A-1.
■ The number of characters must be less than or equal to b/7, where b is the value specified in the "Coding Segment Bit Count" row of the coding
table.
If any of the above tests fails, the encoding of the URI fails.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 155 of 448
```
Output:
```
Consider the input to be a string of zero or more characters s1s2 …sN, where each character si is either a single character or a 3-character
```
sequence matching the Escape production of the grammar (that is, a 3-character sequence consisting of a % character followed by two
```
```
hexadecimal digits). Translate each character to a 7-bit string. For a single character, the corresponding 7-bit string is specified in Table
```
A-1. For an Escape sequence, the 7-bit string is the value of the two hexadecimal characters considered as a 7-bit integer. Concatenating
those 7-bit strings in the order corresponding to the input, then pad to the right with zero bits as necessary to total b bits, where b is the
```
value specified in the "Coding Segment Bit Count" row of the coding table. (The number of padding bits will be b – 7N.) The resulting b-bit
```
string is the output.
14.3.3 "Partition Table" Encoding method
The Partition Table encoding method is used for a segment that appears in the URI as a pair of variable-length numeric fields separated by
```
a dot (".") character, and in the binary encoding as a 3-bit "partition" field followed by two variable length binary integers. The number of
```
characters in the two URI fields always totals to a constant number of characters, and the number of bits in the binary encoding likewise
totals to a constant number of bits.
The Partition Table encoding method makes use of a "partition table." The specific partition table to use is specified in the coding table for a
given EPC scheme.
```
Input:
```
The input to the encoding method is the URI portion indicated in the "URI portion" row of the encoding table. This consists of two strings of
```
digits separated by a dot (".") character. For the purpose of this encoding procedure, the digit strings to the left and right of the dot are
```
denoted C and D, respectively.
Validity Test:
The input must satisfy the following:
■ C must match the grammar for PaddedNumericComponent as specified in Section 5.
■ D must match the grammar for PaddedNumericComponentOrEmpty as specified in Section 5.
```
■ The number of digits in C must match one of the values specified in the "GS1 Company Prefix Digits (L)" column of the partition table. The
```
corresponding row is called the "matching partition table row" in the remainder of the encoding procedure.
■ The number of digits in D must match the corresponding value specified in the other field digits column of the matching partition table row. Note
that if the other field digits column specifies zero, then D must be the empty string, implying the overall input segment ends with a "dot"
character.
```
Output:
```
Construct the output bit string by concatenating the following three components:
■ The value P specified in the "partition value" column of the matching partition table row, as a 3-bit binary integer.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 156 of 448
■ The value of C considered as a decimal integer, converted to an M-bit binary integer, where M is the number of bits specified in the "GS1
Company Prefix bits" column of the matching partition table row.
■ The value of D considered as a decimal integer, converted to an N-bit binary integer, where N is the number of bits specified in the other field bits
column of the matching partition table row. If D is the empty string, the value of the N-bit integer is zero.
```
The resulting bit string is (3 + M + N) bits in length, which always equals the "Coding Segment Bit Count" for this segment as indicated in
```
the coding table.
14.3.4 "Unpadded Partition Table" Encoding method
The Unpadded Partition Table encoding method is used for a segment that appears in the URI as a pair of variable-length numeric fields
```
separated by a dot (".") character, and in the binary encoding as a 3-bit "partition" field followed by two variable length binary integers.
```
The number of characters in the two URI fields is always less than or equal to a known limit, and the number of bits in the binary encoding
is always a constant number of bits.
The Unpadded Partition Table encoding method makes use of a "partition table." The specific partition table to use is specified in the coding
table for a given EPC scheme.
```
Input:
```
The input to the encoding method is the URI portion indicated in the "URI portion" row of the encoding table. This consists of two strings of
```
digits separated by a dot (".") character. For the purpose of this encoding procedure, the digit strings to the left and right of the dot are
```
denoted C and D, respectively.
Validity Test:
The input must satisfy the following:
■ C must match the grammar for PaddedNumericComponent as specified in Section 5.
■ D must match the grammar for NumericComponent as specified in Section 5.
```
■ The number of digits in C must match one of the values specified in the "GS1 Company Prefix Digits (L)" column of the partition table. The
```
corresponding row is called the "matching partition table row" in the remainder of the encoding procedure.
■ The value of D, considered as a decimal integer, must be less than 2N , where N is the number of bits specified in the other field bits column of the
matching partition table row.
```
Output:
```
Construct the output bit string by concatenating the following three components:
■ The value P specified in the "partition value" column of the matching partition table row, as a 3-bit binary integer.
■ The value of C considered as a decimal integer, converted to an M-bit binary integer, where M is the number of bits specified in the "GS1
Company Prefix bits" column of the matching partition table row.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 157 of 448
■ The value of D considered as a decimal integer, converted to an N-bit binary integer, where N is the number of bits specified in the other field bits
column of the matching partition table row. If D is the empty string, the value of the N-bit integer is zero.
```
The resulting bit string is (3 + M + N) bits in length, which always equals the "Coding Segment Bit Count" for this segment as indicated in
```
the coding table.
14.3.5 "String Partition Table" Encoding method
The String Partition Table encoding method is used for a segment that appears in the URI as a variable-length numeric field and a variable-
```
length string field separated by a dot (".") character, and in the binary encoding as a 3-bit "partition" field followed by a variable length
```
binary integer and a variable length binary-encoded character string. The number of characters in the two URI fields is always less than or
```
equal to a known limit (counting a 3-character escape sequence as a single character), and the number of bits in the binary encoding is
```
padded if necessary to a constant number of bits.
The Partition Table encoding method makes use of a "partition table." The specific partition table to use is specified in the coding table for a
given EPC scheme.
```
Input:
```
The input to the encoding method is the URI portion indicated in the "URI portion" row of the encoding table. This consists of two strings
```
separated by a dot (".") character. For the purpose of this encoding procedure, the strings to the left and right of the dot are denoted C and
```
D, respectively.
Validity Test:
The input must satisfy the following:
■ C must match the grammar for PaddedNumericComponent as specified in Section 5.
■ D must match the grammar for GS3A3Component as specified in Section 5.
```
■ The number of digits in C must match one of the values specified in the "GS1 Company Prefix Digits (L)" column of the partition table. The
```
corresponding row is called the "matching partition table row" in the remainder of the encoding procedure.
■ The number of characters in D must be less than or equal to the corresponding value specified in the other field maximum characters column of
```
the matching partition table row. For the purposes of this rule, an escape triplet (%nn) is counted as one character.
```
```
■ For each portion of D that matches the Escape production of the grammar specified in Section 5 (that is, a 3-character sequence consisting of a
```
```
% character followed by two hexadecimal digits), the two hexadecimal characters following the % character must map to one of the 82 allowed
```
characters specified in Table A-1.
```
Output:
```
Construct the output bit string by concatenating the following three components:
■ The value P specified in the "partition value" column of the matching partition table row, as a 3-bit binary integer.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 158 of 448
■ The value of C considered as a decimal integer, converted to an M-bit binary integer, where M is the number of bits specified in the "GS1
Company Prefix bits" column of the matching partition table row.
■ The value of D converted to an N-bit binary string, where N is the number of bits specified in the other field bits column of the matching partition
table row. This N-bit binary string is constructed as follows. Consider D to be a string of zero or more characters s1s2 …sN, where each character
```
si is either a single character or a 3-character sequence matching the Escape production of the grammar (that is, a 3-character sequence
```
```
consisting of a % character followed by two hexadecimal digits). Translate each character to a 7-bit string. For a single character, the
```
corresponding 7-bit string is specified in Table A-1. For an Escape sequence, the 7-bit string is the value of the two hexadecimal characters
considered as a 7-bit integer. Concatenate those 7-bit strings in the order corresponding to the input, then pad with zero bits as necessary to
total N bits.
```
The resulting bit string is (3 + M + N) bits in length, which always equals the "Coding Segment Bit Count" for this segment as indicated in
```
the coding table.
14.3.6 "Numeric String" Encoding method
The Numeric String encoding method is used for a segment that appears as a numeric string in the URI, possibly including leading zeros.
The leading zeros are preserved in the binary encoding by prepending a "1" digit to the numeric string before encoding.
```
Input:
```
The input to the encoding method is the URI portion indicated in the "URI portion" row of the encoding table, a character string with no dot
```
(".") characters.
```
Validity Test:
The input character string must satisfy the following:
■ It must match the grammar for PaddedNumericComponent as specified in Section 5.
■ The number of digits in the string, D, must be such that 2 × 10 D < 2b, where b is the value specified in the "Coding Segment Bit Count" row of
```
the encoding table. (For the GDTI-113 scheme, b = 58 and therefore the number of digits D must be less than or equal to 17. GDTI-113 and
```
```
SGCN-96 are the only schemes that uses this encoding method.)
```
If any of the above tests fails, the encoding of the URI fails.
```
Output:
```
Construct the output bit string as follows:
■ Prepend the character "1" to the left of the input character string.
```
■ Convert the resulting string to a b-bit integer (padded to the left with zero bits as necessary), where b is the value specified in the "bit count" row
```
of the encoding table, whose value is the value of the input character string considered as a decimal integer.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 159 of 448
14.3.7 "6-bit CAGE/DODAAC" Encoding method
The 6-Bit CAGE/DoDAAC encoding method is used for a segment that appears as a 5-character CAGE code or 6-character DoDAAC in the
URI, and as a 36-bit encoded bit string in the binary encoding.
```
Input:
```
The input to the encoding method is the URI portion indicated in the "URI portion" row of the encoding table, a 5- or 6-character string with
```
no dot (".") characters.
```
Validity Test:
The input character string must satisfy the following:
■ It must match the grammar for CAGECodeOrDODAAC as specified in Section 6.3.17.
If the above test fails, the encoding of the URI fails.
```
Output:
```
Consider the input to be a string of five or six characters d1d2 …dN, where each character di is a single character. Translate each character to
```
a 6-bit string using Table G-1 (G). Concatenate those 6-bit strings in the order corresponding to the input. If the input was five characters,
```
prepend the 6-bit value 100000 to the left of the result. The resulting 36-bit string is the output.
14.3.8 "6-Bit Variable String" Encoding method
The 6-Bit Variable String encoding method is used for a segment that appears in the URI as a string field, and in the binary encoding as
variable length null-terminated binary-encoded character string.
```
Input:
```
The input to the encoding method is the URI portion indicated in the "URI portion" row of the encoding table.
Validity Test:
The input must satisfy the following:
■ The input must match the grammar for the corresponding portion of the URI as specified in the appropriate subsection of Section 6.3.
■ The number of characters in the input must be greater than or equal to the minimum number of characters and less than or equal to the
maximum number of characters specified in the footnote to the coding table for this coding table column. For the purposes of this rule, an escape
```
triplet (%nn) is counted as one character.
```
```
■ For each portion of the input that matches the Escape production of the grammar specified in Section 5 (that is, a 3-character sequence
```
```
consisting of a % character followed by two hexadecimal digits), the two hexadecimal characters following the % character must map to one of the
```
```
characters specified in Table G-1 (G), and the character so mapped must satisfy any other constraints specified in the coding table for this coding
```
segment.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 160 of 448
```
■ For each portion of the input that is a single character (as opposed to a 3-character escape sequence), that character must satisfy any other
```
constraints specified in the coding table for this coding segment.
```
Output:
```
Consider the input to be a string of zero or more characters s1s2 …sN, where each character si is either a single character or a 3-character
```
sequence matching the Escape production of the grammar (that is, a 3-character sequence consisting of a % character followed by two
```
```
hexadecimal digits). Translate each character to a 6-bit string. For a single character, the corresponding 6-bit string is specified in Table G-1
```
```
(G). For an Escape sequence, the corresponding 6-bit string is specified in Table G-1 (G) by finding the escape sequence in the "URI Form"
```
```
column. Concatenate those 6-bit strings in the order corresponding to the input, then append six zero bits (000000).
```
The resulting bit string is of variable length, but is always at least 6 bits and is always a multiple of 6 bits.
14.3.9 "6-Bit Variable String Partition Table" Encoding method
The 6-Bit Variable String Partition Table encoding method is used for a segment that appears in the URI as a variable-length numeric field
```
and a variable-length string field separated by a dot (".") character, and in the binary encoding as a 3-bit "partition" field followed by a
```
variable length binary integer and a null-terminated binary-encoded character string. The number of characters in the two URI fields is
```
always less than or equal to a known limit (counting a 3-character escape sequence as a single character), and the number of bits in the
```
binary encoding is also less than or equal to a known limit.
The 6-Bit Variable String Partition Table encoding method makes use of a "partition table." The specific partition table to use is specified in
the coding table for a given EPC scheme.
```
Input:
```
The input to the encoding method is the URI portion indicated in the "URI portion" row of the encoding table. This consists of two strings
```
separated by a dot (".") character. For the purpose of this encoding procedure, the strings to the left and right of the dot are denoted C and
```
D, respectively.
Validity Test:
The input must satisfy the following:
■ The input must match the grammar for the corresponding portion of the URI as specified in the appropriate subsection of Section 6.3.
```
■ The number of digits in C must match one of the values specified in the "GS1 Company Prefix Digits (L)" column of the partition table. The
```
corresponding row is called the "matching partition table row" in the remainder of the encoding procedure.
■ The number of characters in D must be less than or equal to the corresponding value specified in the other field maximum characters column of
```
the matching partition table row. For the purposes of this rule, an escape triplet (%nn) is counted as one character.
```
```
■ For each portion of D that matches the Escape production of the grammar specified in Section 5 (that is, a 3-character sequence consisting of a
```
```
% character followed by two hexadecimal digits), the two hexadecimal characters following the % character must map to one of the 39 allowed
```
```
characters specified in Table G-1 (G).
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 161 of 448
```
Output:
```
Construct the output bit string by concatenating the following three components:
■ The value P specified in the "partition value" column of the matching partition table row, as a 3-bit binary integer.
■ The value of C considered as a decimal integer, converted to an M-bit binary integer, where M is the number of bits specified in the "GS1
Company Prefix bits" column of the matching partition table row.
■ The value of D converted to an N-bit binary string, where N is less than or equal to the number of bits specified in the other field maximum bits
column of the matching partition table row. This binary string is constructed as follows. Consider D to be a string of one or more characters
```
s1s2 …sN, where each character si is either a single character or a 3-character sequence matching the Escape production of the grammar (that is,
```
```
a 3-character sequence consisting of a % character followed by two hexadecimal digits). Translate each character to a 6-bit string. For a single
```
```
character, the corresponding 6-bit string is specified in Table G-1 (G). For an Escape sequence, the 6-bit string is the value of the two
```
hexadecimal characters considered as a 6-bit integer. Concatenate those 6-bit strings in the order corresponding to the input, then add six zero
bits.
```
The resulting bit string is (3 + M + N) bits in length, which is always less than or equal to the maximum "Coding Segment Bit Count" for this
```
segment as indicated in the coding table.
14.3.10 "Fixed Width Integer" Encoding Method
The Fixed Width Integer encoding method is used for a segment that appears as a zero-padded decimal integer in the URI, and as a binary
integer in the binary encoding.
```
Input:
```
The input to the encoding method is the URI portion indicated in the "URI portion" row of the encoding table, an all-numeric character string
```
with no dot (".") characters.
```
Validity Test:
The input character string must satisfy the following:
■ It must match the grammar for PaddedNumericComponent as specified in Section 5.
```
■ The value of the string when considered as a non-negative decimal integer must be less than ((10^D) -1) where D=int(b*log(2)/log(10)), where
```
b is the value specified in the "Coding Segment Bit Count" row of the encoding table.
If any of the above tests fails, the encoding of the URI fails.
```
Output:
```
```
The encoding of this segment is a b-bit integer (padded to the left with zero bits as necessary), where b is the value specified in the "Coding
```
Segment Bit Count" row of the encoding table, whose value is the value of the input character string considered as a decimal integer.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 162 of 448
14.4 Decoding procedure
```
This procedure decodes a bit string as found beginning at bit 20 h in the EPC memory bank of a Gen 2 Tag into an EPC Tag URI (This section
```
```
only applies for EPC schemes for which an EPC Tag URI is defined; no EPC Tag URI format is defined for new EPC schemes introduced in
```
TDS 2.0 – for those schemes, the result of decoding is the corresponding GS1 element string or equivalently, the set of GS1 Application
```
Identifiers and their values. For all new EPC schemes introduced in TDS 2.0, please refer to section 14.5 instead). This procedure only
```
```
decodes the EPC and filter value (if applicable). Section 15.2.2 gives the complete procedure for decoding the entire contents of the EPC
```
memory bank, including control information that is stored outside of the encoded EPC. The procedure in Section 15.2.2 should be used by
```
most applications. (The procedure in Section 15.2.2 uses the procedure below as a subroutine.)
```
```
Given:
```
■ A bit string consisting of N bits bN-1 bN-2 …b0
```
Yields:
```
```
■ An EPC Tag URI beginning with urn:epc:tag:, which does not contain control information fields (other than the filter value if the EPC scheme
```
```
includes a filter value); OR
```
■ An exception indicating that the bit string cannot be decoded into an EPC Tag URI.
```
Procedure:
```
1. Extract the most significant eight bits, the EPC header: bN-1 bN-2 …bN-8 . Referring to Table 14-1 in Section 14.2, use the header to
identify the coding table for this binary encoding and the encoding bit length B. If no coding table exists for this header, stop: this
binary encoding cannot be decoded.
2. Confirm that the total number of bits N is greater than or equal to the total number of bits B specified for this header in Table 14-1. If
not, stop: this binary encoding cannot be decoded.
3. If necessary, truncate the least significant bits of the input to match the number of bits specified in Table 14-1 That is, if Table 14-1
specifies B bits, retain bits bN-1 bN-2 …bN-B . For the remainder of this procedure, consider the remaining bits to be numbered bB-1 bB-
```
2 …b0.(The purpose of this step is to remove any trailing zero padding bits that may have been read due to word-oriented data transfer.)
```
4. For a variable-length coding scheme, there is no B specified in Table 14-1 and so this step must be omitted. There may be trailing zero
```
padding bits remaining after all segments are decoded in Step 4, below; if so, ignore them.
```
5. Separate the bits of the binary encoding into segments according to the "bit position" row of the coding table. For each segment, decode
the bits to obtain a character string that will be used as a portion of the final URI. The method for decoding each column depends on the
"coding method" row of the table. If the "coding method" row specifies a specific bit string, the corresponding bits of the input must
```
match those bits exactly; if not, stop: this binary encoding cannot be decoded. Otherwise, consult the following sections that specify the
```
decoding methods. If the decoding of any segment fails, stop: this binary encoding cannot be decoded.
6. For a variable-length coding segment, the coding method is applied beginning with the bit following the bits consumed by the previous
```
coding column. That is, if the previous coding column (the column to the left of this one) consumed bits up to and including bit bi, then
```
the most significant bit for decoding this segment is bit bi-1 . The coding method will determine where the ending bit for this segment is.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 163 of 448
7. Concatenate the following strings to obtain the final URI: the string urn:epc:tag:,the scheme name as specified in the coding table,
```
a colon (":") character, and the strings obtained in Step 4, inserting a dot (".") character between adjacent strings.
```
The following sections specify the procedures to be used in Step 4.
14.4.1 "Integer" Decoding method
The Integer decoding method is used for a segment that appears as a decimal integer in the URI, and as a binary integer in the binary
encoding.
```
Input:
```
The input to the decoding method is the bit string identified in the "bit position" row of the coding table.
Validity Test:
There are no validity tests for this decoding method.
```
Output:
```
The decoding of this segment is a decimal numeral whose value is the value of the input considered as an unsigned binary integer. The
output shall not begin with a zero character if it is two or more digits in length.
14.4.2 "String" Decoding method
The String decoding method is used for a segment that appears as an alphanumeric string in the URI, and as an ISO/IEC 646 [ISO646]
```
(ASCII) encoded bit string in the binary encoding.
```
```
Input:
```
The input to the decoding method is the bit string identified in the "bit position" row of the coding table. This length of this bit string is
always a multiple of seven.
Validity Test:
The input bit string must satisfy the following:
■ Each 7-bit segment must have a value corresponding to a character specified in Table A-1, or be all zeros.
■ All 7-bit segments following an all-zero segment must also be all zeros.
```
■ The first 7-bit segment must not be all zeros. (In other words, the string must contain at least one character.)
```
If any of the above tests fails, the decoding of the segment fails.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 164 of 448
```
Output:
```
```
Translate each 7-bit segment, up to but not including the first all-zero segment (if any), into a single character or 3-charcter escape triplet
```
by looking up the 7-bit segment in Table A-1, and using the value found in the "URI Form" column. Concatenate the characters and/or 3-
character triplets in the order corresponding to the input bit string. The resulting character string is the output. This character string
matches the GS3A3 production of the grammar in Section 5.
14.4.3 "Partition Table" Decoding method
The Partition Table decoding method is used for a segment that appears in the URI as a pair of variable-length numeric fields separated by
```
a dot (".") character, and in the binary encoding as a 3-bit "partition" field followed by two variable length binary integers. The number of
```
characters in the two URI fields always totals to a constant number of characters, and the number of bits in the binary encoding likewise
totals to a constant number of bits.
The Partition Table decoding method makes use of a "partition table." The specific partition table to use is specified in the coding table for a
given EPC scheme.
```
Input:
```
The input to the decoding method is the bit string identified in the "bit position" row of the coding table. Logically, this bit string is divided
into three substrings, consisting of a 3-bit "partition" value, followed by two substrings of variable length.
Validity Test:
The input must satisfy the following:
■ The three most significant bits of the input bit string, considered as a binary integer, must match one of the values specified in the "partition
value" column of the partition table. The corresponding row is called the "matching partition table row" in the remainder of the decoding
procedure.
■ Extract the M next most significant bits of the input bit string following the three partition bits, where M is the value specified in the "Company
Prefix Bits" column of the matching partition table row. Consider these M bits to be an unsigned binary integer, C. The value of C must be less
```
than 10L, where L is the value specified in the "GS1 Company Prefix Digits (L)" column of the matching partition table row.
```
■ There are N bits remaining in the input bit string, where N is the value specified in the other field bits column of the matching partition table row.
Consider these N bits to be an unsigned binary integer, D. The value of D must be less than 10K, where K is the value specified in the other field
```
digits (K) column of the matching partition table row. Note that if K = 0, then the value of D must be zero.
```
```
Output:
```
Construct the output character string by concatenating the following three components:
```
■ The value C converted to a decimal numeral, padding on the left with zero ("0") characters to make L digits in total.
```
```
■ A dot (".") character.
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 165 of 448
```
■ The value D converted to a decimal numeral, padding on the left with zero ("0") characters to make K digits in total. If K = 0, append no
```
```
characters to the dot above (in this case, the final URI string will have two adjacent dot characters when this segment is combined with the
```
```
following segment).
```
14.4.4 "Unpadded Partition Table" Decoding method
The Unpadded Partition Table decoding method is used for a segment that appears in the URI as a pair of variable-length numeric fields
```
separated by a dot (".") character, and in the binary encoding as a 3-bit "partition" field followed by two variable length binary integers.
```
The number of characters in the two URI fields is always less than or equal to a known limit, and the number of bits in the binary encoding
is always a constant number of bits.
The Unpadded Partition Table decoding method makes use of a "partition table." The specific partition table to use is specified in the coding
table for a given EPC scheme.
```
Input:
```
The input to the decoding method is the bit string identified in the "bit position" row of the coding table. Logically, this bit string is divided
into three substrings, consisting of a 3-bit "partition" value, followed by two substrings of variable length.
Validity Test:
The input must satisfy the following:
■ The three most significant bits of the input bit string, considered as a binary integer, must match one of the values specified in the "partition value"
column of the partition table. The corresponding row is called the "matching partition table row" in the remainder of the decoding procedure.
■ Extract the M next most significant bits of the input bit string following the three partition bits, where M is the value specified in the "Company
Prefix Bits" column of the matching partition table row. Consider these M bits to be an unsigned binary integer, C. The value of C must be less than
```
10L, where L is the value specified in the "GS1 Company Prefix Digits (L)" column of the matching partition table row.
```
■ There are N bits remaining in the input bit string, where N is the value specified in the other field bits column of the matching partition table row.
Consider these N bits to be an unsigned binary integer, D.
```
Output:
```
Construct the output character string by concatenating the following three components:
```
■ The value C converted to a decimal numeral, padding on the left with zero ("0") characters to make L digits in total.
```
```
■ A dot (".") character.
```
```
■ The value D converted to a decimal numeral, with no leading zeros (except that if D = 0 it is converted to a single zero digit).
```
14.4.5 "String Partition Table" Decoding method
The String Partition Table decoding method is used for a segment that appears in the URI as a variable-length numeric field and a variable-
```
length string field separated by a dot (".") character, and in the binary encoding as a 3-bit "partition" field followed by a variable length
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 166 of 448
binary integer and a variable length binary-encoded character string. The number of characters in the two URI fields is always less than or
```
equal to a known limit (counting a 3-character escape sequence as a single character), and the number of bits in the binary encoding is
```
padded if necessary to a constant number of bits.
The Partition Table decoding method makes use of a "partition table." The specific partition table to use is specified in the coding table for a
given EPC scheme.
```
Input:
```
The input to the decoding method is the bit string identified in the "bit position" row of the coding table. Logically, this bit string is divided
into three substrings, consisting of a 3-bit "partition" value, followed by two substrings of variable length.
Validity Test:
The input must satisfy the following:
■ The three most significant bits of the input bit string, considered as a binary integer, must match one of the values specified in the "partition
value" column of the partition table. The corresponding row is called the "matching partition table row" in the remainder of the decoding
procedure.
■ Extract the M next most significant bits of the input bit string following the three partition bits, where M is the value specified in the "Company
Prefix Bits" column of the matching partition table row. Consider these M bits to be an unsigned binary integer, C. The value of C must be less
```
than 10L, where L is the value specified in the "GS1 Company Prefix Digits (L)" column of the matching partition table row.
```
■ There are N bits remaining in the input bit string, where N is the value specified in the other field bits column of the matching partition table row.
These bits must consist of one or more non-zero 7-bit segments followed by zero or more all-zero bits.
```
■ The number of non-zero 7-bit segments that precede the all-zero bits (if any) must be less or equal to than K, where K is the value specified in
```
the "Maximum Characters" column of the matching partition table row.
■ Each of the non-zero 7-bit segments must have a value corresponding to a character specified in Table A-1.
```
Output:
```
Construct the output character string by concatenating the following three components:
```
■ The value C converted to a decimal numeral, padding on the left with zero ("0") characters to make L digits in total.
```
```
■ A dot (".") character.
```
■ A character string determined as follows. Translate each non-zero 7-bit segment as determined by the validity test into a single character or 3-
character escape triplet by looking up the 7-bit segment in Table A-1, and using the value found in the "URI Form" column. Concatenate the
characters and/or 3-character triplet in the order corresponding to the input bit string.
14.4.6 "Numeric String" Decoding method
The Numeric String decoding method is used for a segment that appears as a numeric string in the URI, possibly including leading zeros.
The leading zeros are preserved in the binary encoding by prepending a "1" digit to the numeric string before encoding.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 167 of 448
```
Input:
```
The input to the decoding method is the bit string identified in the "bit position" row of the coding table.
Validity Test:
The input must be such that the decoding procedure below does not fail.
```
Output:
```
Construct the output string as follows.
■ Convert the input bit string to a decimal numeral without leading zeros whose value is the value of the input considered as an unsigned binary
integer.
■ If the numeral from the previous step does not begin with a "1" character, stop: the input is invalid.
```
■ If the numeral from the previous step consists only of one character, stop: the input is invalid (because this would correspond to an empty
```
```
numeric string).
```
■ Delete the leading "1" character from the numeral.
■ The resulting string is the output.
14.4.7 "6-Bit CAGE/DoDAAC" Decoding method
The 6-Bit CAGE/DoDAAC decoding method is used for a segment that appears as a 5-character CAGE code or 6-character DoDAAC code in
the URI, and as a 36-bit encoded bit string in the binary encoding.
```
Input:
```
The input to the decoding method is the bit string identified in the "bit position" row of the coding table. This length of this bit string is
always 36 bits.
Validity Test:
The input bit string must satisfy the following:
■ When the bit string is considered as consisting of six 6-bit segments, each 6-bit segment must have a value corresponding to a character
```
specified in Table G-1 (G) except that the first 6-bit segment may also be the value 100000.
```
■ The first 6-bit segment must be the value 100000, or correspond to a digit character, or an uppercase alphabetic character excluding the letters I
and O.
■ The remaining five 6-bit segments must correspond to a digit character or an uppercase alphabetic character excluding the letters I and O.
If any of the above tests fails, the decoding of the segment fails.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 168 of 448
```
Output:
```
Disregard the first 6-bit segment if it is equal to 100000. Translate each of the remaining five or six 6-bit segments into a single character
```
by looking up the 6-bit segment in Table G-1 (G) and using the value found in the "URI Form" column. Concatenate the characters in the
```
order corresponding to the input bit string. The resulting character string is the output. This character string matches the
CAGECodeOrDODAAC production of the grammar in Section 6.3.17.
14.4.8 "6-Bit Variable String" Decoding method
The 6-Bit Variable String decoding method is used for a segment that appears in the URI as a variable-length string field, and in the binary
encoding as a variable-length null-terminated binary-encoded character string.
```
Input:
```
The input to the decoding method is the bit string that begins in the next least significant bit position following the previous coding
segment. Only a portion of this bit string is consumed by this decoding method, as described below.
Validity Test:
The input must be such that the decoding procedure below does not fail.
```
Output:
```
Construct the output string as follows.
■ Beginning with the most significant bit of the input, divide the input into adjacent 6-bit segments, until a terminating segment consisting of all
```
zero bits (000000) is found. If the input is exhausted before an all-zero segment is found, stop: the input is invalid.
```
■ The number of 6-bit segments preceding the terminating segment must be greater than or equal to the minimum number of characters and less
than or equal to the maximum number of characters specified in the footnote to the coding table for this coding table column. If not, stop: the
input is invalid.
```
■ For each 6-bit segment preceding the terminating segment, consult Table G-1 (G) to find the character corresponding to the value of the 6-bit
```
segment. If there is no character in the table corresponding to the 6-bit segment, stop: the input is invalid.
■ If the input violates any other constraint indicated in the coding table, stop: the input is invalid.
■ Translate each 6-bit segment preceding the terminating segment into a single character or 3-character escape triplet by looking up the 6-bit
```
segment in Table G-1 (G) and using the value found in the "URI Form" column. Concatenate the characters and/or 3-character triplets in the
```
order corresponding to the input bit string. The resulting string is the output of the decoding procedure.
■ If any columns remain in the coding table, the decoding procedure for the next column resumes with the next least significant bit after the
terminating 000000 segment.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 169 of 448
14.4.9 "6-Bit Variable String Partition Table" Decoding method
The 6-Bit Variable String Partition Table decoding method is used for a segment that appears in the URI as a variable-length numeric field
```
and a variable-length string field separated by a dot (".") character, and in the binary encoding as a 3-bit "partition" field followed by a
```
variable length binary integer and a null-terminated binary-encoded character string. The number of characters in the two URI fields is
```
always less than or equal to a known limit (counting a 3-character escape sequence as a single character), and the number of bits in the
```
binary encoding is also less than or equal to a known limit.
The 6-Bit Variable String Partition Table decoding method makes use of a "partition table." The specific partition table to use is specified in
the coding table for a given EPC scheme.
```
Input:
```
The input to the decoding method is the bit string identified in the "bit position" row of the coding table. Logically, this bit string is divided
into three substrings, consisting of a 3-bit "partition" value, followed by two substrings of variable length.
Validity Test:
The input must satisfy the following:
■ The three most significant bits of the input bit string, considered as a binary integer, must match one of the values specified in the "partition
value" column of the partition table. The corresponding row is called the "matching partition table row" in the remainder of the decoding
procedure.
■ Extract the M next most significant bits of the input bit string following the three partition bits, where M is the value specified in the "Company
Prefix Bits" column of the matching partition table row. Consider these M bits to be an unsigned binary integer, C. The value of C must be less
```
than 10L, where L is the value specified in the "GS1 Company Prefix Digits (L)" column of the matching partition table row.
```
■ There are up to N bits remaining in the input bit string, where N is the value specified in the other field maximum bits column of the matching
partition table row. These bits must begin with one or more non-zero 6-bit segments followed by six all-zero bits. Any additional bits after the six
all-zero bits belong to the next coding segment in the coding table.
■ The number of non-zero 6-bit segments that precede the all-zero bits must be less or equal to than K, where K is the value specified in the
"Maximum Characters" column of the matching partition table row.
```
■ Each of the non-zero 6-bit segments must have a value corresponding to a character specified in Table G-1 (G)
```
```
Output:
```
Construct the output character string by concatenating the following three components:
```
■ The value C converted to a decimal numeral, padding on the left with zero ("0") characters to make L digits in total.
```
```
■ A dot (".") character.
```
■ A character string determined as follows. Translate each non-zero 6-bit segment as determined by the validity test into a single character or 3-
```
character escape triplet by looking up the 6-bit segment in Table G-1 (G) and using the value found in the "URI Form" column. Concatenate the
```
characters and/or 3-character triplet in the order corresponding to the input bit string.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 170 of 448
14.4.10 "Fixed Width Integer" Decoding method
The Integer decoding method is used for a segment that appears as a zero-padded decimal integer in the URI, and as a binary integer in
the binary encoding.
```
Input:
```
The input to the decoding method is the bit string identified in the "bit position" row of the coding table.
Validity Test:
Given a sequence of bits of length b, calculate i max as follows:
```
D = int(b*log(2)/log(10))
```
```
imax = 10^D – 1
```
Interpret the sequence of bits of length b as a non-negative integer value, i
If i > i max then decoding fails because the bits correspond to a value that cannot be expressed in D digits.
```
Output:
```
The decoding of this segment is a decimal numeral whose value is the value of the input considered as an unsigned binary integer. The
```
output is padded to the left, so that the total number of digits D is given by D=int(b*log(2)/log(10)).
```
14.5 Encoding/Decoding methods introduced in TDS 2.0
TDS 2.0 introduces several new binary encoding/decoding methods that are used both within the construction and parsing of the new EPC
identifiers as well as for the expression of additional AIDC data beyond the end of the EPC identifier, as summarised in the table below and
detailed in the following subsections, which explain the encoding and decoding methods for each:
Table 14-2 Summary of Encoding/Decoding methods introduced in TDS 2.0
Method name Section Used within binary encoding of
new EPC identifiers
Used within binary encoding of '+AIDC data'
"+AIDC Data Toggle Bit" 14.5.1 Yes – to indicate whether
additional AIDC data follows
after the EPC identifier
No
```
"Fixed-Bit-Length Numeric String" 14.5.2 Yes – for filter value Yes – e.g. for (20) Internal Product Variant
```
"Prioritised Date" 14.5.3 Yes – within DSGTIN+ or
DSGTIN++
No
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 171 of 448
Method name Section Used within binary encoding of
new EPC identifiers
Used within binary encoding of '+AIDC data'
"Fixed-Length Numeric" 14.5.4 Yes for most primary GS1
```
identification keys (e.g. GTIN,
```
```
SSCC etc.). Not used by GIAI or
```
CPI
Yes – when expressing additional GS1 identification keys within
```
+AIDC data (e.g. expressing a GRAI in conjunction with an
```
```
SGTIN+ EPC)
```
"Delimited/Terminated Numeric" 14.5.5 Yes – used for GIAI or CPI Yes – used for GIAI or CPI
```
"Variable-length alphanumeric" 14.5.6 Yes – e.g. for (21) Serial
```
Number within SGTIN+,
SGTIN++, DSGTIN+,
DSGTIN++, ITIP+
```
Yes – e.g. for (10) Batch/Lot Number
```
"Variable-length numeric string" 14.5.6.1 Yes – if value uses only 0-9
```
(leading zero digits are
```
```
preserved)
```
```
Yes – if value uses only 0-9 (leading zero digits are preserved)
```
"Variable-length upper case
hexadecimal"
14.5.6.2 Yes – if value uses only
characters 0123456789ABCDEF
Yes – if value uses only characters 0123456789ABCDEF
"Variable-length lower case
hexadecimal"
14.5.6.3 Yes – if value uses only
characters 0123456789abcdef
Yes – if value uses only characters 0123456789abcdef
"Variable-length 6-bit file-safe
URI-safe base 64"
14.5.6.4 Yes – if value uses only
characters 0-9 A-Z a-z hyphen
or underscore
Yes – if value uses only characters 0-9 A-Z a-z hyphen or
underscore
"Variable-length URN Code 40" 14.5.6.5 Yes – if value uses only 0-9 A-Z
colon, dot or hyphen
Yes – if value uses only 0-9 A-Z colon, dot or hyphen
"Variable-length 7-bit ASCII" 14.5.6.6 Yes – if value contains
characters within the 82-
character GS1 invariant subset
of [ISO646] OTHER than digits
0-9 or letters A-Z a-z or hyphen,
or underscore.
Yes – if value contains characters within the 82-character GS1
invariant subset of [ISO646] OTHER than digits 0-9 or letters
A-Z a-z or hyphen, or underscore.
```
"Single data bit" 14.5.7 No Yes – e.g. for AI (4321), (4322), (4323)
```
"6-digit date YYMMDD" 14.5.8 No – but see Prioritised Date
within DSGTIN+ or DSGTIN++,
section 14.5.3
```
Yes – e.g. for AI (17)
```
"10-digit date+time
YYMMDDhhmm"
```
14.5.9 No Yes – e.g. for AI (4324), (4325), (7003)
```
"Variable-format date / date
range"
```
14.5.10 No Yes – e.g. for AI (7007) = Harvest date / Harvest date range
```
```
"Variable-precision date+time" 14.5.11 No Yes – e.g. for AI (8008) = Production date+time
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 172 of 448
Method name Section Used within binary encoding of
new EPC identifiers
Used within binary encoding of '+AIDC data'
```
"Country code (ISO 3166-1
```
```
alpha-2)"
```
```
14.5.12 No Yes –for AI (4307) and (4317)
```
"Variable-length numeric string
without encoding indicator"
```
14.5.13 Yes – in CPI+ and SGCN+ Yes – for (255),(30),(37),
```
```
(3900)-(3909), (3910)-(3919), (3920)-(3929), (3930)-(3939),
```
```
(423), (425), (7004), (8011) and (8019)
```
```
"Optional minus sign in 1 bit" 14.5.14 No Yes - for (4330) and (4331).
```
```
"Sequence indicator" 14.5.15 No Yes - for (7258).
```
"Custom domain name or
hostname"
14.5.16 Yes – in SGTIN++ and
DSGTIN++ and other ‘++’
schemes introduced in TDS 2.3.
No
14.5.1 "+AIDC Data Toggle Bit"
The Data Toggle Bit encoding method is used for a segment that appears as a single bit in the binary encoding that indicates whether or not
additional AIDC data is encoded after the EPC within the EPC/UII memory bank. This is primarily useful for 'Select' filtering over the air
interface.
The data toggle bit is a single bit that appears immediately after the 8-bit header of the new EPC schemes and before the 3-bit filter value.
Whoever / whatever encodes an EPC identifier into an RFID tag has the responsibility to set the +AIDC data toggle bit correctly. Note that
the +AIDC data toggle bit is primarily used for selection of tag populations via the air interface and a non-essential role in the decoding
procedure if the guidance at the end of Section 15.3 is followed, to determine whether or not any additional +AIDC data has been encoded
after the end of the EPC identifier.
If no additional AIDC data is encoded, the data toggle bit SHALL be set to 0.
If additional AIDC is encoded, the data toggle bit SHALL be set to 1.
The figure below shows an example of the use of the +AIDC data toggle bit.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 173 of 448
Figure 14-1 Example of the use of the +AIDC data toggle bit
14.5.1.1 Encoding:
```
Input:
```
The input to the encoding method is a Boolean value, in which:
```
true = additional AIDC data is to be encoded after the EPC within the EPC/UII memory bank
```
```
false = no additional AIDC data is to be encoded after the EPC within the EPC/UII memory bank
```
Validity Test:
The input must be either true or false, otherwise the encoding fails.
```
Output:
```
The encoding of this segment is a single bit, in which true is encoded as 1 while false is encoded as 0.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 174 of 448
14.5.1.2 Decoding:
```
Input:
```
The input to the decoding method is a single bit, which is interpreted as follows:
1 = additional AIDC data is to be encoded after the EPC within the EPC/UII memory bank
0 = no additional AIDC data is to be encoded after the EPC within the EPC/UII memory bank
Validity Test:
The output must be either true or false, otherwise the decoding fails.
```
Output:
```
```
The encoding of this segment is a Boolean value, in which 0 is interpreted as false (i.e. no additional AIDC data is to be encoded after the
```
```
EPC within the EPC/UII memory bank ), whereas 1 is interpreted as true (i.e. additional AIDC data is to be encoded after the EPC within the
```
```
EPC/UII memory bank). If the +AIDC data toggle bit is set to 1, then refer to section 15.3 for further details about extraction of AIDC data
```
that follows after new EPC schemes within the EPC/UII memory bank.
14.5.2 "Fixed-Bit-Length Numeric String"
The Fixed-Bit-Length Numeric String encoding method is used for a segment that can represent numeric digits 0-9 using approximately
3.32 bits per digit,. When this method is used to encode the value of a GS1 Application Identifier, it is necessary to use Table F to
determine the expected bit length, by locating the row for which the GS1 Application Identifier key is shown in column a, then reading the
expected bit length from column e.
14.5.2.1 Encoding
```
Input:
```
The input to the encoding method is a numeric string consisting only of digits 0-9. The expected number of bits must be determined from
```
Table F (see introduction above).
```
Validity Test:
```
The input must be a numeric string consisting only of digits 0-9, otherwise the encoding fails. Leading digits of zero ('0') are permitted and
```
SHALL be reinstated upon decoding.
```
Output:
```
Convert the base 10 value to binary and if necessary left-pad with '0' bits to reach the expected bit length. This is the output of this
encoding method.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 175 of 448
14.5.2.2 Decoding
```
Input:
```
```
The input to the decoding method is a fixed-length binary string of N bits, where N is determined from Table F (see introduction above)
```
unless this method is being used to decode the filter value as 3 bits.
Validity Test:
The output must be a numeric string consisting only of digits 0-9.
```
Output:
```
Read N bits and convert the value to an unsigned base 10 integer. Refer to Table F to determine the expected length in digits, shown in
column d for the row that includes the GS1 Application Identifier key in column a. Convert the base 10 integer value to a numeric string
and if necessary, left-pad with digits of '0' to reach the expected number of digits, as shown in column d of Table F. The result is the output
of this decoding method.
14.5.3 "Prioritised Date"
The Prioritised Date encoding method is used within the DSGTIN+ or DSGTIN++ schemes for a segment that represents a date value in a
```
well-defined position within the binary string (irrespective of the length or character set used for the serial number), to support air interface
```
filtering on a date of interest. This is particularly useful to enable efficient scanning of perishable items with limited remaining shelf life or to
ensure that all expired / expiring products have been removed from sale. The prioritised date format only supports 6-digit date values
```
(YYMMDD) and includes a four-bit date type indicator to express the meaning of the value – whether it corresponds to (11) production date,
```
```
(17) expiration date, (7007) harvest date, (16) sell-by date etc, as illustrated in the figure below.
```
Figure 14-2 Prioritised date format support for 6-digit date values
Within the binary encoding of the DSGTIN+ or DSGTIN++ schemes, the 4-bit date type indicator appears immediately after the filter bits,
i.e. 12 bits after the start of the EPC, starting at 2C h .
Its 4-bit string value must be one of the values shown in the table below. All other values are reserved for future use.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 176 of 448
GS1 Application Identifier 4-bit string for date type indicator
```
(11) Production date 0000
```
```
(13) Packaging date 0001
```
```
(15) Best before date 0010
```
```
(16) Sell by date 0011
```
```
(17) Expiration date 0100
```
```
(7006) First freeze date 0101
```
```
(7007) Harvest date 0110
```
14.5.3.1 Encoding
```
Input:
```
The input to the encoding method is a date-related GS1 Application Identifier and a 6-digit numeric string representing a date value in the
format YYMMDD, as expected in the GS1 General Specifications.
Validity Test:
The GS1 Application Identifier must appear listed within the table above and the 6-digit numeric string must only consist of digits 0-9 and is
further constrained to be a plausible date value, meaning that the third and fourth digits are always in the range 01-12 and the fifth and
sixth digits are always in the range 00-31 and do not indicate a day-of-month value that is greater than the number of days in the month
indicated by the third and fourth Digits. e.g. if the third and fourth digits are "09" then a value of "31" for the fifth and sixth digits would be
invalid because September can only contain 30 days.
```
Output:
```
Create an empty binary string buffer to receive the output. Lookup the GS1 Application Identifier in the table below and append the
corresponding four bits to the binary string buffer as the date type indicator.
Consider the input string as pairs of digits in which the first two digits are YY, the next two digits are MM and the final two digits are DD.
```
Convert YY to a decimal integer (e.g. '22'  22 ) and convert this to an unsigned binary value, then if the resulting binary string for YY is
```
less than seven bits in length, pad to the left with bits set to '0' to reach a total of seven bits. Append these seven bits to the binary string
buffer.
```
Convert MM to a decimal integer (e.g. '05'  5 ) and convert this to an unsigned binary value, then if the resulting binary string for MM is
```
less than four bits in length, pad to the left with bits set to '0' to reach a total of four bits. Append these four bits to the binary string
buffer.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 177 of 448
```
Convert DD to a decimal integer (e.g. '31'  31 ) and convert this to an unsigned binary value, then if the resulting binary string for DD is
```
less than five bits in length, pad to the left with bits set to '0' to reach a total of five bits. Append these five bits to the binary string buffer.
The binary string buffer should now consist of a total of 20 bits and should be considered as the output of this encoding method.
14.5.3.2 Decoding
```
Input:
```
The input to the decoding method is a binary string of 20 bits.
Validity Test:
The left-most four bits must appear in the date table above, to indicate a specific date type, otherwise encoding fails. The next sixteen bits
will be decoded as a 6-digit numeric string representing a date formatted as YYMMDD. After decoding, the third and fourth digits are always
in the range 01-12 and the fifth and sixth digits are always in the range 00-31 and do not indicate a day-of-month value that is greater than
the number of days in the month indicated by the third and fourth Digits. e.g. if the third and fourth digits are "09" then a value of "31" for
the fifth and sixth digits would be invalid because September can only contain 30 days.
```
Output:
```
Lookup the left-most four bits in the table above to identify the GS1 Application Identifier to which the YYMMDD value corresponds.
Create an empty string buffer to receive the six-digit output value YYMMDD.
Treat the remaining sixteen bits as an encoding of the value.
Working from left to right, read the next 7 bits as unsigned binary integer y, then convert to a base 10 value YY, padding to the left with a
single '0' digit if the initial result after conversion to base 10 was in the range 0-9.
Read the next 4 bits as unsigned binary integer m, then convert to a base 10 value MM, padding to the left with a single '0' digit if the initial
result after conversion to base 10 was in the range 0-9.
Read the next 5 bits as unsigned binary integer d, then convert to a base 10 value DD, padding to the left with a single '0' digit if the initial
result after conversion to base 10 was in the range 0-9.
Check that MM is within the range 01-12 and that DD is within the range 00-31 and does not exceed the number of days in the month for
the month indicated by MM. Otherwise decoding fails.
Concatenate YY MM and DD in sequence as the output value YYMMDD for the date-related GS1 Application Identifier identified by the date
```
type indicator (the left-most four bits of the binary input string).
```
14.5.4 "Fixed-Length Numeric"
The Fixed-Length Numeric encoding method is used for a segment that can represent numeric digits 0-9 using 4 bits per digit/character,
```
preserving leading zero digits and (where possible) aligning with nibble (half-byte) boundaries to support air interface filtering on a known
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 178 of 448
```
sequence of digits (such as a known GS1 Company Prefix), irrespective of any initial indicator digit or extension digit that may be present.
```
The encoding and decoding methods use the following table:
Table 14-3 "Fixed-Length Numeric" encoding table
Numeric character 4-bit sequence
0 0000
1 0001
2 0010
3 0011
4 0100
5 0101
6 0110
7 0111
8 1000
9 1001
14.5.4.1 Encoding
```
Input:
```
The input to the encoding method is a fixed-length string of N characters, each of which is either a numeric digit in the range 0-9.
Validity Test:
The input must not contain any characters except for digits 0-9, otherwise the encoding fails.
```
Output:
```
Create an empty binary string buffer to receive the output. Working from left to right, consider each character of the input string. Lookup
the character in the table above and append the corresponding sequence of four bits to the binary string buffer. Continue until each
character of the input string has been processed. For an input string of N digits, the binary string buffer should now contain 4N bits and is
considered to be the output of this encoding method.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 179 of 448
14.5.4.2 Decoding
```
Input:
```
The input to the decoding method is a fixed-length binary string of 4N bits, considered as a concatenation of N groups of 4-bit sequences
Validity Test:
Each of the 4-bit sequences in the input must appear within the table above, otherwise decoding fails. The output must not contain any
characters except for digits 0-9, otherwise the decoding fails
```
Output:
```
Create an empty string buffer to receive the numeric string output. Working from left to right, consider each set of four bits of the input
string, moving the cursor to the right by four bits each time. Lookup the four bit sequence in the table above and append the corresponding
character to the output string buffer. Continue until no further bits remain to be processed in the binary input string. For a binary input
string of 4N bits, the output string buffer should now contain N digits 0-9 and is considered to be the output of this decoding method.
14.5.5 "Delimited/Terminated Numeric"
The Delimited/Terminated 4-bit Integer encoding method is used for a segment that can represent a variable-length string that begins with
```
numeric digits 0-9, preserving leading zero digits and (where possible) aligning with nibble (half-byte) boundaries to support air interface
```
filtering on a known sequence of digits, irrespective of any initial indicator digit or extension digit that may be present.
If the string contains no characters except digits 0-9, a 4-bit terminator '1111' indicates the end of the string.
If the string contains characters other than numeric digits 0-9, a 4-bit delimiter indicates the end of the initial all-numeric substring, with
```
the remainder of the string (starting with the first character that is not a digit 0-9) being encoded using the variable-length alphanumeric
```
method.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 180 of 448
Figure 14-3 Example of numeric delimiter and terminator
The encoding and decoding methods use the following table for all of the initial digits:
Table 14-4 Encoding table for initial digits of "Delimited/Terminated Numeric" encoding method
Numeric character 4-bit sequence Interpretation
0 0000 Numeric digit '0'
1 0001 Numeric digit '1'
2 0010 Numeric digit '2'
3 0011 Numeric digit '3'
4 0100 Numeric digit '4'
5 0101 Numeric digit '5'
6 0110 Numeric digit '6'
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 181 of 448
Numeric character 4-bit sequence Interpretation
7 0111 Numeric digit '7'
8 1000 Numeric digit '8'
9 1001 Numeric digit '9'
```
Delimiter 1110 End of the initial all-numeric substring; the remainder
```
of the string uses the variable-length alphanumeric –
see section 14.5.6 and its subsections.
Terminator 1111 End of a string that is all-numeric
14.5.5.1 Encoding
```
Input:
```
The input to the encoding method is a string of characters, either consisting only of digits 0-9 or with an initial substring that consists only
of digits 0-9.
Validity Test:
The input must begin with a sequence of numeric digits 0-9, preserving leading zero digits, but may be followed by a string of alphanumeric
or symbol characters that are permitted for the value of this GS1 Application Identifier.
```
Output:
```
Create an empty binary string buffer to receive the output. Working from left to right, consider each character of the input string. If the
character is a digit 0-9, lookup the
Lookup the digit in the table below and append the corresponding sequence of four bits to the binary string buffer. Continue until each
character of the input string has been processed. Finally, if no variable-length alphanumeric segment follows, append a terminator
```
sequence of four bits ('1111') otherwise, if a variable-length alphanumeric segment follows, append a delimiter sequence of four bits
```
```
('1110'). For an input string of N digits, the binary string buffer should now contain (4N+4) bits and is considered to be the output of this
```
encoding method. If the input string was not all-numeric, the binary string buffer should be further appended with the output of applying
the variable-length alphanumeric method to the remaining characters– see section 14.5.6
14.5.5.2 Decoding
```
Input:
```
The input to the encoding method is a binary string
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 182 of 448
Validity Test:
The output must begin with a sequence of numeric digits 0-9, preserving leading zero digits, but may be followed by a string of
alphanumeric or symbol characters that are permitted for the value of this GS1 Application Identifier.
```
Output:
```
Create an empty string buffer to receive the output. Working from left to right, consider each excessive group of four bits as a hexadecimal
character.
```
If the four bits correspond to a digit 0-9, append this character to the output buffer. If the four bits are '1111' (hexadecimal character F),
```
```
the final terminator has been read and indicates the end of an all-numeric value; the output is the all-numeric contents of the output string
```
```
buffer. If the four bits are '1110' (hexadecimal character E), the delimiter character has now been read, indicating that the next character
```
is not a digit but instead decoding switches after reading the delimiter '1110' to the variable-length alphanumeric method and the next bits
```
are a 3-bit encoding indicator, followed by a length indicator (see column g of Table F). The final output consists of the all-numeric contents
```
of the output string buffer from this method, concatenated with with the output of the variable length alphanumeric method used to decode
the remaining bits.
14.5.6 "Variable-length alphanumeric"
The Variable-length Alphanumeric encoding method is used to encode variable-length alphanumeric strings using the minimum number of
bits. This requires knowledge of the length of the string to be encoded, as well as analysis of the character set required to express the
value. Shorter lengths and more restricted character sets result in fewer bits.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 183 of 448
Figure 14-4 Examples of "Variable-length alphanumeric" encoding method
When encoding, implementations may use the decision tree below, to determine the most efficient encoding method to use, based on the
characters actually present in the value to be encoded, then use that method specified in the relevant subsection. Having said that, a tag
that is encoded using a less efficient encoding method may still conform to TDS 2.0 provided that the actual encoding method used has
been correctly indicated via the three encoding indicator bits.
```
When decoding, the first three bits are the encoding indicator. Refer to the decision tree flowchart or Table E (encoding indicator values) to
```
determine which subsection to use for the value of the encoding indicator.
Although the decision tree flowchart and Table E provide guidance about which encoding method is likely to require the fewest bits for the
actual value being encoded, the use of a less efficient encoding method is permitted, provided that the encoding indicator is set correctly.
```
Note also that although the "Variable-length URN Code 40 (§14.5.6.5) method is slightly more efficient (at 16 bits per 3 characters) than
```
```
the "Variable-length 6-bit file-safe URI-safe base 64 (§14.5.6.4) method (at 6 bits per character), there are situations where use of the
```
latter may result in fewer bits, particularly if the length of the value is less than 3 characters or if it is less than 14 characters and not an
```
exact multiple of 3 characters. For values longer than 13 characters, "Variable-length URN Code 40 (§14.5.6.5) may be more efficient, if its
```
more restricted character set is sufficient to express the value being encoded.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 184 of 448
Figure 14-5 Decision tree flowchart to select the most efficient encoding method based on the value being encoded
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 185 of 448
Table E – lists the permitted values for encoding indicator together with the encoding methods and the character ranges supported by
each method
3-bit encoding
indicator
Coding method name Defined in
TDS section
Supported characters Number of bits per character
000 = 0 Variable-length numeric
string
14.5.6.1 0-9 ≈ 3.32 bits per digit, rounded up to next integer
001 = 1 Variable-length upper
case hexadecimal
14.5.6.2 0-9 A-F 4 bits per digit or hexadecimal character
010 = 2 Variable-length lower
case hexadecimal
14.5.6.3 0-9 a-f 4 bits per digit or hexadecimal character
011 = 3 Variable-length file-safe
URI-safe base 64
14.5.6.4 0-9 A-Z a-z _ - 6 bits per character
100 = 4 Variable-length 7-bit
ASCII
14.5.6.6 All 82 characters within GS1
Gen Specs Fig 7.11-1
OR
All 39 characters within GS1
Gen Specs Fig 7.11-2
7 bits per character
101 = 5 Variable-length URN Code
40
```
14.5.6.5 0-9 A-Z . : - ≈ 5.33 bits per character (16 bits per 3 characters)
```
110 = 6 Reserved for future
use
111 = 7 Reserved for encoding
indicators longer than
3 bits
14.5.6.1 "Variable-length numeric string"
The Variable-length numeric string encoding method is used to encode variable-length numeric strings as unsigned binary integers using the
minimum number of bits. It preserves leading zeros, since the decoding method is required to left-pad the decoded integer to the number
of digits indicated by the length indicator that was encoded. This method requires knowledge of L, the length of the string to be encoded,
as well as L max, the maximum permitted length for such a string.
```
Note: this is similar to the Fixed-Bit-Length Numeric String method (§14.5.2) except that the binary value is appended after appropriate
```
```
encoding indicator (three bits set to 000) and length indicator.
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 186 of 448
14.5.6.1.1 Encoding
```
Input:
```
The input to the encoding method is a numeric string of length L consisting only of digits 0-9.
Validity Test:
If the input string contains characters other than digits 0-9 or length L > L max, encoding fails.
```
Output:
```
Create an empty binary string buffer to receive the output. Append three bits '000' to the binary string buffer, to set an encoding indicator
value of '0'.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Convert the actual length L from a base 10 integer to a binary value, then if necessary, pad to the left with bits of '0' to reach a total length
bLI for the binary string representing the length indicator.
If L max = 1, the binary string representing the length indicator is empty, of zero length.
Append the binary string representing the length indicator to the binary string buffer.
Convert the input string of L digits 0-9 to a base10 integer then convert this to an unsigned binary integer, v.
Calculate bv, the number of bits for expressing the value either via a lookup of L in table B and reading the value in the column titled
'Integer encoding' or using the following formula:
```
bv = ceiling(L*log(10)/log(2))
```
If necessary, pad the binary string v with bits of '0' to reach a total length b v for the binary string representing the numeric string value.
```
After any necessary padding, append binary string v (of length bv ) to the binary string buffer.
```
The contents of the binary string buffer is now the binary output of this encoding method.
14.5.6.1.2 Decoding
```
Input:
```
The input to the decoding method is a binary string for which the leftmost three bits must be '000'.
Validity Test:
If the leftmost three bits of the input binary string do not match '000', decoding fails.
If the output string contains characters other than digits 0-9 or if length L > Lmax, decoding fails.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 187 of 448
```
Output:
```
Create an empty binary string buffer to receive the output.
Read the first three bits of the input binary string as the encoding indicator and check that these match '000', otherwise this decoding
method cannot be used.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Read the next bLI bits of the binary input string as the length indicator and convert this binary value to an unsigned base 10 integer L, the
number of characters that are encoded. Within the binary input string, move the cursor past the b LI length indicator bits to begin decoding
the actual value.
Calculate bv, the number of bits for expressing the value either via a lookup of L in table B and reading the value in the column titled
'Integer encoding' or using the following formula:
```
bv = ceiling(L*log(10)/log(2))
```
Read the next bv bits from the binary string and convert this to an unsigned base 10 integer V.
Convert V to a numeric string. If V is fewer than L digits in length, left-pad V with digits of '0' to reach a total of L digits. The resulting L-
```
digit numeric string value V (with any necessary left-padding) is the output of this decoding method.
```
14.5.6.2 "Variable-length upper case hexadecimal"
The Variable-length upper case hexadecimal method is used to encode variable-length strings consisting of digits 0-9 and letters A-F as
unsigned binary integers using four bits per character. This requires knowledge of L, the length of the string to be encoded, as well as L max,
the maximum permitted length for such a string.
This method uses the following table to map each character 0-9 A-F to a 4 bit binary string:
Table 14-5 Mapping table for "Variable-length upper case hexadecimal" encoding method
Character 4-bit binary string Character 4-bit binary string
0 0000 8 1000
1 0001 9 1001
2 0010 A 1010
3 0011 B 1011
4 0100 C 1100
5 0101 D 1101
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 188 of 448
Character 4-bit binary string Character 4-bit binary string
6 0110 E 1110
7 0111 F 1111
14.5.6.2.1 Encoding
```
Input:
```
The input to the encoding method is a numeric string of length L consisting only of digits 0-9 or letters A-F.
Validity Test:
If the input string contains characters other than digits 0-9 or letters A-F or length L > L max, encoding fails.
```
Output:
```
Create an empty binary string buffer to receive the output. Append three bits '001' to the binary string buffer, to set an encoding indicator
value of '1'.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Convert the actual length L from a base 10 integer to a binary value, then if necessary, pad to the left with bits of '0' to reach a total length
bLI for the binary string representing the length indicator.
If L max = 1, the binary string representing the length indicator is empty, of zero length.
Append the binary string representing the length indicator to the binary string buffer.
Working from left to right across the input string, lookup each character in the table above and append the corresponding four bits to the
binary string buffer. Repeat until all L characters of the input string have been processed.
The contents of the binary string buffer is now the output of this encoding method.
14.5.6.2.2 Decoding
```
Input:
```
The input to the encoding method is a binary string whose leftmost three bits are '001', corresponding to an encoding indicator value '1' for
this method.
Validity Test:
If the input binary string does not begin with bits '001' this decoding method cannot be used.
If the output string contains characters other than digits 0-9 or letters A-F or is of length L > L max, decoding fails.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 189 of 448
```
Output:
```
Create an empty string buffer to receive the output.
Read three bits from the binary input string and check that these match '001', otherwise decoding fails. Within the binary input string,
advance the cursor beyond those leftmost three bits.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Read bLI bits from the binary input string and convert this unsigned integer value to base 10 value L, the number of characters that are to
be decoded. Within the binary input string, advance the cursor beyond the b LI length indicator bits. Repeat the follow procedure L times,
once per character to be decoded:
Read the next four bits from the binary input string and advance the cursor beyond the bits that have just been read. Lookup the four bits
in the table above and append the corresponding character to the output string buffer.
When L characters have been decoded, the contents of the output string buffer is the output of this decoding method.
14.5.6.3 "Variable-length lower case hexadecimal"
The Variable-length lower case hexadecimal method is used to encode variable-length strings consisting of digits 0-9 and letters a-f as
unsigned binary integers using four bits per character. This requires knowledge of L, the length of the string to be encoded, as well as L max,
the maximum permitted length for such a string.
This method uses the following table to map each character 0-9 a-f to a 4 bit binary string:
Table 14-6 Mapping table for "Variable-length lower case hexadecimal" encoding method
Character 4-bit binary string Character 4-bit binary string
0 0000 8 1000
1 0001 9 1001
2 0010 a 1010
3 0011 b 1011
4 0100 c 1100
5 0101 d 1101
6 0110 e 1110
7 0111 f 1111
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 190 of 448
14.5.6.3.1 Encoding
```
Input:
```
The input to the encoding method is a numeric string of length L consisting only of digits 0-9 or letters a-f.
Validity Test:
If the input string contains characters other than digits 0-9 or letters a-f or length L > L max, encoding fails.
```
Output:
```
Create an empty binary string buffer to receive the output. Append three bits '010' to the binary string buffer, to set an encoding indicator
value of '2'.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Convert the actual length L from a base 10 integer to a binary value, then if necessary, pad to the left with bits of '0' to reach a total length
bLI for the binary string representing the length indicator.
If L max = 1, the binary string representing the length indicator is empty, of zero length.
Append the binary string representing the length indicator to the binary string buffer.
Working from left to right across the input string, lookup each character in the table above and append the corresponding four bits to the
binary string buffer. Repeat until all L characters of the input string have been processed.
The contents of the binary string buffer is now the output of this encoding method.
14.5.6.3.2 Decoding
```
Input:
```
The input to the encoding method is a binary string whose leftmost three bits are '010', corresponding to an encoding indicator value '2' for
this method.
Validity Test:
If the input binary string does not begin with bits '010' this decoding method cannot be used.
If the output string contains characters other than digits 0-9 or letters a-f or is of length L > L max, decoding fails.
```
Output:
```
Create an empty string buffer to receive the output.
Read three bits from the binary input string and check that these match '010', otherwise decoding fails. Within the binary input string,
advance the cursor beyond those leftmost three bits.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 191 of 448
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Read bLI bits from the binary input string and convert this unsigned integer value to base 10 value L, the number of characters that are to
be decoded. Within the binary input string, advance the cursor beyond the b LI length indicator bits. Repeat the follow procedure L times,
once per character to be decoded:
Read the next four bits from the binary input string and advance the cursor beyond the bits that have just been read. Lookup the four bits
in the table above and append the corresponding character to the output string buffer.
When L characters have been decoded, the contents of the output string buffer is the output of this decoding method.
14.5.6.4 "Variable-length 6-bit file-safe URI-safe base 64"
The Variable-length file-safe base64 encoding method is used to encode variable-length strings of digits 0-9, upper case letters A-Z, lower
case letters a-z, hyphen or underscore characters using 6 bits per character. This requires knowledge of L, the length of the string to be
encoded, as well as L max, the maximum permitted length for such a string.
Figure 14-6 Example value - alphanumeric, encoded as file-safe URI-safe base 64
Table 14-7 Mapping table for "Variable-length 6-bit file-safe URI-safe base 64" encoding method
Character 6-bit binary string Character 6-bit binary
string
A 000000 g 100000
B 000001 h 100001
C 000010 i 100010
D 000011 j 100011
E 000100 k 100100
F 000101 l 100101
G 000110 m 100110
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 192 of 448
H 000111 n 100111
I 001000 o 101000
J 001001 p 101001
K 001010 q 101010
L 001011 r 101011
M 001100 s 101100
N 001101 t 101101
O 001110 u 101110
P 001111 v 101111
Q 010000 w 110000
R 010001 x 110001
S 010010 y 110010
T 010011 z 110011
U 010100 0 110100
V 010101 1 110101
W 010110 2 110110
X 010111 3 110111
Y 011000 4 111000
Z 011001 5 111001
a 011010 6 111010
b 011011 7 111011
c 011100 8 111100
d 011101 9 111101
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 193 of 448
```
e 011110 - (hyphen) 111110
```
```
f 011111 _ (underscore) 111111
```
14.5.6.4.1 Encoding
```
Input:
```
The input to the encoding method is a string of length L consisting only of digits 0-9 or upper case letters A-Z, colon, hyphen and full-stop
```
(period/dot).
```
Validity Test:
```
If the input string contains characters other than digits 0-9 or upper case letters A-Z, colon, hyphen and full-stop (period/dot) or length L >
```
L max, encoding fails.
```
Output:
```
Create an empty binary string buffer to receive the output. Append three bits '011' to the binary string buffer, to set an encoding indicator
value of '3'.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Convert the actual length L from a base 10 integer to a binary value, then if necessary, pad to the left with bits of '0' to reach a total length
bLI for the binary string representing the length indicator.
If L max = 1, the binary string representing the length indicator is empty, of zero length.
Append the binary string representing the length indicator to the binary string buffer.
Starting at the beginning of the input string and moving left-to-right, considering each character in turn until no further characters remain
to be encoded, lookup the character in the table below and append the corresponding set of six bits to the binary string buffer.
The contents of the binary string buffer is now the binary output of this encoding method.
14.5.6.4.2 Decoding
```
Input:
```
The input to the encoding method is a binary string whose leftmost three bits are '011', corresponding to an encoding indicator value '3' for
this method.
Validity Test:
If the input binary string does not begin with bits '011' this decoding method cannot be used.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 194 of 448
If the output string contains characters other than digits 0-9 or letters A-Z a-z, hyphen or underscore or is of length L > L max, decoding fails.
```
Output:
```
Create an empty string buffer to receive the output.
Read three bits from the binary input string and check that these match '011', otherwise decoding fails. Within the binary input string,
advance the cursor beyond those leftmost three bits.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Read bLI bits from the binary input string and convert this unsigned integer value to base 10 value L, the number of characters that are to
be decoded. Within the binary input string, advance the cursor beyond the b LI length indicator bits. Repeat the follow procedure L times,
once per character to be decoded:
Read the next six bits from the binary input string and advance the cursor beyond the bits that have just been read. Lookup the six bits in
the table above and append the corresponding character to the output string buffer.
When L characters have been decoded, the contents of the output string buffer is the output of this decoding method.
14.5.6.5 "Variable-length URN Code 40"
The Variable-length URN Code 40 encoding method is used to encode variable-length strings of digits 0-9, upper case letters A-Z, colon,
```
hyphen and full-stop (period/dot) using 16 bits for each set of 3 characters. This requires knowledge of L, the length of the string to be
```
encoded, as well as L max, the maximum permitted length for such a string.
The figure below illustrates the use of the variable-length URN Code 40 method to encode 6 characters.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 195 of 448
Figure 14-7 Use of the "Variable-length URN Code 40" method to encode 6 characters
URN Code 40 uses the following character table to map supportable characters to index values that are used in the calculation:
Table 14-8 URN Code 40 character table
Character Index Character Index
PAD character 0 T 20
A 1 U 21
B 2 V 22
C 3 W 23
D 4 X 24
E 5 Y 25
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 196 of 448
F 6 Z 26
```
G 7 - (hyphen) 27
```
```
H 8 . (full stop) 28
```
```
I 9 : (colon) 29
```
J 10 0 30
K 11 1 31
L 12 2 32
M 13 3 33
N 14 4 34
O 15 5 35
P 16 6 36
Q 17 7 37
R 18 8 38
S 19 9 39
14.5.6.5.1 Encoding
```
Input:
```
The input to the encoding method is a string of length L consisting only of digits 0-9 or upper case letters A-Z, colon, hyphen and full-stop
```
(period/dot). The maximum permitted length for the value ( L max ) must also be known.
```
Validity Test:
```
If the input string contains characters other than digits 0-9 or upper case letters A-Z, colon, hyphen and full-stop (period/dot) or length L >
```
L max, encoding fails.
```
Output:
```
Create an empty binary string buffer to receive the output. Append three bits '101' to the binary string buffer, to set an encoding indicator
value of '5'.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 197 of 448
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Convert the actual length L from a base 10 integer to a binary value, then if necessary, pad to the left with bits of '0' to reach a total length
bLI for the binary string representing the length indicator.
If L max = 1, the binary string representing the length indicator is empty, of zero length.
Append the binary string representing the length indicator to the binary string buffer.
Working from left to right across the input string, consider each successive group of three characters. If the final group only contains one or
two characters, consider the final group to be appended at the right with two or one pad characters respectively, to reach a total of three
characters.
Within each group of three characters, lookup the corresponding index values for each character. i 1 is the index value for the first
```
character, i 2 the index for the second character and i 3 is the index for the third character. Calculate r = (1600i 1 + 40i2 + i3 + 1). Convert r
```
to binary and if necessary, left-pad with bits of '0' to reach a total of 16 bits. Append this 16 bit string to the binary string buffer and repeat
this process for the next group of three characters until no further groups remain to be processed.
The contents of the binary string buffer is now the binary output of this encoding method.
14.5.6.5.2 Decoding
```
Input:
```
```
The input to the decoding method is a binary string. The maximum permitted length for the value ( L max ) must also be known.
```
Validity Test:
If the leftmost three bits of the binary input string are not '101' then this method cannot be used because the encoding indicator does not
correspond to this method.
```
If the output string contains characters other than digits 0-9 or upper case letters A-Z, colon, hyphen and full-stop (period/dot) or length L
```
> L max, encoding fails.
```
Output:
```
Create an empty string buffer to receive the output. Working from left to right across the binary input string, read the first three bits and
check that these are '101', the encoding indicator value for this method. Otherwise, this method cannot be used.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Read bLI bits as the length indicator and convert that unsigned binary integer to a base 10 value L, the number of characters to be read.
Move the cursor of the binary string past the three-bit encoding indicator '101' and the length indicator of b LI bits to begin reading the
encoded data.
```
If L is exactly divisible by 3, the number of iterations n = L/3, otherwise n = ceiling(L/3).
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 198 of 448
Repeat the following procedure n times, reading and processing 16 bits from the input binary string on each iteration and advancing the
cursor accordingly:
For each iteration, convert the 16 bit string to a base 10 unsigned integer r.
```
Calculate i 3 = (r–1)%40 where % is the modulo division operator and (r–1)%40 is the remainder of (r–1) after division by 40.
```
```
Calculate i 2 = ((r–1 – i3 )/40)%40
```
```
Calculate i1 = ((r–1 – i3 – 40i 2 )/1600)
```
Lookup i1 in the table above and append the corresponding character to the output string buffer.
If i2 > 0, lookup i2 in the table above and append the corresponding character to the output string buffer.
If i3 > 0, lookup i3 in the table above and append the corresponding character to the output string buffer.
After all n iterations have been completed, the contents of the output string buffer are considered to be the output of this decoding method.
14.5.6.6 "Variable-length 7-bit ASCII"
The Variable-length 7-bit ASCII encoding method is used to encode variable-length strings of characters within the 82-character GS1
invariant subset of ISO/IEC 646 [ISO646] or within the 39 character GS1 invariant subset of ISO/IEC 646 using 7 bits per character. This
requires knowledge of L, the length of the string to be encoded, as well as L max, the maximum permitted length for such a string.
This method uses the following character table, mapping characters to 7 bit sequences.
Table 14-9 Character table for "Variable-length 7-bit ASCII" encoding method
Character 7-bit binary
string
Character 7-bit binary
string
! 0100001 M 1001101
" 0100010 N 1001110
# 0100011 O 1001111
% 0100101 P 1010000
& 0100110 Q 1010001
' 0100111 R 1010010
```
( 0101000 S 1010011
```
```
) 0101001 T 1010100
```
- 0101010 U 1010101
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 199 of 448
Character 7-bit binary
string
Character 7-bit binary
string
- 0101011 V 1010110
, 0101100 W 1010111
- 0101101 X 1011000
. 0101110 Y 1011001
/ 0101111 Z 1011010
0 0110000 _ 1011111
1 0110001 a 1100001
2 0110010 b 1100010
3 0110011 c 1100011
4 0110100 d 1100100
5 0110101 e 1100101
6 0110110 f 1100110
7 0110111 g 1100111
8 0111000 h 1101000
9 0111001 i 1101001
: 0111010 j 1101010
```
; 0111011 k 1101011
```
< 0111100 l 1101100
= 0111101 m 1101101
> 0111110 n 1101110
? 0111111 o 1101111
A 1000001 p 1110000
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 200 of 448
Character 7-bit binary
string
Character 7-bit binary
string
B 1000010 q 1110001
C 1000011 r 1110010
D 1000100 s 1110011
E 1000101 t 1110100
F 1000110 u 1110101
G 1000111 v 1110110
H 1001000 w 1110111
I 1001001 x 1111000
J 1001010 y 1111001
K 1001011 z 1111010
L 1001100
The following figure provides a worked example to illustrate this method.
Figure 14-8 Example of alphanumeric encoded as 7-bit ASCII
14.5.6.6.1 Encoding
```
Input:
```
The input to the encoding method is a string of length L consisting only of characters appearing within the 82-character GS1 invariant
subset of ISO/IEC 646 or within the 39 character GS1 invariant subset of ISO/IEC 646. See GS1 General Specifications, Figures 7.11-1 and
7.11-2.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 201 of 448
Validity Test:
If the input string contains characters other than those appearing within the 82-character GS1 invariant subset of ISO/IEC 646 or within the
39 character GS1 invariant subset of ISO/IEC 646 or length L > Lmax, encoding fails.
```
Output:
```
Create an empty binary string buffer to receive the output. Append three bits '100' to the binary string buffer, to set an encoding indicator
value of '4'.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Convert the actual length L from a base 10 integer to a binary value, then if necessary, pad to the left with bits of '0' to reach a total length
bLI for the binary string representing the length indicator.
If L max = 1, the binary string representing the length indicator is empty, of zero length.
Append the binary string representing the length indicator to the binary string buffer.
Starting at the beginning of the input string and moving left-to-right, considering each character in turn until no further characters remain
to be encoded, lookup the character in the table below and append the corresponding set of seven bits to the binary string buffer.
The contents of the binary string buffer is now the binary output of this encoding method.
14.5.6.6.2 Decoding
```
Input:
```
```
The input to the decoding method is a binary string. The maximum permitted length for the value ( L max ) must also be known.
```
Validity Test:
If the leftmost three bits of the binary input string are not '100' then this method cannot be used because the encoding indicator does not
correspond to this method.
If the output string contains characters other than digits 0-9 or letters A-Z a-z, h201ninitialiundescore or if its length L > L max, decoding
fails.
```
Output:
```
Create an empty string buffer to receive the output. Working from left to right across the binary input string, read the first three bits and
check that these are '100', the encoding indicator value for this method. Otherwise, this method cannot be used.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 202 of 448
Read bLI bits from the binary input string and convert this unsigned integer value to base 10 value L, the number of characters that are to
be decoded. Within the binary input string, advance the cursor beyond the leftmost encoding indicator bits '100' and the b LI length indicator
bits. Repeat the follow procedure L times, once per character to be decoded:
Read the next seven bits from the binary input string and advance the cursor beyond the bits that have just been read. Lookup the seven
bits in the table above and append the corresponding character to the output string buffer.
When L characters have been decoded, the contents of the output string buffer is the output of this decoding method.
14.5.7 "Single data bit"
```
GS1 Application Identifiers (4321), (4322), (4323) use a single digit of '0' or '1' to represent a single bit Boolean value in which '0' indicates
```
false, whereas '1' indicates true.
14.5.7.1 Encoding
```
Input:
```
```
The input to the encoding method is one decimal digit, 0 ("false") or 1 ("true").
```
Validity Test:
The input must consist of exactly one decimal digit, which must be 0 or 1,
```
Output:
```
The output is a lone bit, 0 or 1.
14.5.7.2 Decoding
```
Input:
```
The input to the encoding method is a lone bit, 0 or 1.
Validity Test:
The input must consist of exactly one bit, otherwise the encoding fails.
```
Output:
```
If the single bit is 0, it is decoded as decimal value 0. If the single bit is 1, it is decoded as decimal value 1. 0 = false, 1 = true.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 203 of 448
14.5.8 "6-digit date YYMMDD"
Several GS1 Application Identifiers express a date value as a six-digit numeric string formatted as YYMMDD, in which YY represents the
year, MM represents the month and DD represents the day of the month. Such a numeric string value can be efficiently encoded using 16
bits as shown in the figure below, using 7 bits to encode YY, 4 bits to encode MM and 5 bits to encode DD:
Figure 14-9 Efficient encoding of YYMMDD date value using 16 bits
14.5.8.1 Encoding
```
Input:
```
The input to the encoding method is a 6-digit numeric string representing a date value in the format YYMMDD, as expected in the GS1
General Specifications.
Validity Test:
The 6-digit numeric string must only consist of digits 0-9 and is further constrained to be a plausible date value, meaning that the third and
fourth digits are always in the range 01-12 and the fifth and sixth digits are always in the range 00-31 and do not indicate a day-of-month
value that is greater than the number of days in the month indicated by the third and fourth Digits. e.g. if the third and fourth digits are
"09" then a value of "31" for the fifth and sixth digits would be invalid because September can only contain 30 days.
```
Output:
```
Create an empty binary string buffer to receive the output.
Consider the input string as pairs of digits in which the first two digits are YY, the next two digits are MM and the final two digits are DD.
```
Convert YY to a decimal integer (e.g. '22'  22 ) and convert this to an unsigned binary value, then if the resulting binary string for YY is
```
less than seven bits in length, pad to the left with bits set to '0' to reach a total of seven bits. Append these seven bits to the binary string
buffer.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 204 of 448
```
Convert MM to a decimal integer (e.g. '05'  5 ) and convert this to an unsigned binary value, then if the resulting binary string for MM is
```
less than four bits in length, pad to the left with bits set to '0' to reach a total of four bits. Append these four bits to the binary string
buffer.
```
Convert DD to a decimal integer (e.g. '31'  31 ) and convert this to an unsigned binary value, then if the resulting binary string for DD is
```
less than five bits in length, pad to the left with bits set to '0' to reach a total of five bits. Append these five bits to the binary string buffer.
The binary string buffer should now consist of a total of 16 bits and should be considered as the output of this encoding method.
14.5.8.2 Decoding
```
Input:
```
The input to the decoding method is a binary string of 16 bits.
Validity Test:
The sixteen bits will be decoded as a 6-digit numeric string representing a date formatted as YYMMDD. After decoding, the third and fourth
digits must always be in the range 01-12 and the fifth and sixth digits must always be in the range 00-31 and must not indicate a day-of-
month value that is greater than the number of days in the month indicated by the third and fourth Digits. e.g. if the third and fourth digits
are "09" then a value of "31" for the fifth and sixth digits would be invalid because September can only contain 30 days.
```
Output:
```
Create an empty string buffer to receive the six-digit output value YYMMDD.
Treat the sixteen bits as an encoding of the date value.
Working from left to right, read the first 7 bits as unsigned binary integer y, then convert to a base 10 value YY, padding to the left with a
single '0' digit if the initial result after conversion to base 10 was in the range 0-9.
Read the next 4 bits as unsigned binary integer m, then convert to a base 10 value MM, padding to the left with a single '0' digit if the initial
result after conversion to base 10 was in the range 0-9.
Read the next 5 bits as unsigned binary integer d, then convert to a base 10 value DD, padding to the left with a single '0' digit if the initial
result after conversion to base 10 was in the range 0-9.
Check that MM is within the range 01-12 and that DD is within the range 00-31 and does not exceed the number of days in the month for
the month indicated by MM. Otherwise decoding fails.
Concatenate YY MM and DD in sequence as the output value YYMMDD.
14.5.9 "10-digit date+time YYMMDDhhmm"
```
GS1 Application Identifiers (4324), (4325), (7003) use a 10-digit numeric string to express a date format YYMMDDhhmm in which YY
```
represents the year, MM represents the month, DD represents the day of the month, hh represents the hour of the day and mm represents
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 205 of 448
the minutes. Such a numeric string value can be efficiently encoded using 27 bits as shown in the figure below, using 7 bits to encode YY, 4
bits to encode MM, 5 bits to encode DD, 5 bits to encode hh and 6 bits to encode mm:
Figure 14-10 Encoding of YYMMDDhhmm date time value using 27 bits
14.5.9.1 Encoding
```
Input:
```
The input to the encoding method is a 10-digit numeric string representing a date value in the format YYMMDDhhmm, as expected in the
GS1 General Specifications.
Validity Test:
The 10-digit numeric string must only consist of digits 0-9 and is further constrained to be a plausible date+time value, meaning that the
third and fourth digits are always in the range 01-12 and the fifth and sixth digits are always in the range 00-31 and do not indicate a day-
of-month value that is greater than the number of days in the month indicated by the third and fourth Digits. e.g. if the third and fourth
digits are "09" then a value of "31" for the fifth and sixth digits would be invalid because September can only contain 30 days. The seventh
and eight digits must be in the range 00-24, while the ninth and tenth digits must be in the range 00-59.
```
Output:
```
Create an empty binary string buffer to receive the output.
Consider the input string as pairs of digits in which the first two digits are YY, the next two digits are MM, followed by two digits DD, a
further two digits hh and a final two digits mm.
```
Convert YY to a decimal integer (e.g. '22'  22 ) and convert this to an unsigned binary value, then if the resulting binary string for YY is
```
less than seven bits in length, pad to the left with bits set to '0' to reach a total of seven bits. Append these seven bits to the binary string
buffer.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 206 of 448
```
Convert MM to a decimal integer (e.g. '05'  5 ) and convert this to an unsigned binary value, then if the resulting binary string for MM is
```
less than four bits in length, pad to the left with bits set to '0' to reach a total of four bits. Append these four bits to the binary string
buffer.
```
Convert DD to a decimal integer (e.g. '31'  31 ) and convert this to an unsigned binary value, then if the resulting binary string for DD is
```
less than five bits in length, pad to the left with bits set to '0' to reach a total of five bits. Append these five bits to the binary string buffer.
```
Convert hh to a decimal integer (e.g. '07'  7 ) and convert this to an unsigned binary value, then if the resulting binary string for hh is less
```
than five bits in length, pad to the left with bits set to '0' to reach a total of five bits. Append these five bits to the binary string buffer.
```
Convert mm to a decimal integer (e.g. '59'  59 ) and convert this to an unsigned binary value, then if the resulting binary string for mm is
```
less than six bits in length, pad to the left with bits set to '0' to reach a total of six bits. Append these six bits to the binary string buffer.
The binary string buffer should now consist of a total of 27 bits and should be considered as the output of this encoding method.
14.5.9.2 Decoding
```
Input:
```
The input to the decoding method is a binary string of 27 bits.
Validity Test:
The sixteen bits will be decoded as a 10-digit numeric string representing a date formatted as YYMMDDhhmm. After decoding, the third and
fourth digits must always be in the range 01-12 and the fifth and sixth digits must always be in the range 00-31 and must not indicate a
day-of-month value that is greater than the number of days in the month indicated by the third and fourth Digits. e.g. if the third and
fourth digits are "09" then a value of "31" for the fifth and sixth digits would be invalid because September can only contain 30 days. The
seventh and eight digits must be in the range 00-24, while the ninth and tenth digits must be in the range 00-59.
```
Output:
```
Create an empty string buffer to receive the ten-digit output value YYMMDDhhmm.
Treat the 27 bits as an encoding of the date+time value.
Working from left to right, read the first 7 bits as unsigned binary integer y, then convert to a base 10 value YY, padding to the left with a
single '0' digit if the initial result after conversion to base 10 was in the range 0-9.
Read the next 4 bits as unsigned binary integer m, then convert to a base 10 value MM, padding to the left with a single '0' digit if the initial
result after conversion to base 10 was in the range 0-9.
Read the next 5 bits as unsigned binary integer d, then convert to a base 10 value DD, padding to the left with a single '0' digit if the initial
result after conversion to base 10 was in the range 0-9.
Read the next 5 bits as unsigned binary integer h, then convert to a base 10 value hh, padding to the left with a single '0' digit if the initial
result after conversion to base 10 was in the range 0-9.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 207 of 448
Read the next 6 bits as unsigned binary integer n, then convert to a base 10 value mm, padding to the left with a single '0' digit if the initial
result after conversion to base 10 was in the range 0-9.
Check that MM is within the range 01-12 and that DD is within the range 00-31 and does not exceed the number of days in the month for
the month indicated by MM. Otherwise decoding fails.
Check that hh is within the range 00-24 and that mm is within the range 00-59. If hh is '24' then mm must be '00' otherwise decoding fails
Concatenate YY MM DD hh mm in sequence as the output value YYMMDDhhmm.
14.5.10 "Variable-format date / date range"
```
GS1 Application Identifier (7007) expresses either a harvest date or a harvest date range (indicating a start date then an end date). A
```
single YYMMDD date value can be efficiently encoded using 16 bits, whereas a date range consisting of a start date and end date will require
32 bits. In order to distinguish between these two possibilities, this method uses a single bit format indicator as shown in the figure below.
If that single bit format indicator is set to 0, a single date value YYMMDD is expected. If the single bit format indicator is set to 1, a pair of
date values YYMMDD YYMMDD is expected, to express a date range.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 208 of 448
Figure 14-11 Encoding of "Variable-format date / date range"
14.5.10.1 Encoding
```
Input:
```
The input to the encoding method is either a 6-digit numeric string representing a date value in the format YYMMDD, or a 12 digit numeric
string representing a date range in the format YYMMDDYYMMDD as expected in the GS1 General Specifications.
Validity Test:
A 6-digit numeric string must only consist of digits 0-9 and is further constrained to be a plausible date value, meaning that the third and
fourth digits are always in the range 01-12 and the fifth and sixth digits are always in the range 00-31 and do not indicate a day-of-month
value that is greater than the number of days in the month indicated by the third and fourth Digits. e.g. if the third and fourth digits are
"09" then a value of "31" for the fifth and sixth digits would be invalid because September can only contain 30 days. A 12-digit numeric
string must only consist of digits 0-9 and both the first six digits and last six digits are further constrained to be a plausible date value, as
previously explained.
```
Output:
```
Create an empty binary string buffer to receive the output.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 209 of 448
If the input is a 6-digit string in the format YYMMDD, append a single bit of '0' to the binary string buffer. If the input is a 12-digit string in
the format YYMMDD, append a single bit of '1' to the binary string buffer.
Perform the following procedure once if the input is a 6-digit string YYMMDD or perform it twice, with each set of six digits YYMMDD for the
date range if the input is a 12-digit string YYMMDDYYMMDD.
Consider the input string as pairs of digits in which the first two digits are YY, the next two digits are MM and the final two digits are DD.
```
Convert YY to a decimal integer (e.g. '22'  22 ) and convert this to an unsigned binary value, then if the resulting binary string for YY is
```
less than seven bits in length, pad to the left with bits set to '0' to reach a total of seven bits. Append these seven bits to the binary string
buffer.
```
Convert MM to a decimal integer (e.g. '05'  5 ) and convert this to an unsigned binary value, then if the resulting binary string for MM is
```
less than four bits in length, pad to the left with bits set to '0' to reach a total of four bits. Append these four bits to the binary string
buffer.
```
Convert DD to a decimal integer (e.g. '31'  31 ) and convert this to an unsigned binary value, then if the resulting binary string for DD is
```
less than five bits in length, pad to the left with bits set to '0' to reach a total of five bits. Append these five bits to the binary string buffer.
```
The binary string buffer should now consist of a total of 17 bits (for a 6-digit input of YYMMDD) or 33 bits (for a 12-digit input of
```
```
YYMMDDYYMMDD) and should be considered as the output of this encoding method.
```
14.5.10.2 Decoding
```
Input:
```
The input to the decoding method is a binary string of 17 bits or 33 bits, of which the first bit is a date format indicator, where '0' indicates
that 16 bits follow, to be decoded as a 6-digit date string YYMMDD, whereas '1' indicates that 32 bits follow, to be decoded as a 12-digit
date range string YYMMDDYYMMDD.
Validity Test:
Each set of sixteen bits will be decoded as a 6-digit numeric string representing a date formatted as YYMMDD. After decoding, the third and
fourth digits must always be in the range 01-12 and the fifth and sixth digits must always be in the range 00-31 and must not indicate a
day-of-month value that is greater than the number of days in the month indicated by the third and fourth Digits. e.g. if the third and
fourth digits are "09" then a value of "31" for the fifth and sixth digits would be invalid because September can only contain 30 days.
```
Output:
```
Create an empty string buffer to receive the six-digit output value YYMMDD or the twelve-digit output value YYMMDDYYMMDD.
Read the left-most bit of the binary input string and move the cursor beyond it, to begin reading data. If the single bit value is '0', perform
the following procedure once. If the single bit value is '1', perform the following procedure twice.
Treat the next sixteen bits as an encoding of a date value.
Working from left to right, read the first 7 bits as unsigned binary integer y, then convert to a base 10 value YY, padding to the left with a
single '0' digit if the initial result after conversion to base 10 was in the range 0-9.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 210 of 448
Read the next 4 bits as unsigned binary integer m, then convert to a base 10 value MM, padding to the left with a single '0' digit if the initial
result after conversion to base 10 was in the range 0-9.
Read the next 5 bits as unsigned binary integer d, then convert to a base 10 value DD, padding to the left with a single '0' digit if the initial
result after conversion to base 10 was in the range 0-9.
Check that MM is within the range 01-12 and that DD is within the range 00-31 and does not exceed the number of days in the month for
the month indicated by MM. Otherwise decoding fails.
Concatenate YY MM and DD in sequence as the output value YYMMDD and append this to the output string buffer.
If the initial bit of the binary input string was set to '1', ensure that the procedure above has been performed twice, for both the start date
and the end date, both formatted as YYMMDD.
The output string buffer should now consist of either a 6-digit numeric string representing a date formatted as YYMMDD or a 12-digit
numeric string representing a date range formatted as YYMMDDYYMMDD. This is the output of this decoding method.
14.5.11 "Variable-precision date+time"
```
GS1 Application Identifier (8008) expresses a production date and time with a choice of three formats that differ in the precision of the time
```
value,either hours, hours and minutes or hours, minutes and seconds, as shown in the figure below.
```
GS1 Application Identifier (7011) expresses a test-by date, either as a date in YYMMDD format or as a date-time that also expresses hours
```
and minutes,
A numeric string representing a date formatted as YYMMDD can be encoded in 16 bits.
A numeric string representing a date+hours formatted as YYMMDDhh can be encoded in 21 bits.
A numeric string representing a date+hours+minutes formatted as YYMMDDhhmm can be encoded in 27 bits.
A numeric string representing a date+hours+minutes+seconds formatted as YYMMDDhhmmss can be encoded in 33 bits.
To distinguish between these four alternatives, the binary encoding begins with a two-bit format indicator whose value is '00' for
YYMMDDhh, '01' for YYMMDDhhmm, '10' for YYMMDDhhmmss or '11' for YYMMDD.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 211 of 448
Figure 14-12 Encoding of "Variable-precision date+time"
14.5.11.1 Encoding
```
Input:
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 212 of 448
The input to the encoding method is either a 6-digit numeric string representing a date in the format YYMMDD, a 8-digit numeric string
representing a date+time value in the format YYMMDDhh, a 10-digit numeric string representing a date+time value in the format
YYMMDDhhmm or a 12-digit numeric string representing a date+time value in the format YYMMDDhhmmss, as expected in the GS1 General
Specifications.
Validity Test:
The numeric string must only consist of digits 0-9 and is further constrained to be a plausible date or date+time value, meaning that the
third and fourth digits are always in the range 01-12 and the fifth and sixth digits are always in the range 00-31 and do not indicate a day-
of-month value that is greater than the number of days in the month indicated by the third and fourth Digits. e.g. if the third and fourth
digits are "09" then a value of "31" for the fifth and sixth digits would be invalid because September can only contain 30 days. The seventh
```
and eight digits (if present) must be in the range 00-24, while the ninth and tenth digits (if present) must be in the range 00-59 and the
```
```
eleventh and twelfth digits (if present) must also be in the range 00-59.
```
```
Output:
```
Create an empty binary string buffer to receive the output.
If the input string was a 6-digit numeric string formatted as YYMMDD, append '11' to the binary string buffer. If the input string was a 8-
digit numeric string formatted as YYMMDDhh, append '00' to the binary string buffer. If the input string was 10-digit numeric string
formatted as YYMMDDhhmm, append '01' to the binary string buffer. If the input string was 12-digit numeric string formatted as
YYMMDDhhmmss, append '10' to the binary string buffer.
```
Consider the input string as pairs of digits in which the first two digits are YY, the next two digits are MM, followed by two digits DD, then (if
```
```
present) a further two digits hh and (if present) two digits mm and (if present) two digits ss.
```
```
Convert YY to a decimal integer (e.g. '22'  22 ) and convert this to an unsigned binary value, then if the resulting binary string for YY is
```
less than seven bits in length, pad to the left with bits set to '0' to reach a total of seven bits. Append these seven bits to the binary string
buffer.
```
Convert MM to a decimal integer (e.g. '05'  5 ) and convert this to an unsigned binary value, then if the resulting binary string for MM is
```
less than four bits in length, pad to the left with bits set to '0' to reach a total of four bits. Append these four bits to the binary string
buffer.
```
Convert DD to a decimal integer (e.g. '31'  31 ) and convert this to an unsigned binary value, then if the resulting binary string for DD is
```
less than five bits in length, pad to the left with bits set to '0' to reach a total of five bits. Append these five bits to the binary string buffer.
```
If present, convert hh to a decimal integer (e.g. '07'  7 ) and convert this to an unsigned binary value, then if the resulting binary string
```
for hh is less than five bits in length, pad to the left with bits set to '0' to reach a total of five bits. Append these five bits to the binary
string buffer.
```
If present, convert mm to a decimal integer (e.g. '59'  59 ) and convert this to an unsigned binary value, then if the resulting binary string
```
for mmis less than six bits in length, pad to the left with bits set to '0' to reach a total of six bits. Append these six bits to the binary string
buffer.
```
If present, convert ss to a decimal integer (e.g. '59'  59 ) and convert this to an unsigned binary value, then if the resulting binary string
```
for ss is less than six bits in length, pad to the left with bits set to '0' to reach a total of six bits. Append these six bits to the binary string
buffer.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 213 of 448
```
The binary string buffer should now consist of a total of either 18 bits (for a 6-digit input YYMMDD) or 23 bits (for an 8-digit input
```
```
YYMMDDhh) or 29 bits (for a 10-digit input YYMMDDhhmm) or 35 bits (for a 12-digit input YYMMDDhhmmss) and should be considered as
```
the output of this encoding method.
14.5.11.2 Decoding
```
Input:
```
The input to the decoding method is a binary string of either 18, 23, 29 or 35 bits.
Validity Test:
The leftmost two bits are a date+time format indicator. As shown in Figure 40, the value of these two bits determine how many further bits
should be read and how they should be interpreted.
In all situations, the next 16 bits will be decoded as a 6-digit numeric string representing a date formatted as YYMMDD, using 7 bit for YY,
followed by 4 bits for MM, then 5 bits for DD If the initial two bits for the date+time format indicator have a value other than '11', further
groups of bits shall be read and interpreted as follows, in sequence: 5 bits for hh, 6 bits for mm and 6 bits for ss.
After decoding the initial 16 bits after the two-bit indicator, the third and fourth digits must always be in the range 01-12 for MM and the
fifth and sixth digits must always be in the range 00-31 for DD and must not indicate a day-of-month value that is greater than the number
of days in the month indicated by the third and fourth digits. e.g. if the third and fourth digits are "09" then a value of "31" for the fifth and
```
sixth digits would be invalid because September can only contain 30 days. The seventh and eight digits (if present) must be in the range
```
```
00-24 for hh, while the ninth and tenth digits (if present) must be in the range 00-59 for mm and the eleventh and twelfth digits (if
```
```
present) must also be in the range 00-59 for ss.
```
```
Output:
```
Create an empty string buffer to receive the output value.
Read the leftmost two bits of the binary input string and move the cursor beyond those initial two bits. If the value is '00', the next 21 bits
will be decoded to an 8-digit numeric string YYMMDDhh.
If the value is '01', the next 27 bits will be decoded to a 10-digit numeric string YYMMDDhhmm.
If the value is '10', the next 33 bits will be decoded to a 12-digit numeric string YYMMDDhhmmss.
If the value is '11', the next 16 bits will be decoded to a 6-digit numeric string YYMMDD.
Working from left to right, read the first 7 bits as unsigned binary integer y, then convert to a base 10 value YY, padding to the left with a
single '0' digit if the initial result after conversion to base 10 was in the range 0-9.
Read the next 4 bits as unsigned binary integer m, then convert to a base 10 value MM, padding to the left with a single '0' digit if the initial
result after conversion to base 10 was in the range 0-9.
If present, read the next 5 bits as unsigned binary integer d, then convert to a base 10 value DD, padding to the left with a single '0' digit if
the initial result after conversion to base 10 was in the range 0-9.
If present, read the next 5 bits as unsigned binary integer h, then convert to a base 10 value hh, padding to the left with a single '0' digit if
the initial result after conversion to base 10 was in the range 0-9.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 214 of 448
If present, read the next 6 bits as unsigned binary integer n, then convert to a base 10 value mm, padding to the left with a single '0' digit
if the initial result after conversion to base 10 was in the range 0-9.
If present, read the next 6 bits as unsigned binary integer s, then convert to a base 10 value ss, padding to the left with a single '0' digit if
the initial result after conversion to base 10 was in the range 0-9.
Check that MM is within the range 01-12 and that DD is within the range 00-31 and does not exceed the number of days in the month for
the month indicated by MM. Otherwise decoding fails.
```
Check that hh (if present) is within the range 00-24 and that mm (if present) is within the range 00-59 and that ss (if present) is also within
```
```
the range 00-59. If hh is '24' then both mm and ss (if present) must be '00', otherwise decoding fails.
```
If the initial two-bit date indicator was '00', concatenate YY MM DD hh in sequence as the output value YYMMDDhh.
If the initial two-bit date indicator was '01', concatenate YY MM DD hh mm in sequence as the output value YYMMDDhhmm.
If the initial two-bit date indicator was '10', concatenate YY MM DD hh mm ss in sequence as the output value YYMMDDhhmmss.
If the initial two-bit date indicator was '11', concatenate YY MM DD in sequence as the output value YYMMDD.
```
14.5.12 "Country code (ISO 3166-1 alpha-2)"
```
```
The Country code (ISO 3166-1 alpha-2) encoding method is used to encode two-letter strings of upper case letters A-Z using 6 bits per
```
character, using the file-safe URI-safe base64 alphabet for the binary encoding of each letter.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 215 of 448
Figure 14-13 ISO 3166-1 alpha-2 country code encoded as file-safe URI base 64
```
Table 14-10 Encoding table for "Country code (ISO 3166-1 alpha-2)"
```
Character 6-bit binary string Character 6-bit binary
string
A 000000 N 001101
B 000001 O 001110
C 000010 P 001111
D 000011 Q 010000
E 000100 R 010001
F 000101 S 010010
G 000110 T 010011
H 000111 U 010100
I 001000 V 010101
J 001001 W 010110
K 001010 X 010111
L 001011 Y 011000
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 216 of 448
Character 6-bit binary string Character 6-bit binary
string
M 001100 Z 011001
14.5.12.1 Encoding
```
Input:
```
The input to the encoding method is a string of two upper case letters A-Z.
Validity Test:
If the input string contains characters other than upper case letters A-Z or is not exactly two characters in length, encoding fails.
```
Output:
```
Create an empty binary string buffer to receive the output.
Lookup the first character in the table above and append the corresponding set of six bits to the binary string buffer.
Lookup the second character in the table above and append the corresponding set of six bits to the binary string buffer.
The contents of the binary string buffer is now the binary output of this encoding method.
14.5.12.2 Decoding
```
Input:
```
The input to the encoding method is a binary string of 12 bits.
Validity Test:
If the output string contains characters other than upper case letters A-Z, decoding fails.
```
Output:
```
Create an empty string buffer to receive the output.
Read the first six bits from the binary input string. Lookup the six bits in the table above and append the corresponding character to the
output string buffer.
```
Read the next (final) six bits from the binary input string. Lookup the six bits in the table above and append the corresponding character to
```
the output string buffer.
The contents of the output string buffer is the output of this decoding method.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 217 of 448
14.5.13 "Variable-length numeric string without encoding indicator"
The 'Variable-length numeric string without encoding indicator' encoding method is used to encode variable-length numeric strings as
unsigned binary integers using the minimum number of bits.
```
It is very similar to the method " (§14.5.6.1) option within "Variable-length alphanumeric (§14.5.6) but is used in situations where the
```
value is defined within the GS1 General Specifications to be strictly numeric rather than alphanumeric, so no encoding indicator is used
within this method.
It preserves leading zeros, since the decoding method is required to left-pad the decoded integer to the number of digits indicated by the
length indicator that was encoded. This method requires knowledge of L, the length of the string to be encoded, as well as L max, the
maximum permitted length for such a string.
```
Note: this is also similar to the "Fixed-Bit-Length Numeric String"method (§14.5.2) except that the length is not fixed and the binary value
```
```
is appended after an appropriate length indicator (but no encoding indicator).
```
14.5.13.1 Encoding
```
Input:
```
The input to the encoding method is a numeric string of length L consisting only of digits 0-9.
Validity Test:
If the input string contains characters other than digits 0-9 or length L > L max, encoding fails.
```
Output:
```
Create an empty binary string buffer to receive the output.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Convert the actual length L from a base 10 integer to a binary value, then if necessary, pad to the left with bits of '0' to reach a total length
bLI for the binary string representing the length indicator.
If L max = 1, the binary string representing the length indicator is empty, of zero length.
Append the binary string representing the length indicator to the binary string buffer.
Convert the input string of L digits 0-9 to a base 10 integer then convert this to an unsigned binary integer, v.
Calculate bv, the number of bits for expressing the value either via a lookup of L in table B and reading the value in the column titled
'Integer encoding' or using the following formula:
```
bv = ceiling(L*log(10)/log(2))
```
If necessary, pad the binary string v with bits of '0' to reach a total length b v for the binary string representing the numeric string value.
```
After any necessary padding, append binary string v (of length bv ) to the binary string buffer.
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 218 of 448
The contents of the binary string buffer is now the binary output of this encoding method.
14.5.13.2 Decoding
```
Input:
```
The input to the decoding method is a binary string.
Validity Test:
If the output string contains characters other than digits 0-9 or if length L > Lmax, decoding fails.
```
Output:
```
Create an empty binary string buffer to receive the output.
Lookup bLI, the number of bits for expressing the length indicator in Table F.
Read the next bLI bits of the binary input string as the length indicator and convert this binary value to an unsigned base 10 integer L, the
number of characters that are encoded. Within the binary input string, move the cursor past the b LI length indicator bits to begin decoding
the actual value.
Calculate bv, the number of bits for expressing the value either via a lookup of L in table B and reading the value in the column titled
'Integer encoding' or using the following formula:
```
bv = ceiling(L*log(10)/log(2))
```
Read the next bv bits from the binary string and convert this to an unsigned base 10 integer V.
Convert V to a numeric string. If V is fewer than L digits in length, left-pad V with digits of '0' to reach a total of L digits. The resulting L-
```
digit numeric string value V (with any necessary left-padding) is the output of this decoding method.
```
14.5.14 "Optional minus sign in 1 bit"
```
GS1 Application Identifiers (4330), (4331), (4332), (4333) express a 6 digit value for maximum/minimum temperature in hundredths of
```
degrees Celsius or Fahrenheit and use an optional trailing minus sign to indicate if the temperature is negative.
To support efficient encoding of the optional trailing minus sign, this method uses a single bit value in which '0' indicates an empty string
```
(used for positive temperature values in the Celsius and Fahrenheit scales), whereas '1' indicates the presence of a trailing minus sign (used
```
```
for negative temperature values in the Celsius and Fahrenheit scales).
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 219 of 448
14.5.14.1 Encoding
```
Input:
```
The input to the encoding method is a string, either the empty string "" or a single minus/hyphen character "-". The empty string will be
mapped to a single bit with value 0. The single minus/hyphen character will be mapped to a single bit with value 1
Validity Test:
The input must consist of either the empty string "" or a single minus/hyphen character "-"
```
Output:
```
The output is a single bit, 0 or 1.
If the input is the empty string "", the output shall be a single bit set to value 0.
If the input is a single minus/hyphen character "-", the output shall be a single bit set to value 1.
14.5.14.2 Decoding
```
Input:
```
The input to the encoding method is a single bit, 0 or 1.
Validity Test:
The input must consist of exactly one bit, otherwise the encoding fails.
```
Output:
```
If the single bit is 0, it is decoded as an empty string "".
If the single bit is 1, it is decoded as a single minus/hyphen character "-".
14.5.15 "Sequence indicator"
```
GS1 Application Identifier (7258) expresses a 3 character value for baby birth sequence indicator using the format of a single digit, followed
```
by a literal forward slash or solidus, followed by a final single digit. For example, a value of "1/3" indicates the first of three triplets.
To support efficient encoding of this value format, this method encodes the value as two single digits without encoding the literal forward
slash or solidus. Upon decoding from binary, the literal forward slash or solidus is reinstated. Each digit is encoded as a fixed-length binary
sequence of four bits.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 220 of 448
14.5.15.1 Encoding
```
Input:
```
The input to the encoding method is a string of the format "n/m" where n and m are digit characters in the range 1-9 only, separated by a
literal forward slash or solidus character.
Validity Test:
The input must consist of a string of the format "n/m" where n and m are digit characters in the range 1-9 only, separated by a literal
forward slash or solidus character.
```
Output:
```
Create an empty binary string buffer
Extract the first digit character, n, convert to a base 10 integer in the range 1-9 then convert that to binary, padding to the left with bits of
'0' to reach a total of four bits, then append this to the binary string buffer. For example, if the first digit character is "1", the sequence
"0001" should be appended to the buffer. If the first digit character is "9", the sequence "1001" should be appended to the buffer.
Extract the third digit character, m, convert to a base 10 integer in the range 1-9 then convert that to binary, padding to the left with bits of
'0' to reach a total of four bits, then append this to the binary string buffer. For example, if the third digit character is "3", the sequence
"0011" should be appended to the buffer. If the third digit character is "9", the sequence "1001" should be appended to the buffer.
The binary string buffer should now consist of eight bits. These should be returned as the output.
14.5.15.2 Decoding
```
Input:
```
The input to the encoding method is a sequence of eight bits.
Validity Test:
The input must consist of exactly eight bits, otherwise the decoding fails.
Furthermore, treating the eight bits as two concatenated groups of four bits, the corresponding base 10 integer value for each group should
be in the range 1-9, otherwise the decoding fails.
```
Output:
```
Create an empty string buffer for the output.
Extract the first four bits from the input and convert these to a base 10 integer value in the range 1-9, then convert this to a single string
digit character in the range "1" – "9" and append this to the output buffer.
Append the forward slash or solidus character "/" to the output buffer.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 221 of 448
Extract the final four bits from the input and convert these to a base 10 integer value in the range 1-9, then convert this to a single string
digit character in the range "1" – "9" and append this to the output buffer.
Return the output buffer as a 3-character string of the format "n/m" where n and m are digit characters in the range "1"-"9".
14.5.16 "Custom domain name or hostname"
```
The new ‘++’ EPC schemes (including SGTIN++ and DSGTIN++) support the expression of a custom domain name or hostname after the
```
serial number within the binary encoding of the EPC identifier, in order to support lossless encoding/decoding of non-canonical GS1 Digital
Link URIs that have custom domain names. For SGTIN++, DSGTIN++ and other ‘++’ EPC schemes, the only supported URI protocol is
```
https:// - not http://. When translating binary encodings for SGTIN++, DSGTIN++ and other ‘++’ EPC schemes to GS1 Digital Link URIs,
```
‘https://’ is not encoded in binary but is implied and automatically reinstated as the URI protocol, i.e. https:// will always appear before the
hostname decoded from the binary string using this method.
The corresponding binary encoding consists of a 1-bit encoding indicator followed by a 6-bit length indicator followed by encoded character
data.
```
Because hostnames include the dot character, encoding options include URN Code 40 (at 16 bits per 3 characters) or 7-bit truncated ASCII
```
```
(at 7 bits per character). Although the 7-bit truncated ASCII encoding might appear slightly less efficient, it includes the possibility to
```
compress some frequently-used sequences such as “.com” or “id.” in fewer bits by making use of optimisation sequences of bits and lookup
tables that map special 7-bit values or 14-bit values to sequences of characters such as “.com” or “id.” rather than to single characters
```
within the GS1 AI-encodable character set 82; the 7-bit or 14-bit optimisation sequences of bits all begin with a 7-bit value that does not
```
correspond to a character within the GS1 AI-encodable character set 82.
Only the '++' EPC schemes introduced in TDS 2.3 support efficient binary encoding of a custom hostname. All other EPC schemes outside
```
the '++' set do not support explicit binary encoding of a custom hostname. For those that are based on GS1 identifiers (e.g. SGTIN-96,
```
```
SGTIN-198, SGTIN+, DSGTIN+, ... - and not ADI-var or USDOD-96), it is possible to construct an equivalent GS1 Digital Link URI using
```
either a hostname that is preferred/recommended within a specific jurisdiction or to use 'id.gs1.org' to construct a canonical GS1 Digital
Link URI - see section 4.12 of https://ref.gs1.org/standards/digital-link/uri-syntax/ for further details. Note that resolution of canonical GS1
Digital Link URIs using the hostname id.gs1.org is supported by the GS1 global resolver.
Figure 42 shows a worked example of how the URN Code 40 method can be used to encode a custom hostname that contains only
uppercase alphanumeric characters, dot, colon or hyphen.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 222 of 448
Figure 14-14 Example of URN Code 40 method to encode custom hostname
Figure 45 shows a worked example of how the 7-bit truncated ASCII method can be used to encode a custom hostname that contains any
permitted characters from the GS1 AI-encodable character set 82, without making use of any optimisations for encoding top-level domains
```
(TLDs) or subdomains such as “id.”.
```
Figure 14-15 Example of 7-bit truncated ASCII method to encode custom hostname
Figure 46 shows a worked example of how the 7-bit truncated ASCII method can be used to encode a custom hostname that contains any
```
permitted characters from the GS1 AI-encodable character set 82, making use of any optimisations for encoding top-level domains (TLDs)
```
or subdomains such as “id.” .
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 223 of 448
Figure 14-16 Example of 7-bit truncated ASCII method to encode custom hostname with TLD optimisation
The 7-bit ASCII method with optimised encoding of top-level domains and subdomains makes use of the following optimisation tables:
```
Table 14-11Optimisation Table A (showing GS1 AI encodable UTF-8 / ASCII characters and 7-bit optimisation sequences)
```
7-bit optimised encoding sequence UTF-8 / ASCII character or Subdomain or TLD or note
0000000 See Optimisation Table B1 for 14-bit values
0000001 See Optimisation Table B2 for 14-bit values
0000010 See Optimisation Table B3 for 14-bit values
0000011 See Optimisation Table B4 for 14-bit values
0000100
to
0011101
Reserved for future use
0011110 qr.
0011111 www.
0100000 id.
0100001 !
0100010 "
0100011 #
0100100 Reserved for future use
0100101 %
0100110 &
0100111 '
```
0101000 (
```
```
0101001 )
```
0101010 *
0101011 +
0101100 ,
0101101 -
0101110 .
0101111 /
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 224 of 448
0110000 0
0110001 1
0110010 2
0110011 3
0110100 4
0110101 5
0110110 6
0110111 7
0111000 8
0111001 9
0111010 :
```
0111011 ;
```
0111100 <
0111101 =
0111110 >
0111111 ?
1000000 Reserved for future use
1000001 A
1000010 B
1000011 C
1000100 D
1000101 E
1000110 F
1000111 G
1001000 H
1001001 I
1001010 J
1001011 K
1001100 L
1001101 M
1001110 N
1001111 O
1010000 P
1010001 Q
1010010 R
1010011 S
1010100 T
1010101 U
1010110 V
1010111 W
1011000 X
1011001 Y
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 225 of 448
1011010 Z
1011011 .com
1011100 .org
1011101 .net
1011110 .int
1011111 _
1100000 .edu
1100001 a
1100010 b
1100011 c
1100100 d
1100101 e
1100110 f
1100111 g
1101000 h
1101001 i
1101010 j
1101011 k
1101100 l
1101101 m
1101110 n
1101111 o
1110000 p
1110001 q
1110010 r
1110011 s
1110100 t
1110101 u
1110110 v
1110111 w
1111000 x
1111001 y
1111010 z
1111011 .gov
1111100 .mil
1111101 .biz
1111110 .eco
1111111 .med
```
Note that for all 7-bit values not shown in Optimisation Table A, Table 14-9 ("Character table for "Variable-length 7-bit ASCII" encoding
```
```
method") should be used to decode the 7 bits as an ASCII character.
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 226 of 448
```
Table 14-12 - Optimisation Table B1 (14-bit values all beginning with ‘0000000’, for optimised encoding of regional or country-specific top-level
```
```
domains (.ac to .li))
```
14-bit optimised encoding sequence Regional or country-specific top-level domain
```
(.ac to .li)
```
0000000 0000000 .ac
0000000 0000001 .ad
0000000 0000010 .ae
0000000 0000011 .af
0000000 0000100 .ag
0000000 0000101 .ai
0000000 0000110 .al
0000000 0000111 .am
0000000 0001000 .ao
0000000 0001001 .aq
0000000 0001010 .ar
0000000 0001011 .as
0000000 0001100 .at
0000000 0001101 .au
0000000 0001110 .aw
0000000 0001111 .ax
0000000 0010000 .az
0000000 0010001 .ba
0000000 0010010 .bb
0000000 0010011 .bd
0000000 0010100 .be
0000000 0010101 .bf
0000000 0010110 .bg
0000000 0010111 .bh
0000000 0011000 .bi
0000000 0011001 .bj
0000000 0011010 .bm
0000000 0011011 .bn
0000000 0011100 .bo
0000000 0011101 .bq
0000000 0011110 .br
0000000 0011111 .bs
0000000 0100000 .bt
0000000 0100001 .bw
0000000 0100010 .by
0000000 0100011 .bz
0000000 0100100 .ca
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 227 of 448
0000000 0100101 .cc
0000000 0100110 .cd
0000000 0100111 .cf
0000000 0101000 .cg
0000000 0101001 .ch
0000000 0101010 .ci
0000000 0101011 .ck
0000000 0101100 .cl
0000000 0101101 .cm
0000000 0101110 .cn
0000000 0101111 .co
0000000 0110000 .cr
0000000 0110001 .cu
0000000 0110010 .cv
0000000 0110011 .cw
0000000 0110100 .cx
0000000 0110101 .cy
0000000 0110110 .cz
0000000 0110111 .de
0000000 0111000 .dj
0000000 0111001 .dk
0000000 0111010 .dm
0000000 0111011 .do
0000000 0111100 .dz
0000000 0111101 .ec
0000000 0111110 .ee
0000000 0111111 .eg
0000000 1000000 .eh
0000000 1000001 .er
0000000 1000010 .es
0000000 1000011 .et
0000000 1000100 .eu
0000000 1000101 .fi
0000000 1000110 .fj
0000000 1000111 .fk
0000000 1001000 .fm
0000000 1001001 .fo
0000000 1001010 .fr
0000000 1001011 .ga
0000000 1001100 .gd
0000000 1001101 .ge
0000000 1001110 .gf
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 228 of 448
0000000 1001111 .gg
0000000 1010000 .gh
0000000 1010001 .gi
0000000 1010010 .gl
0000000 1010011 .gm
0000000 1010100 .gn
0000000 1010101 .gp
0000000 1010110 .gq
0000000 1010111 .gr
0000000 1011000 .gs
0000000 1011001 .gt
0000000 1011010 .gu
0000000 1011011 .gw
0000000 1011100 .gy
0000000 1011101 .hk
0000000 1011110 .hm
0000000 1011111 .hn
0000000 1100000 .hr
0000000 1100001 .ht
0000000 1100010 .hu
0000000 1100011 .id
0000000 1100100 .ie
0000000 1100101 .il
0000000 1100110 .im
0000000 1100111 .in
0000000 1101000 .io
0000000 1101001 .iq
0000000 1101010 .ir
0000000 1101011 .is
0000000 1101100 .it
0000000 1101101 .je
0000000 1101110 .jm
0000000 1101111 .jo
0000000 1110000 .jp
0000000 1110001 .ke
0000000 1110010 .kg
0000000 1110011 .kh
0000000 1110100 .ki
0000000 1110101 .km
0000000 1110110 .kn
0000000 1110111 .kp
0000000 1111000 .kr
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 229 of 448
0000000 1111001 .kw
0000000 1111010 .ky
0000000 1111011 .kz
0000000 1111100 .la
0000000 1111101 .lb
0000000 1111110 .lc
0000000 1111111 .li
```
Table 14-13 Optimisation Table B2 (14-bit values all beginning with ‘0000001’, for optimised encoding of regional or country-specific top-level
```
```
domains (.lk to .zw))
```
14-bit optimised encoding sequence Regional or country-specific top-level domain
```
(.lk to .zw)
```
0000001 0000000 .lk
0000001 0000001 .lr
0000001 0000010 .ls
0000001 0000011 .lt
0000001 0000100 .lu
0000001 0000101 .lv
0000001 0000110 .ly
0000001 0000111 .ma
0000001 0001000 .mc
0000001 0001001 .md
0000001 0001010 .me
0000001 0001011 .mg
0000001 0001100 .mh
0000001 0001101 .mk
0000001 0001110 .ml
0000001 0001111 .mm
0000001 0010000 .mn
0000001 0010001 .mo
0000001 0010010 .mp
0000001 0010011 .mq
0000001 0010100 .mr
0000001 0010101 .ms
0000001 0010110 .mt
0000001 0010111 .mu
0000001 0011000 .mv
0000001 0011001 .mw
0000001 0011010 .mx
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 230 of 448
0000001 0011011 .my
0000001 0011100 .mz
0000001 0011101 .na
0000001 0011110 .nc
0000001 0011111 .ne
0000001 0100000 .nf
0000001 0100001 .ng
0000001 0100010 .ni
0000001 0100011 .nl
0000001 0100100 .no
0000001 0100101 .np
0000001 0100110 .nr
0000001 0100111 .nu
0000001 0101000 .nz
0000001 0101001 .om
0000001 0101010 .pa
0000001 0101011 .pe
0000001 0101100 .pf
0000001 0101101 .pg
0000001 0101110 .ph
0000001 0101111 .pk
0000001 0110000 .pl
0000001 0110001 .pm
0000001 0110010 .pn
0000001 0110011 .pr
0000001 0110100 .ps
0000001 0110101 .pt
0000001 0110110 .pw
0000001 0110111 .py
0000001 0111000 .qa
0000001 0111001 .re
0000001 0111010 .ro
0000001 0111011 .rs
0000001 0111100 .ru
0000001 0111101 .rw
0000001 0111110 .sa
0000001 0111111 .sb
0000001 1000000 .sc
0000001 1000001 .sd
0000001 1000010 .se
0000001 1000011 .sg
0000001 1000100 .sh
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 231 of 448
0000001 1000101 .si
0000001 1000110 .sk
0000001 1000111 .sl
0000001 1001000 .sm
0000001 1001001 .sn
0000001 1001010 .sr
0000001 1001011 .ss
0000001 1001100 .st
0000001 1001101 .su
0000001 1001110 .sv
0000001 1001111 .sx
0000001 1010000 .sy
0000001 1010001 .sz
0000001 1010010 .tc
0000001 1010011 .td
0000001 1010100 .tf
0000001 1010101 .tg
0000001 1010110 .th
0000001 1010111 .tj
0000001 1011000 .tk
0000001 1011001 .tl
0000001 1011010 .tm
0000001 1011011 .tn
0000001 1011100 .to
0000001 1011101 .tr
0000001 1011110 .tt
0000001 1011111 .tv
0000001 1100000 .tw
0000001 1100001 .tz
0000001 1100010 .ua
0000001 1100011 .ug
0000001 1100100 .us
0000001 1100101 .uy
0000001 1100110 .uz
0000001 1100111 .va
0000001 1101000 .vc
0000001 1101001 .ve
0000001 1101010 .vg
0000001 1101011 .vi
0000001 1101100 .vn
0000001 1101101 .vu
0000001 1101110 .wf
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 232 of 448
0000001 1101111 .ws
0000001 1110000 .ye
0000001 1110001 .yt
0000001 1110010 .za
0000001 1110011 .zm
0000001 1110100 .zw
0000001 1110101 Reserved for future use
0000001 1110110 Reserved for future use
0000001 1110111 Reserved for future use
0000001 1111000 Reserved for future use
0000001 1111001 Reserved for future use
0000001 1111010 Reserved for future use
0000001 1111011 Reserved for future use
0000001 1111100 Reserved for future use
0000001 1111101 Reserved for future use
0000001 1111110 Reserved for future use
0000001 1111111 Reserved for future use
```
Table 14-14 - Optimisation Table B3 (14-bit values all beginning with ‘0000010’, for optimised encoding of compound country-specific TLDs
```
```
(.co.uk etc.))
```
14-bit optimised encoding sequence Compound top-level domain
0000010 0000000 .com.au
0000010 0000001 .net.au
0000010 0000010 .org.au
0000010 0000011 .co.at
0000010 0000100 .com.bd
0000010 0000101 .co.bd
0000010 0000110 .com.br
0000010 0000111 .net.br
0000010 0001000 .co.nz
0000010 0001001 .com.ng
0000010 0001010 .com.pk
0000010 0001011 .co.in
0000010 0001100 .com.in
0000010 0001101 .co.il
0000010 0001110 .co.jp
0000010 0001111 .co.za
0000010 0010000 .co.kr
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 233 of 448
0000010 0010001 .com.es
0000010 0010010 .com.lk
0000010 0010011 .co.th
0000010 0010100 .co.tt
0000010 0010101 .com.tt
0000010 0010110 .com.tr
0000010 0010111 .biz.tr
0000010 0011000 .com.ua
0000010 0011001 .co.uk
0000010 0011010 .co.zm
0000010 0011011 .com.zm
0000010 0011100 .com.cn
0000000 0011101 .org.cn
0000000 0011110 .net.cn
0000010 0011111 .gov.cn
0000010 0100000
to
0000010 1111111
Reserved for future use
```
Table 14-15 Optimisation Table B4 (14-bit values all beginning with ‘0000010’, for optimised encoding of less frequently used gTLDs
```
```
('.tech' etc.)
```
14-bit optimised encoding sequence Compound top-level domain
0000011 0000000 .tech
0000011 0000001
to
0000011 1111111
Reserved for future use
14.5.16.1 Encoding a custom hostname
```
Input:
```
```
The input to the encoding method is a custom hostname (such as ‘example.com’)
```
Validity Test:
The input must consist of a string consisting of string of characters from the GS1 AI-encodable character set 82 and no longer than 63
```
characters in length (excluding 'https://').
```
```
If all characters of the input hostname string are either digits 0-9, upper case letters A-Z, hyphen, colon or full-stop (period/dot), then URN
```
Code 40 encoding may be used to encode the input string. Otherwise, if the input string includes any lower case letters or other symbol
characters, it can only be encoded using 7-bit truncated ASCII encoding, although optimisation sequences may be used.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 234 of 448
14.5.16.1.1 Encoding a hostname using URN Code 40
Create an empty binary string buffer to receive the output. Append one bit '0' to the binary string buffer, to set an encoding indicator value
of '0', indicating URN Code 40 encoding within this method.
Convert the actual length L from a base 10 integer to a binary value, then if necessary, pad to the left with bits of '0' to reach a total length
of 6 bits for the binary string representing the length indicator.
Append this 6-bit binary string representing the length indicator to the binary string buffer.
Working from left to right across the input string, consider each successive group of three characters. If the final group only contains one or
two characters, consider the final group to be appended at the right with two or one pad characters respectively, to reach a total of three
characters.
```
Within each group of three characters, lookup in Table 14-8 of section 14.5.6.5 ("Variable-length URN Code 40") the corresponding index
```
values for each character. i1 is the index value for the first character, i 2 the index for the second character and i 3 is the index for the third
```
character. Calculate r = (1600i 1 + 40i2 + i3 + 1). Convert r to binary and if necessary, left-pad with bits of '0' to reach a total of 16 bits.
```
Append this 16 bit string to the binary string buffer and repeat this process for the next group of three characters until no further groups
remain to be processed.
The contents of the binary string buffer is now the binary output of this encoding method.
14.5.16.1.2 Encoding a hostname using 7-bit truncated ASCII with potential optimisations
Create an empty string buffer to receive the output. Append one bit '1' to the binary string buffer, to set an encoding indicator value of '1',
indicating 7-bit truncated ASCII encoding within this method.
Check the right-hand column of the optimisation tables A, B1, B2 and B3 to check for opportunities to use fewer bits by making use of
optimised encoding sequences.
If not using any optimised encoding sequences when encoding, set L o to the length of the input hostname string instead of proceeding with
the following steps to determine the value of L o.
For example, if the input hostname string is ‘id.example.com’, then ‘id.’ can be encoded using the 7-bit encoding ‘0100000’, while ‘.com’ can
also be encoded using the 7-bit encoding ‘1011011’.
To calculate the optimised length of the input string, take a copy of the input string and remove each occurrence of an optimised encoding
```
sequence (such as ‘id.’ or ‘.com’ etc.), while making a count of the number of 7-bit optimised encoding sequences used and a count of the
```
number of 14-bit encoding sequences used. Let S r be the copy of the input string after all optimisation sequences have been removed.
For example, if the input hostname string is ‘id.example.com’, then optimised encoding sequences for ‘id.’ and ‘.com’ may be used. The
copy of the string with the optimised encoding sequences removed is then simply ‘example’ and we have used two 7-bit optimised encoding
sequences, one for ‘id.’, another for ‘.com’.
The optimised length of the input string L o is the length of S r plus the number of 7-bit optimised encoding sequences plus two times the
number of 14-bit optimised encoding sequences.
```
For example, if the input hostname string is ‘id.example.com’, then S r is ‘example’ and two 7-bit optimised encoding sequences (for ‘id.’ and
```
```
‘com’), so L o is the length of S r ( = 7) plus 2 (one for each 7-bit optimised encoding sequence), so L o is 9.
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 235 of 448
Convert L o to a binary value and if necessary, pad to the left with bits of '0' to reach a total length of 6 bits for the binary string
representing the length indicator.
Append this 6-bit binary string representing the length indicator to the binary string buffer.
Consider the input string, moving the cursor from left to right, with the cursor initially at the start of the string on the first iteration of this
procedure. If any of the previously identified optimised encoding sequences can be found at the current cursor position, append the
corresponding 7-bit or 14-bit encoding sequence to the binary string buffer and move the cursor within the input string past the optimised
encoding sequence that has just been encoded. Otherwise, if none of the previously identified optimised encoding sequences can be found
at the current cursor position, lookup the character immediately to the right of the cursor within Table 14-9 of Section 14.5.6.6 and append
the corresponding 7-bit truncated ASCII value to the binary string buffer and move the cursor one character position to the right. Repeat
this procedure until all characters and optimisation sequences within the input string have been processed and encoded as a corresponding
7-bit or 14-bit value within the binary string buffer.
When all characters of the input string have been processed, the binary output is the contents of the binary string buffer.
14.5.16.2 Decoding a custom hostname
```
Input:
```
The input to the encoding method is a binary string consisting of bits with values ‘0’ or ‘1’
Validity Test:
If the left-most bit is ‘0’, use section 14.5.16.2.1
If the left-most bit is ‘1’, use section 14.5.16.2.2
14.5.16.2.1 Decoding a hostname using URN Code 40
Create an empty string buffer to receive the output. Working from left to right across the binary input string, read the first bit and check
that this is '0', the encoding indicator value for this method. Otherwise, this method cannot be used.
Read 6 bits as the length indicator and convert that unsigned binary integer to a base 10 value L, the number of characters to be read.
Move the cursor of the binary string past the single-bit encoding indicator '0' and the length indicator of 6 bits to begin reading the encoded
data.
```
If L is exactly divisible by 3, the number of iterations n = L/3, otherwise n = ceiling(L/3).
```
Repeat the following procedure n times, reading and processing 16 bits from the input binary string on each iteration and advancing the
cursor accordingly:
For each iteration, convert the 16 bit string to a base 10 unsigned integer r.
```
Calculate i 3 = (r–1)%40 where % is the modulo division operator and (r–1)%40 is the remainder of (r–1) after division by 40.
```
```
Calculate i 2 = ((r–1 – i3 )/40)%40
```
```
Calculate i1 = ((r–1 – i3 – 40i 2 )/1600)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 236 of 448
Lookup i1 in Table 14-8 of section 14.5.6.5 and append the corresponding character to the output string buffer.
If i2 > 0, lookup i2 in Table 14-8 of section 14.5.6.5 and append the corresponding character to the output string buffer.
If i3 > 0, lookup i3 in Table 14-8 of section 14.5.6.5 and append the corresponding character to the output string buffer.
After all n iterations have been completed, the contents of the output string buffer are considered to be the output of this decoding method.
14.5.16.2.2 Decoding a hostname using 7-bit truncated ASCII with potential optimisations.
Create an empty string buffer to receive the output. Working from left to right across the binary input string, read the first bit and check
that this is '1', the encoding indicator value for this method. Otherwise, this method cannot be used.
Read 6 bits as the length indicator and convert that unsigned binary integer to a base 10 value L, the number of repetitions of the main
decoding loop. Move the cursor of the binary string past the single-bit encoding indicator '1' and the length indicator of 6 bits to begin
reading the encoded data.
```
For each repetition of this main decoding loop, read 7 bits of the binary string at (to the right of) the current cursor position.
```
If the initial 7 bits are ‘0000000’, ‘0000001’, ‘0000010’ or ‘0000011’, read a further 7 bits ‘xxxxxxx’ and lookup the combined 14 bits in the
following optimisation tables, depending on the initial 7 bits shown in bold in the table below:
14-bit optimisations Optimisation table to lookup
0000000 xxxxxxx Lookup these 7 bits and the next 7 bits within optimisation table B1
0000001 xxxxxxx Lookup these 7 bits and the next 7 bits within optimisation table B2
0000010 xxxxxxx Lookup these 7 bits and the next 7 bits within optimisation table B3
If a corresponding row for such 14-bit optimisation sequences can be found in any of optimisation tables B1-B3, append the corresponding
alphanumeric optimisation sequence to the output string buffer.
Otherwise, lookup the initial 7 bits in optimisation table A and append the corresponding alphanumeric character or alphanumeric
```
optimisation sequence to the output string buffer. Repeat this main decoding loop until a total of L 7-bit sequences have been read (each
```
```
14-bit sequence counts as two 7-bit sequences), then the output of this decoding method is the value of the output string buffer.
```
14.6 EPC Binary coding tables
This section specifies coding tables for use with the encoding procedure of Section 14.3 and the decoding procedure of Section 14.3.4.
For EPC schemes defined before TDS 2.0. the "Bit Position" row of each coding table illustrates the relative bit positions of segments within
each binary encoding. Before TDS 2.0, the "Bit Position" row only took a 'counting down' approach, in which the highest subscript indicates
the most significant bit, and subscript 0 indicates the least significant bit. Note that this is opposite to the way RFID tag memory bank bit
addresses are normally indicated, where address 0 is the most significant bit. In TDS 2.0, for the older EPC schemes, two "Bit Position"
rows are shown, one taking the previous 'counting down' approach, from most significant bit to least significant bit, with the bit count
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 237 of 448
decreasing from left to right, as well as separate row using the 'counting up' approach, in which b0 is the left-most bit and b0 -b7 always
correspond to the EPC header bits, with the bit count increasing from left to right.
```
For new EPC schemes defined in TDS 2.x (those whose name ends with '+' or '++', e.g. SGTIN+, DSGTIN++), because many of these
```
involve variable-length components and multiple alternative encodings and the possibility of additional +AIDC data appended after the EPC,
the "Bit Position" row of each new EPC coding table is shown only with a 'counting up' approach from left to right, in which b0 is the left-
most bit and b0 -b7 bits always correspond to the EPC header bits. Note that this 'counting up' approach is different from the 'counting
down' approach taken for the older EPC schemes because the total bit count for most of the new EPC schemes is variable, typically
depending on the length and character set used in the actual value being encoded for the serial component, so for most of the new EPC
schemes introduced in TDS 2.0, 'counting down' from the most significant bit at the left to least significant bit at the right cannot even
provide a consistent formula or expression for the numbering the bits that correspond to the header, +AIDC toggle bit, filter bit or primary
GS1 identification key.
Please see section E3 for worked examples of all EPC coding schemes described in section 14.6.
```
14.6.1 Serialised Global Trade Item Number (SGTIN)
```
```
Two coding schemes for the SGTIN are specified, a 96-bit encoding (SGTIN-96) and a 198-bit encoding (SGTIN-198). The SGTIN-198
```
encoding allows for the full range of serial numbers up to 20 alphanumeric characters as specified in [GS1GS]. The SGTIN-96 encoding
```
allows for numeric-only serial numbers, without leading zeros, whose value is less than 2 38 (that is, from 0 through 274,877,906,943,
```
```
inclusive).
```
Both SGTIN coding schemes make reference to the following partition table.
Table 14-16 SGTIN Partition Table
```
Partition Value (P) GS1 Company Prefix Indicator/Pad Digit and Item Reference
```
Bits
```
(M)
```
Digits
```
(L)
```
Bits
```
(N)
```
Digits
0 40 12 4 1
1 37 11 7 2
2 34 10 10 3
3 30 9 14 4
4 27 8 17 5
5 24 7 20 6
6 20 6 24 7
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 238 of 448
14.6.1.1 SGTIN-96 coding table
Table 14-17 SGTIN-96 coding table
Scheme SGTIN-96
URI Template urn:epc:tag:sgtin-96:F.C.I.S
GS1 Digital Link
URI syntax
```
https://id.gs1.org/01/{gtin}/21/{serial}
```
Total Bits 96
Logical Segment EPC
Header
Filter Parti
tion
GS1
Company
```
Prefix (*)
```
Indicator
```
(**) / Item
```
Reference
Serial
Logical Segment
Bit Count
8 3 3 20-40 24-4 38
Logical Segment
Character Count
```
1 digit (0-7) 1
```
digit
```
(6-
```
```
0)
```
6-12 digits 7-1 digits up to 12 digits in range
0 – 274,877,906,943
without preservation of leading zeros
Coding Segment EPC
Header
Filter GTIN Serial
URI portion F C.I S
Coding Segment
Bit Count
8 3 47 38
Bit Position
```
(counting down)
```
b95b94 …b88 b87b86b85 b84b83 …b38 b37b36 …b0
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9b10 b11b12 …b57 b58b59 …b95
Coding Method 00110000 Integer
§14.3.1
§14.4.1
Partition Table 14-16
§14.3.3
§14.4.3
Integer
§14.3.1
§14.4.1
```
(*) See Section 7.3.2 for the case of an SGTIN derived from a GTIN-8.
```
```
(**) Note that in the case of an SGTIN derived from a GTIN-12 or GTIN-13, a zero pad digit takes the place of the Indicator Digit. In all
```
```
cases, see Section 7.3 for the definition of how the Indicator Digit (or zero pad) and the Item Reference are combined into this segment of
```
the EPC.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 239 of 448
14.6.1.2 SGTIN-198 coding table
Table 14-18 SGTIN-198 coding table
Scheme SGTIN-198
URI Template urn:epc:tag:sgtin-198:F.C.I.S
GS1 Digital Link URI
syntax
```
https://id.gs1.org/01/{gtin}/21/{serial}
```
Total Bits 198
Logical Segment EPC
Header
Filter Partition GS1
Company
```
Prefix (*)
```
```
Indicator (**)
```
/ Item
Reference
Serial
Logical Segment Bit
Count
8 3 3 20-40 24-4 140
Logical Segment
Character Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 7-1 digits up to 20 characters
Coding Segment EPC
Header
Filter GTIN Serial
URI portion F C.I S
Coding Segment Bit
Count
8 3 47 140
Bit Position
```
(counting down)
```
b197b196 …
b190
b189b188b18
7
b186b185 …b140 b139b138 …b0
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9b10 b11b12 …b57 b58b59 …b197
Coding Method 0011011
0
Integer
§14.3.1
§14.4.1
Partition Table 14-16
§14.3.3
§14.4.3
String
§14.3.2
§14.4.2
```
(*) See Section 7.3.2 for the case of an SGTIN derived from a GTIN-8.
```
```
(**) Note that in the case of an SGTIN derived from a GTIN-12 or GTIN-13, a zero pad digit takes the place of the Indicator Digit. In all
```
```
cases, see Section 7.3 for the definition of how the Indicator Digit (or zero pad) and the Item Reference are combined into this segment of
```
the EPC.
14.6.1.3 SGTIN+
The SGTIN+ coding scheme uses the following coding table.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 240 of 448
Table 14-5 SGTIN+ coding table
Scheme SGTIN+
GS1 Digital Link
URI syntax
```
https://id.gs1.org/01/{gtin}/21/{serial}
```
Total Bits Up to 216 bits **
Logical Segment EPC Header +Data Toggle Filter GTIN Serial Number
Corresponding
```
GS1 AI (01) (21)
```
Logical Segment
Bit Count
8 1 3 56 3 bit encoding indicator +
5 bit length indicator +
up to 140 bits
Logical Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
14 digits up to 20 characters
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b67 b68b69b70 …
Coding Method 11110111 +AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-Length
Numeric String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Variable-length alphanumeric
§14.5.6
- Note that for the SGTIN+ and all other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is shown
only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the EPC
header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
14.6.1.4 DSGTIN+
The DSGTIN+ coding scheme uses the following coding table.
Table 14-6 DSGTIN+ coding table
Scheme DSGTIN+
GS1 Digital Link
URI syntax
```
https://id.gs1.org/01/{gtin}/21/{serial}
```
Total Bits Up to 236 bits **
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 241 of 448
Scheme DSGTIN+
Logical
Segment
EPC
Head
er
+Data Toggle Filter Date GTIN Serial Number
Corresponding
```
GS1 AI One of(11),(13),(15),(16),
```
```
(17),(7006),(7007)
```
as indicated
```
(01) (21)
```
Logical
Segment Bit
Count
8 1 3 4 bit date type
indicator +
16 bit date value
56 3 bit encoding indicator +
5 bit length indicator +
up to 140 bits
Logical
Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
date type indicator
and 6-digit date
YYMMDD
14 digits up to 20 characters
Bit Position
```
(counting up)*
```
b0b1 …
b7
b8 b9b10b11 b12b13…b30b31 b32b33 …b87 b88b89b90 …
Coding Method 1111
1011
+AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-Length
Numeric String
§14.5.2
Prioritised Date
§14.5.3
Fixed-Length Numeric
§14.5.4
Variable-length alphanumeric
§14.5.6
- Note that for the DSGTIN+ and all other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
14.6.1.5 SGTIN++
The SGTIN++ coding scheme uses the following coding table.
Table 14-5 SGTIN++ coding table
Scheme SGTIN++
GS1 Digital
Link URI
syntax
```
https://{hostname}/01/{gtin}/21/{serial}
```
Total Bits Variable **
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 242 of 448
Scheme SGTIN++
Logical
Segment
EPC
Header
+Data Toggle Filter GTIN Serial Number Hostname
Corresponding
GS1 AI
```
(01) (21)
```
Logical
Segment
Bit Count
8 1 3 56 3 bit encoding indicator +
5 bit length indicator +
up to 140 bits
1 bit encoding indicator +
6 bit length indicator +
up to 240 bits
Logical
Segment
Character
Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
14 digits up to 20 characters up to 63 characters
Bit Position
```
(counting
```
```
up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b67 b68b69b70 … bnbn+1bn+2 …
Coding
Method
11111101 +AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-
Length
Numeric
String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Variable-length alphanumeric
§14.5.6
Custom domain name or hostname
§14.5.16
- Note that for the SGTIN++ and all other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
14.6.1.6 DSGTIN++
The DSGTIN++ coding scheme uses the following coding table.
Table 14-6 DSGTIN++ coding table
Scheme DSGTIN++
GS1
Digital
Link URI
syntax
```
https://{hostname}/01/{gtin}/21/{serial}
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 243 of 448
Scheme DSGTIN++
Total Bits Variable **
Logical
Segment
EPC
Header
+Data
Toggle
Filter Date GTIN Serial Number Hostname
Corresponding
GS1 AI
One of
```
(11),(13),
```
```
(15),(16),
```
```
(17),(7006),(70
```
```
07)
```
as indicated
```
(01) (21)
```
Logical
Segment
Bit Count
8 1 3 4 bit date type
indicator +
16 bit date
value
56 3 bit encoding indicator +
5 bit length indicator +
up to 140 bits
1 bit encoding indicator +
6 bit length indicator +
up to 240 bits
Logical
Segment
Character
Count
1 digit
```
(0 or
```
```
1)
```
1 digit
```
(0-7)
```
date type
indicator and 6-
digit date
YYMMDD
14 digits up to 20 characters up to 63 characters
Bit
Position
```
(counting
```
```
up)*
```
b0b1 …b7 b8 b9b10b11 b12b13…b30b31 b32b33 …b87 b88b89b90 … bnbn+1bn+2 …
Coding
Method
111111
00
+AIDC
Data
Toggle
Bit
§14.5.
1
Fixed-
Bit-
Length
Numeric
String
§14.5.2
Prioritised Date
§14.5.3
Fixed-Length
Numeric
§14.5.4
Variable-length alphanumeric
§14.5.6
Custom domain name or hostname
§14.5.16
- Note that for the DSGTIN++ and all other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
```
14.6.2 Serial Shipping Container Code (SSCC)
```
Two coding schemes for the SSCC are specified:
```
■ SSCC-96 (TDS 1.x) is fixed at 96 bits length, is GCP-partitioned, and allows for the full range of SSCCs as specified in [GS1GS].
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 244 of 448
■ SSCC+ is fixed at 84 bits length, is not GCP-partitioned, and allows for simplified interoperability with the full range of SSCCs in their
GS1 element string form, as specified in [GS1GS].
14.6.2.1 SSCC-96
The SSCC-96 coding scheme uses the following partition table.
Table 14-7 SSCC Partition Table
Partition Value
```
(P)
```
GS1 Company Prefix Extension Digit and Serial Reference
Bits
```
(M)
```
Digits
```
(L)
```
Bits
```
(N)
```
Digits
0 40 12 18 5
1 37 11 21 6
2 34 10 24 7
3 30 9 28 8
4 27 8 31 9
5 24 7 34 10
6 20 6 38 11
The SSCC-96 coding scheme uses the following coding table.
Table 14-8 SSCC-96 coding table
Scheme SSCC-96
URI Template urn:epc:tag:sscc-96:F.C.S
GS1 Digital Link
URI syntax
```
https://id.gs1.org/00/{sscc}
```
Total Bits 96
Logical Segment EPC
Header
Filter Partition GS1 Company
Prefix
Extension / Serial
Reference
```
(Reserved)
```
Logical Segment
Bit Count
8 3 3 20-40 38-18 24
Logical Segment
Character Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 11-5 digits
Coding Segment EPC
Header
```
Filter SSCC (Reserved)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 245 of 448
Scheme SSCC-96
URI portion F C.S
Coding Segment
Bit Count
8 3 61 24
Bit Position
```
(counting down)
```
b95b94 …b8
8
b87b86b85 b84b83 …b24 b23b36 …b0
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9b10 b11b12 …b71 b72b73 …b95
Coding Method 0011000
1
Integer
§14.3.1
§14.4.1
Partition Table 14-7
§14.3.3
§14.4.3
```
00…0 (24 zero bits)
```
14.6.2.2 SSCC+
The SSCC+ coding scheme uses the following coding table.
Table 14-9 SSCC+ coding table
Scheme SSCC+
GS1 Digital Link URI
syntax
```
https://id.gs1.org/00/{sscc}
```
Total Bits 84 **
Logical Segment EPC Header +Data Toggle Filter SSCC
Corresponding
GS1 AI
```
(00)
```
Logical Segment Bit
Count
8 1 3 72
Logical Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
18 digits
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b83
Coding Method 11111001 +AIDC Data Toggle Bit
§14.5.1
Fixed-Bit-Length Numeric
String
§14.5.2
Fixed-Length Numeric
§14.5.4
- Note that for the SSCC+ and other other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 246 of 448
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
14.6.2.3 SSCC++
The SSCC++ coding scheme uses the following coding table.
Table 14-9 SSCC++ coding table
Scheme SSCC++
GS1 Digital Link URI
syntax
```
https://{hostname}/00/{sscc}
```
Total Bits Variable **
Logical Segment EPC Header +Data Toggle Filter SSCC Hostname
Corresponding
GS1 AI
```
(00)
```
Logical Segment Bit
Count
8 1 3 72 1 bit encoding indicator +
6 bit length indicator +
up to *** bits
Logical Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
18 digits up to 63 characters
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b83 bnbn+1bn+2 …
Coding Method 11101111 +AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-Length
Numeric String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Custom domain name or
hostname
§14.5.16
- Note that for the SSCC++ and other other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 247 of 448
```
14.6.3 Global Location Number with or without Extension (SGLN)
```
```
Two coding schemes for the SGLN are specified, a 96-bit encoding (SGLN-96) and a 195-bit encoding (SGLN-195). The SGLN-195 encoding
```
allows for the full range of GLN extensions up to 20 alphanumeric characters as specified in [GS1GS]. The SGLN-96 encoding allows for
```
numeric-only GLN extensions, without leading zeros, whose value is less than 2 41 (that is, from 0 through 2,199,023,255,551, inclusive).
```
Note that an extension value of 0 is reserved to indicate that the SGLN is equivalent to the GLN indicated by the GS1 Company Prefix and
```
location reference; this value is available in both the SGLN-96 and the SGLN-195 encodings.
```
Both SGLN coding schemes make reference to the following partition table.
Table 14-10 SGLN Partition Table
Partition Value
```
(P)
```
GS1 Company Prefix Location Reference
Bits
```
(M)
```
Digits
```
(L)
```
Bits
```
(N)
```
Digits
0 40 12 1 0
1 37 11 4 1
2 34 10 7 2
3 30 9 11 3
4 27 8 14 4
5 24 7 17 5
6 20 6 21 6
14.6.3.1 SGLN-96 coding table
Table 14-11 SGLN-96 coding table
Scheme SGLN-96
URI Template urn:epc:tag:sgln-96:F.C.L.E
GS1 Digital Link
URI syntax
```
https://id.gs1.org/414/{gln}/254/{glnextension}
```
Total Bits 96
Logical Segment EPC Header Filter Partition GS1 Company Prefix Location Reference Extension
Logical Segment
Bit Count
8 3 3 20-40 21-1 41
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 248 of 448
Scheme SGLN-96
Logical Segment
Character Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 6-0 digits Up to 13 digits in range 0 –
2,199,023,255,551
without preservation of leading
zeros
Coding Segment EPC Header Filter GLN Extension
URI portion F C.L E
Coding Segment
Bit Count
8 3 44 41
Bit Position
```
(counting down)
```
b95b94 …b88 b87b86b85 b84b83 …b41 b40b39 …b0
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9b10 b11b12 …b54 b55b56 …b95
Coding Method 00110010 Integer
§14.3.1
§14.4.1
Partition Table 14-10
§14.3.3
§14.4.3
Integer
§14.3.1
§14.4.1
14.6.3.2 SGLN-195 coding table
Table 14-12 SGLN-195 coding table
Scheme SGLN-195
URI Template urn:epc:tag:sgln-195:F.C.L.E
GS1 Digital Link
URI syntax
```
https://id.gs1.org/414/{gln}/254/{glnextension}
```
Total Bits 195
Logical Segment EPC Header Filter Partition GS1 Company
Prefix
Location Reference Extension
Logical Segment
Bit Count
8 3 3 20-40 21-1 140
Logical Segment
Character Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 6-0 digits up to 20 characters
Coding Segment EPC Header Filter GLN Extension
URI portion F C.L E
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 249 of 448
Scheme SGLN-195
Coding Segment
Bit Count
8 3 44 140
Bit Position
```
(counting down)
```
b194b193 …b187 b186b185b184 b183b182 …b140 b139b138 …b0
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9b10 b11b12 …b54 b55b56 …b194
Coding Method 00111001 Integer
§14.3.1
§14.4.1
Partition Table 14-10
§14.3.3
§14.4.3
String
§14.3.2
§14.4.2
14.6.3.3 SGLN+
The SGLN+ coding scheme uses the following coding table.
Table 14-13 SGLN+ coding table
Scheme SGLN+
GS1 Digital Link URI
syntax
```
https://id.gs1.org/414/{gln}/254/{glnextension}
```
Total Bits Up to 212 bits **
Logical Segment EPC Header +Data Toggle Filter GLN GLN Extension
Corresponding
GS1 AI
```
(414) (254)
```
Logical Segment Bit
Count
8 1 3 52 3 bit encoding indicator +
5 bit length indicator +
up to 140 bits for GLN Extension
Logical Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
13 digits up to 20 characters
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b63 b64b65b66 …
Coding Method 11110010 +AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-Length
Numeric String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Variable-length alphanumeric
§14.5.6
- Note that for the SGLN+ and other other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 250 of 448
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
14.6.3.4 SGLN++
The SGLN++ coding scheme uses the following coding table.
Table 14-13 SGLN++ coding table
Scheme SGLN++
GS1 Digital Link
URI syntax
```
https://{hostname}/414/{gln}/254/{glnextension}
```
Total Bits Variable **
Logical Segment EPC Header +Data Toggle Filter GLN GLN Extension Hostname
Corresponding
GS1 AI
```
(414) (254)
```
Logical Segment
Bit Count
8 1 3 52 3 bit encoding indicator
+
5 bit length indicator +
up to 140 bits for GLN
Extension
1 bit encoding indicator +
6 bit length indicator +
up to *** bits
Logical Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
13 digits up to 20 characters up to 63 characters
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b63 b64b65b66 … bnbn+1bn+2 …
Coding Method 11101001 +AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-Length
Numeric String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Variable-length
alphanumeric
§14.5.6
Custom domain name or
hostname
§14.5.16
- Note that for the SGLN++ and other other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 251 of 448
```
14.6.4 Global Returnable Asset Identifier (GRAI)
```
```
Two coding schemes for the GRAI are specified, a 96-bit encoding (GRAI-96) and a 170-bit encoding (GRAI-170). The GRAI-170 encoding
```
allows for the full range of serial numbers up to 16 alphanumeric characters as specified in [GS1GS]. The GRAI-96 encoding allows for
```
numeric-only serial numbers, without leading zeros, whose value is less than 2 38 (that is, from 0 through 274,877,906,943, inclusive).
```
Only GRAIs that include the optional serial number may be represented as EPCs. A GRAI without a serial number represents an asset class,
```
rather than a specific instance, and therefore may not be used as an EPC (just as a non-serialised GTIN may not be used as an EPC).
```
Both GRAI coding schemes make reference to the following partition table.
Table 14-19 GRAI Partition Table
Partition Value
```
(P)
```
Company Prefix Asset Type
Bits
```
(M)
```
```
Digits (L) Bits
```
```
(N)
```
Digits
0 40 12 4 0
1 37 11 7 1
2 34 10 10 2
3 30 9 14 3
4 27 8 17 4
5 24 7 20 5
6 20 6 24 6
14.6.4.1 GRAI-96 coding table
Table 14-15 GRAI-96 coding table
Scheme GRAI-96
URI Template urn:epc:tag:grai-96:F.C.A.S
GS1 Digital Link
URI syntax
```
https://id.gs1.org/8003/{grai}
```
Total Bits 96
Logical Segment EPC Header Filter Partition GS1 Company Prefix Asset Type Serial
Logical Segment
Bit Count
8 3 3 20-40 24-4 38
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 252 of 448
Scheme GRAI-96
Logical Segment
Character Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digit 6-0 digits Up to 12 digits in range
0 –
274,877,906,943
without preservation of leading
zeros
Coding Segment EPC Header Filter Partition + Company Prefix + Asset Type Serial
URI portion F C.A S
Coding Segment
Bit Count
8 3 47 38
Bit Position
```
(counting down)
```
b95b94 …b88 b87b86b85 b84b83 …b38 b37b36 …b0
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9b10 b11b12 …b57 b58b59 …b95
Coding Method 00110011 Integer
§14.3.1
§14.4.1
Partition Table 14-19
§14.3.3
§14.4.3
Integer
§14.3.1
§14.4.1
14.6.4.2 GRAI-170 coding table
Table 14-20 GRAI-170 coding table
Scheme GRAI-170
URI Template urn:epc:tag:grai-170:F.C.A.S
GS1 Digital Link
URI syntax
```
https://id.gs1.org/8003/{grai}
```
Total Bits 170
Logical Segment EPC Header Filter Partition GS1 Company
Prefix
Asset Type Serial
Logical Segment
Bit Count
8 3 3 20-40 24-4 112
Logical Segment
Character Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 6-0 digits Up to 16 characters
Coding Segment EPC Header Filter Partition + Company Prefix + Asset Type Serial
URI portion F C.A S
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 253 of 448
Scheme GRAI-170
Coding Segment
Bit Count
8 3 47 112
Bit Position
```
(counting down)
```
b169b168 …b162 b161b160b159 b158b157 …b112 b111b110 …b0
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9b10 b11b12 …b57 b58b59 …b169
Coding Method 00110111 Integer
§14.3.1
§14.4.1
Partition Table 14-19
§14.3.3
§14.4.3
String
§14.3.2
§14.4.2
14.6.4.3 GRAI+
The GRAI+ coding scheme uses the following coding table.
Table 14-21 GRAI+ coding table
Scheme GRAI+
GS1 Digital Link URI
syntax
```
https://id.gs1.org/8003/{grai}
```
Total Bits Up to 188 bits **
Logical Segment EPC Header +Data Toggle Filter Leading pad '0' then
13-digit GRAI
GRAI
Serial Component
Corresponding
GS1 AI
```
(8003)
```
Logical Segment Bit
Count
8 1 3 56 3 bit encoding indicator +
5 bit length indicator +
up to 112 bits
Logical Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
14 digits Up to 16 characters
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b67 b68b69b70 …
Coding Method 11110001 +AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-Length
Numeric String
§14.5.2
Fixed-Length Numeric
§14.5.4
Variable-length alphanumeric
§14.5.6
- Note that for the GRAI+ and other other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 254 of 448
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
14.6.4.4 GRAI++
The GRAI++ coding scheme uses the following coding table.
Table 14-22 GRAI++ coding table
Scheme GRAI++
GS1 Digital Link
URI syntax
```
https://{hostname}/8003/{grai}
```
Total Bits Variable **
Logical Segment EPC
Header
+Data
Toggle
Filter Leading pad '0'
then 13-digit
GRAI
GRAI
Serial Component
Hostname
Corresponding
GS1 AI
```
(8003)
```
Logical Segment
Bit Count
8 1 3 56 3 bit encoding indicator
+
5 bit length indicator +
up to 112 bits
1 bit encoding indicator +
6 bit length indicator +
up to *** bits
Logical Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
14 digits Up to 16 characters up to 63 characters
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b67 b68b69b70 … bnbn+1bn+2 …
Coding Method 11101011 +AIDC
Data
Toggle Bit
§14.5.1
Fixed-Bit-Length
Numeric String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Variable-length
alphanumeric
§14.5.6
Custom domain name or hostname
§14.5.16
- Note that for the GRAI++ and other other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 255 of 448
```
14.6.5 Global Individual Asset Identifier (GIAI)
```
```
Two coding schemes for the GIAI are specified, a 96-bit encoding (GIAI-96) and a 202-bit encoding (GIAI-202). The GIAI-202 encoding
```
allows for the full range of serial numbers up to 24 alphanumeric characters as specified in [GS1GS]. The GIAI-96 encoding allows for
numeric-only serial numbers, without leading zeros, whose value is, up to a limit that varies with the length of the GS1 Company Prefix.
Each GIAI coding schemes make reference to a different partition table, specified alongside the corresponding coding table in the
subsections below.
14.6.5.1 GIAI-96 Partition Table and coding table
The GIAI-96 coding scheme makes use of the following partition table.
Table 14-23 GIAI-96 Partition Table
Partition Value
```
(P)
```
Company Prefix Individual Asset Reference
Bits
```
(M)
```
Digits
```
(L)
```
Bits
```
(N)
```
```
Max Digits (K)
```
0 40 12 42 13
1 37 11 45 14
2 34 10 48 15
3 30 9 52 16
4 27 8 55 17
5 24 7 58 18
6 20 6 62 19
Table 14-24 GIAI-96 coding table
Scheme GIAI-96
URI Template urn:epc:tag:giai-96:F.C.A
GS1 Digital Link URI
syntax
```
https://id.gs1.org/8004/{giai}
```
Total Bits 96
Logical Segment EPC Header Filter Partition GS1 Company Prefix Individual Asset Reference
Logical Segment Bit
Count
8 3 3 20-40 62–42
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 256 of 448
Scheme GIAI-96
Logical Segment
Character Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 19-13 digits
without preservation of leading zeros
Coding Segment EPC Header Filter GIAI
URI portion F C.A
Coding Segment Bit
Count
8 3 85
Bit Position
```
(counting down)
```
b95b94 …b88 b87b86b85 b84b83 …b0
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9b10 b11b12 …b95
Coding Method 00110100 Integer
§14.3.1
§14.4.1
Unpadded Partition Table 14-23
§14.3.4
§14.4.4
14.6.5.2 GIAI-202 Partition Table and coding table
The GIAI-202 coding scheme makes use of the following partition table.
Table 14-20 GIAI-202 Partition Table
Partition Value
```
(P)
```
Company Prefix Individual Asset Reference
Bits
```
(M)
```
Digits
```
(L)
```
Bits
```
(N)
```
Maximum
Characters
0 40 12 148 18
1 37 11 151 19
2 34 10 154 20
3 30 9 158 21
4 27 8 161 22
5 24 7 164 23
6 20 6 168 24
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 257 of 448
Table 14-21 GIAI-202 coding table
Scheme GIAI-202
URI Template urn:epc:tag:giai-202:F.C.A
GS1 Digital Link URI
syntax
```
https://id.gs1.org/8004/{giai}
```
Total Bits 202
Logical Segment EPC Header Filter Partition GS1 Company
Prefix
Individual Asset Reference
Logical Segment Bit
Count
8 3 3 20-40 168–148
Logical Segment
Character Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 24-18 characters
Coding Segment EPC Header Filter GIAI
URI portion F C.A
Coding Segment Bit
Count
8 3 191
Bit Position
```
(counting down)
```
b201b200 …b194 b193b192b191 b190b189 …b0
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9b10 b11b12 …b201
Coding Method 00111000 Integer
§14.3.1
§14.4.1
String Partition Table 14-20
§14.3.5
§14.4.5
14.6.5.3 GIAI+ Coding table
The GIAI+ coding scheme makes use of the following coding table.
Table 14-22 GIAI+ coding table
Scheme GIAI+
GS1 Digital Link URI
syntax
```
https://id.gs1.org/8004/{giai}
```
```
Total Bits Up to 222 bits (assuming shortest initial all-numeric sequence to be 4 digits) **
```
Logical Segment EPC Header +Data Toggle Filter GIAI
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 258 of 448
Scheme GIAI+
Corresponding
GS1 AI
```
(8004)
```
Logical Segment Bit
Count
```
8 1 3 4n (for initial n digits) + 4 bit terminator
```
OR
```
4n (for initial n digits) + 4 bit delimiter
```
- 3 bit encoding indicator +
5 bit length indicator +
```
up to (210-7n) bits
```
Logical Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
Up to 30 characters
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …
Coding Method 11111010 +AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-Length
Numeric String
§14.5.2
```
Delimited/terminated Numeric (§14.5.5)
```
```
(followed by Variable-length alphanumeric
```
```
(§14.5.6) for any characters after the initial n
```
```
digits)
```
- Note that for the GIAI+ and other other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
14.6.5.4 GIAI++ Coding table
The GIAI++ coding scheme makes use of the following coding table.
Table 14-22 GIAI++ coding table
Scheme GIAI++
GS1 Digital Link URI
syntax
```
https://{hostname}/8004/{giai}
```
Total Bits Variable **
Logical Segment EPC Header +Data Toggle Filter GIAI Hostname
Corresponding
GS1 AI
```
(8004)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 259 of 448
Scheme GIAI++
Logical Segment Bit
Count
```
8 1 3 4n (for initial n digits) + 4
```
bit terminator
OR
```
4n (for initial n digits) + 4
```
bit delimiter
- 3 bit encoding indicator +
5 bit length indicator +
```
up to (210-7n) bits
```
1 bit encoding indicator +
6 bit length indicator +
up to *** bits
Logical Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
Up to 30 characters up to 63 characters
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 … bnbn+1bn+2 …
Coding Method 11101110 +AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-Length
Numeric String
§14.5.2
Delimited/terminated
```
Numeric (§14.5.5)
```
```
(followed by Variable-length
```
```
alphanumeric (§14.5.6) for
```
any characters after the
```
initial n digits)
```
Custom domain name or hostname
§14.5.16
- Note that for the GIAI++ and other other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
```
14.6.6 Global Service Relation Number - Recipient (GSRN)
```
Two encoding schemes for the GSRN are specified:
```
• GSRN-96 (TDS 1.x) is fixed at 96 bits length, is GCP-partitioned, and allows for the full range of "Recipient" GSRNs corresponding
```
```
to AI (8018), as specified in [GS1GS].
```
• GSRN+ is fixed at 84 bits length, is not GCP-partitioned, and allows for simplified interoperability with the full range of "Recipient"
```
GSRNs corresponding to AI (8018), in their GS1 element string form, as specified in [GS1GS].
```
14.6.6.1 GSRN-96
The GSRN-96 coding scheme uses the following partition table.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 260 of 448
Table 14-23 GSRN Partition Table
Partition Value
```
(P)
```
Company Prefix Service Reference
Bits
```
(M)
```
Digits
```
(L)
```
Bits
```
(N)
```
Digits
0 40 12 18 5
1 37 11 21 6
2 34 10 24 7
3 30 9 28 8
4 27 8 31 9
5 24 7 34 10
6 20 6 38 11
The GSRN-96 coding scheme uses the following coding table.
Table 14-24 GSRN-96 coding table
Scheme GSRN-96
URI Template urn:epc:tag:gsrn-96:F.C.S
GS1 Digital Link
URI syntax
```
https://id.gs1.org/8018/{gsrn}
```
Total Bits 96
Logical Segment EPC Header Filter Partition GS1 Company
Prefix
```
Service Reference (Reserved)
```
Logical Segment
Bit Count
8 3 3 20-40 38-18 24
Logical Segment
Character Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 11-5 digits
```
Coding Segment EPC Header Filter GSRN (Reserved)
```
URI portion F C.S
Coding Segment
Bit Count
8 3 61 24
Bit Position
```
(counting down)
```
b95b94 …b88 b87b86b85 b84b83 …b24 b23b22 …b0
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 261 of 448
Scheme GSRN-96
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9b10 b11b12 …b71 b72b73 …b95
Coding Method 00101101 Integer
§14.3.1
§14.4.1
Partition Table 14-23
§14.3.3
§14.4.3
00…0
```
(24 zero bits)
```
14.6.6.2 GSRN+
The GSRN+ coding scheme uses the following coding table.
Table 14-25 GSRN+ coding table
Scheme GSRN+
GS1 Digital Link URI
syntax
```
https://id.gs1.org/8018/{gsrn}
```
Total Bits 84 **
Logical Segment EPC Header +Data Toggle Filter GSRN
Corresponding
GS1 AI 8018
Logical Segment Bit
Count
8 1 3 72
Logical Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
18 digits
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b83
Coding Method 11110100 +AIDC Data Toggle Bit
§14.5.1
Fixed-Bit-Length Numeric
String
§14.5.2
Fixed-Length Numeric
§14.5.4
- Note that for the GSRN+ and other other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 262 of 448
14.6.6.3 GSRN++
The GSRN++ coding scheme uses the following coding table.
Table 14-25 GSRN++ coding table
Scheme GSRN++
GS1 Digital Link URI
syntax
```
https://{hostname}/8018/{gsrn}
```
Total Bits Variable **
Logical Segment EPC Header +Data Toggle Filter GSRN Hostname
Corresponding
GS1 AI 8018
Logical Segment Bit
Count
8 1 3 72 1 bit encoding indicator +
6 bit length indicator +
up to *** bits
Logical Segment
Character Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
18 digits up to 63 characters
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b83 bnbn+1bn+2 …
Coding Method 11100111 +AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-Length
Numeric String
§14.5.2
Fixed-Length Numeric
§14.5.4
Custom domain name or hostname
§14.5.16
- Note that for the GSRN++ and other other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
```
14.6.7 Global Service Relation Number - Provider (GSRNP)
```
Two encoding schemes for the GSRNP are specified:
```
■ GSRNP-96 (TDS 1.x) is fixed at 96 bits length, is GCP-partitioned, and allows for the full range of "Provider" GSRNs corresponding to
```
```
AI (8017), as specified in [GS1GS].
```
■ GSRNP+ is fixed at 84 bits length, is not GCP-partitioned, and allows for simplified interoperability with the full range of "Provider"
```
GSRNs corresponding to AI (8018), in their GS1 element string form, as specified in [GS1GS].
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 263 of 448
14.6.7.1 GSRNP-96
The GSRNP-96 coding scheme uses the following partition table.
Table 14-26 GSRNP Partition Table
Partition Value
```
(P)
```
Company Prefix Service Reference
Bits
```
(M)
```
Digits
```
(L)
```
Bits
```
(N)
```
Digits
0 40 12 18 5
1 37 11 21 6
2 34 10 24 7
3 30 9 28 8
4 27 8 31 9
5 24 7 34 10
6 20 6 38 11
The GSRNP-96 coding scheme uses the following coding table.
Table 14-27 GSRNP-96 coding table
Scheme GSRNP-96
URI Template urn:epc:tag:gsrnp-96:F.C.S
GS1 Digital Link
URI syntax
```
https://id.gs1.org/8017/{gsrnp}
```
Total Bits 96
Logical Segment EPC
Header
Filter Partition GS1 Company
Prefix
```
Service Reference (Reserved)
```
Logical Segment
Bit Count
8 3 3 20-40 38-18 24
Logical Segment
Character Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 11-5 digits
Coding Segment EPC
Header
```
Filter GSRN (Reserved)
```
URI portion F C.S
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 264 of 448
Scheme GSRNP-96
Coding Segment
Bit Count
8 3 61 24
Bit Position
```
(counting down)
```
b95b94 …b88 b87b86b85 b84b83 …b24 b23b22 …b0
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9b10 b11b12 …b71 b72b73 …b95
Coding Method 00101110 Integer
§14.3.1
§14.4.1
Partition Table 14-23
§14.3.3
§14.4.3
00…0
```
(24 zero bits)
```
14.6.7.2 GSRNP+
The GSRNP+ coding scheme uses the following coding table.
Table 14-28 GSRNP+ coding table
Scheme GSRNP+
GS1 Digital Link
URI syntax
```
https://id.gs1.org/8017/{gsrnp}
```
Total Bits 84 **
Logical
Segment
EPC Header +Data
Toggle
Filter GSRN
Corresponding
GS1 AI
8017
Logical
Segment Bit
Count
8 1 3 72
Logical
Segment
Character
Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
18 digits
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b83
Coding Method 11110101 +AIDC
Data
Toggle Bit
§14.5.1
Fixed-Bit-
Length
Numeric
String
§14.5.2
Fixed-Length Numeric
§14.5.4
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 265 of 448
- Note that for the GSRNP+ and other other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
14.6.7.3 GSRNP++
The GSRNP++ coding scheme uses the following coding table.
Table 14-28 GSRNP++ coding table
Scheme GSRNP++
GS1 Digital
Link URI
syntax
```
https://{hostname}/8017/{gsrnp}
```
Total Bits Variable **
Logical
Segment
EPC Header +Data
Toggle
Filter GSRN Hostname
Corresponding
GS1 AI
8017
Logical
Segment Bit
Count
8 1 3 72 1 bit encoding indicator +
6 bit length indicator +
up to *** bits
Logical
Segment
Character
Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
18 digits up to 63 characters
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b83 bnbn+1bn+2 …
Coding
Method
11101000 +AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-
Length
Numeric
String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Custom domain name or
hostname
§14.5.16
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 266 of 448
- Note that for the GSRNP++ and other other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
```
14.6.8 Global Document Type Identifier (GDTI)
```
```
Three coding schemes for the GDTI specified, a 96-bit encoding (GDTI-96), a 113-bit encoding (GDTI-113, DEPRECATED as of TDS 1.9),
```
```
and a 174-bit encoding (GDTI-174). The GDTI-174 encoding allows for the full range of document serialisation up to 17 alphanumeric
```
characters, as specified in [GS1GS]. The deprecated GDTI-113 encoding allows for a reduced range of document serial numbers up to 17
```
numeric characters (including leading zeros) as originally specified in [GS1GS]. The GDTI-96 encoding allows for document serial numbers
```
```
without leading zeros whose value is less than 2 41 (that is, from 0 through 2,199,023,255,551, inclusive).
```
Only GDTIs that include the optional serial number may be represented as EPCs. A GDTI without a serial number represents a document
```
class, rather than a specific document, and therefore may not be used as an EPC (just as a non-serialised GTIN may not be used as an
```
```
EPC).
```
Both GDTI coding schemes make reference to the following partition table.
Table 14-29 GDTI Partition Table
Partition Value
```
(P)
```
Company Prefix Document Type
Bits
```
(M)
```
Digits
```
(L)
```
Bits
```
(N)
```
Digits
0 40 12 1 0
1 37 11 4 1
2 34 10 7 2
3 30 9 11 3
4 27 8 14 4
5 24 7 17 5
6 20 6 21 6
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 267 of 448
14.6.8.1 GDTI-96 coding table
Table 14-30 GDTI-96 coding table
Scheme GDTI-96
URI
Template
```
urn:epc:tag:gdti-96:F.C.D.S
```
GS1 Digital
Link URI
syntax
```
https://id.gs1.org/253/{gdti}
```
Total Bits 96
Logical
Segment
EPC Header Filter Partition GS1
Company
Prefix
Document
Type
Serial
Logical
Segment
Bit Count
8 3 3 20-40 21-1 41
Logical
Segment
Character
Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 6-0 digits Up to 13
digits in
range
0 –
2,199,023,2
55,551
without
preservation
of leading
zeros
Coding
Segment
EPC Header Filter Partition + Company Prefix + Document Type Serial
URI portion F C.D S
Coding
Segment
Bit Count
8 3 44 41
Bit Position
```
(counting
```
```
down)
```
b95b94 …b88 b87b86b85 b84b83 …b41 b40b39 …b0
Bit Position
```
(counting
```
```
up)
```
b0b1 …b7 b8b9b10 b11b12 …b54 b55b56 …b95
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 268 of 448
Scheme GDTI-96
Coding
Method
00101100 Integer
§14.3.1
§14.4.1
Partition Table 14-29
§14.3.3
§14.4.3
Integer
§14.3.1
§14.4.1
14.6.8.2 GDTI-113 coding table
Table 14-31 GDTI-113 coding table
Scheme GDTI-113
URI
Template
```
urn:epc:tag:gdti-113:F.C.D.S
```
GS1 Digital
Link URI
syntax
```
https://id.gs1.org/253/{gdti}
```
Total Bits 113
Logical
Segment
EPC Header Filter Partition GS1
Company
Prefix
Document
Type
Serial
Logical
Segment
Bit Count
8 3 3 20-40 21-1 58
Logical
Segment
Character
Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 6-0 digits Up to 17
digits
without
preservation
of leading
zeros
Coding
Segment
EPC Header Filter Partition + Company Prefix + Document
Type
Serial
URI
portion
F C.D S
Coding
Segment
Bit Count
8 3 44 58
Bit Position
```
(counting
```
```
down)
```
b112b111 …b105 b104b103b 102 b101b100 …b58 b57b 56…b0
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 269 of 448
Scheme GDTI-113
Bit Position
```
(counting
```
```
up)
```
b0b1 …b7 b8b9b 10 b11b12 …b54 b55b 56…b112
Coding
Method
00111010 Integer
§14.3.1
§14.4.1
Partition Table 14-29 Numeric
String
§14.3.6
14.6.8.3 GDTI-174 coding table
Table 14-32 GDTI-174 coding table
Scheme GDTI-174
URI
Template
```
urn:epc:tag:gdti-174:F.C.A.S
```
Total Bits 174
Logical
Segment
EPC Header Filter Partition GS1
Company
Prefix
Document
Type
Serial
Logical
Segment
Bit Count
8 3 3 20-40 21-1 119
Logical
Segment
Character
Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 6-0 digits Up to 17
characters
Coding
Segment
EPC Header Filter Partition + Company Prefix + Asset
Type
Serial
URI
portion
F C.A S
Coding
Segment
Bit Count
8 3 44 119
Bit
Position
```
(counting
```
```
down)
```
b173b172 …b166 b165b164b163 b162b161 …b119 b118b117 …b0
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 270 of 448
Scheme GDTI-174
Bit
Position
```
(counting
```
```
up)
```
b0b1 …b7 b8b9b10 b11b12 …b54 b55b56 …b 173
Coding
Method
00111110 Integer
§14.3.1
§14.4.1
Partition Table 14-29
§14.3.3
§14.4.3
String
§14.3.2
§14.4.2
14.6.8.4 GDTI+
The GDTI+ coding scheme uses the following coding table.
Table 14-33 GDTI+ coding table
Scheme GDTI+
GS1 Digital Link
URI syntax
```
https://id.gs1.org/253/{gdti}
```
Total Bits Up to 191 bits **
Logical
Segment
EPC Header +Data
Toggle
Filter GDTI GDTI
Serial Component
Corresponding
GS1 AI
```
(253)
```
Logical
Segment Bit
Count
8 1 3 52 3 bit encoding
indicator +
5 bit length
indicator +
up to 119 bits
Logical
Segment
Character
Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
13 digits Up to 17
characters
Bit Position
```
(counting up)*
```
```
b0b1 …b7 b8 b9b10b11 b12b13 …b63 b64b65 … b(B-1)
```
Coding Method 11110110 +AIDC
Data
Toggle Bit
§14.5.1
Fixed-Bit-
Length
Numeric
String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Variable-length
alphanumeric
§14.5.6
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 271 of 448
- Note that for the GDTI+ and other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is shown
only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the EPC
header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
14.6.8.5 GDTI++
The GDTI++ coding scheme uses the following coding table.
Table 14-33 GDTI++ coding table
Scheme GDTI++
GS1 Digital
Link URI
syntax
```
https://{hostname}/253/{gdti}
```
Total Bits Variable **
Logical
Segment
EPC
Header
+Dat
a
Toggl
e
Filter GDTI GDTI
Serial Component
Hostname
Correspondin
g
GS1 AI
```
(253)
```
Logical
Segment Bit
Count
8 1 3 52 3 bit encoding
indicator +
5 bit length
indicator +
up to 119 bits
1 bit encoding
indicator +
6 bit length
indicator +
up to *** bits
Logical
Segment
Character
Count
1
digit
```
(0 or
```
```
1)
```
1 digit
```
(0-7)
```
13 digits Up to 17
characters
up to 63 characters
Bit Position
```
(counting up)*
```
```
b0b1 …b7 b8 b9b10b11 b12b13 …b63 b64b65 … b(B-1) bnbn+1bn+2 …
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 272 of 448
Scheme GDTI++
Coding
Method
111010
10
+AID
C
Data
Toggl
e Bit
§14.5
.1
Fixed-
Bit-
Length
Numeric
String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Variable-length
alphanumeric
§14.5.6
Custom domain
name or hostname
§14.5.16
- Note that for the GDTI++ and other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is shown
only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the EPC
header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
```
14.6.9 CPI Identifier (CPI)
```
Two coding schemes for the CPI identifier are specified: the 96-bit scheme CPI-96 and the variable-length encoding CPI-var. CPI-96 makes
use of Partition Table 14-34 and CPI-var makes use of Partition Table 14-35.
Table 14-34 CPI-96 Partition Table
Partition Value
```
(P)
```
GS1 Company Prefix Component/Part Reference
Bits
```
(M)
```
```
Digits (L) Bits
```
```
(N)
```
Maximum Digits
0 40 12 11 3
1 37 11 14 4
2 34 10 17 5
3 30 9 21 6
4 27 8 24 7
5 24 7 27 8
6 20 6 31 9
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 273 of 448
Table 14-35 CPI-var Partition Table
Partition Value
```
(P)
```
GS1 Company Prefix Component/Part Reference
Bits
```
(M)
```
```
Digits (L) Maximum Bits **
```
```
(N)
```
Maximum
Characters
0 40 12 114 18
1 37 11 120 19
2 34 10 126 20
3 30 9 132 21
4 27 8 138 22
5 24 7 144 23
6 20 6 150 24
```
** The number of bits depends on the number of characters in the Component/Part Reference; see Sections 14.3.9 and 14.4.9.
```
14.6.9.1 CPI-96 coding table
Table 14-25 CPI-96 coding table
Scheme CPI-96
URI
Template
```
urn:epc:tag:cpi-96:F.C.P.S
```
GS1
Digital
Link URI
syntax
```
https://id.gs1.org/8010/{cpi}/8011/{cpi_serial}
```
Total Bits 96
Logical
Segment
EPC Header Filter Partition GS1
Company
Prefix
Component /
Part Reference
Serial
Logical
Segment
Bit Count
8 3 3 20-40 31-11 31
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 274 of 448
Scheme CPI-96
Logical
Segment
Character
Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 9-3 digits
without
preservation of
leading zeros
Up to 10 digits
in range
0 -
2,147,483,647
without
preservation
of leading
zeros
Coding
Segment
EPC Header Filter Component/Part Identifier Component /
Part Serial
Number
URI
portion
F C.P S
Coding
Segment
Bit Count
8 3 54 31
Bit
Position
```
(counting
```
```
down)
```
b95b94 …b88 b87b86b85 b84b83 …b31 b30b29 …b0
Bit
Position
```
(counting
```
```
up)
```
b0b1 …b7 b8b9b10 b11b12 …b64 b65b67 …b95
Coding
Method
00111100 Integer
§14.3.1
§14.4.1
Unpadded Partition Table 14-34
§14.3.4
§14.4.4
Integer
§14.3.1
§14.4.1
14.6.9.2 CPI-var coding table
Table 14-26 CPI-var coding table
Scheme CPI-var
URI
Template
```
urn:epc:tag:cpi-var:F.C.P.S
```
GS1 Digital
Link URI
syntax
```
https://id.gs1.org/8010/{cpi}/8011/{cpi_serial}
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 275 of 448
Scheme CPI-var
```
Total Bits Variable: between 86 and 224 bits (inclusive)
```
Logical
Segment
EPC Header Filter Partition GS1
Company
Prefix
Component /
Part
Reference
Serial
Logical
Segment
Bit Count
8 3 3 20-40 12-150
```
(variable)
```
```
40 (fixed)
```
Logical
Segment
Character
Count
```
1 digit (0-7) 1 digit
```
```
(6-0)
```
6-12 digits 24-18
characters
Up to 12 digits
without
preservation
of leading
zeros
Coding
Segment
EPC Header Filter Component/Part Identifier Component /
Part Serial
Number
URI
portion
F C.P S
Coding
Segment
Bit Count
8 3 Up to 173 bits 40
Bit
Position
```
(counting
```
```
down)
```
bB-1bB-2 …
bB-8
bB-9bB-10bB-11 bB-12bB-13 …b40 b39b38 …b0
Bit
Position
```
(counting
```
```
up)
```
```
b0b1 …b7 b8b9b10 b11bB-13 …b(B-41) b(B-40)b(B-39)
```
```
…b(B-1)
```
Coding
Method
00111101 Integer
§14.3.1
§14.4.1
6-Bit Variable String Partition Table
14-35
§14.3.9
14.4.9
Integer
§14.3.1
§14.4.1
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 276 of 448
14.6.9.3 CPI+ coding table
Table 14-27 CPI+ coding table
Scheme CPI+
GS1 Digital
Link URI
syntax
```
https://id.gs1.org/8010/{cpi}/8011/{cpi_serial}
```
```
Total Bits Up to 266 bits (if at least first 4 characters of CPI are all-numeric) **
```
Logical
Segment
EPC Header +Data Toggle Filter CPI CPI Serial
Corresponding
```
GS1 AI (8010) (8011)
```
Logical
Segment Bit
Count
```
8 1 3 4n (for initial n
```
```
digits) + 4 bit
```
terminator
OR
```
4n (for initial n
```
```
digits) + 4 bit
```
delimiter
- 3 bit encoding
indicator +
5 bit length
indicator +
```
up to (210-7n)
```
bits
4 bit length
indicator +
up to 40 bits
Logical
Segment
Character
Count
1 digit
```
(0 or 1)
```
```
1 digit (0-7) Up to 30
```
characters
with
preservation of
leading zeros
Up to 12 digits
with preservation
of leading zeros
Bit Position
```
(counting
```
```
up)*
```
```
b0b1 …b7 b8 b9b10b11 b12b13 … ..b(B-2)b(B-1)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 277 of 448
Scheme CPI+
Coding
Method
11110000 +AIDC Data
Toggle Bit
§14.5.1
Fixed-Bit-
Length
Numeric
String
§14.5.2
Delimited/termi
nated Numeric
```
(§14.5.5)
```
```
(followed by
```
Variable-length
alphanumeric
```
(§14.5.6) for
```
any characters
after the initial
```
n digits)
```
Variable-length
numeric string
without encoding
indicator
§14.5.13
```
(using 4-bit length
```
```
indicator, b LI = 4)
```
- Note that for the CPI+ and other other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is shown
only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the EPC
header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
14.6.9.4 CPI++ coding table
Table 14-28 CPI++ coding table
Scheme CPI++
GS1 Digital
Link URI
syntax
```
https://{hostname}/8010/{cpi}/8011/{cpi_serial}
```
Total Bits Variable **
Logical
Segment
EPC
Header
+Data
Toggle
Filter CPI CPI Serial Hostname
Corresponding
GS1 AI
```
(8010) (8011)
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 278 of 448
Scheme CPI++
Logical
Segment
Bit Count
```
8 1 3 4n (for initial n
```
```
digits) + 4 bit
```
terminator
OR
```
4n (for initial n
```
```
digits) + 4 bit
```
delimiter
- 3 bit encoding
indicator +
5 bit length
indicator +
```
up to (210-7n)
```
bits
4 bit length
indicator +
up to 40 bits
1 bit encoding
indicator +
6 bit length
indicator +
up to *** bits
Logical
Segment
Character
Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
Up to 30
characters
with
preservation of
leading zeros
Up to 12 digits
with preservation
of leading zeros
up to 63
characters
Bit Position
```
(counting
```
```
up)*
```
```
b0b1 …b7 b8 b9b10b11 b12b13 … ..b(B-2)b(B-1) bnbn+1bn+2 …
```
Coding
Method
1110011
0
+AIDC
Data
Toggle Bit
§14.5.1
Fixed-
Bit-
Length
Numeric
String
§14.5.2
Delimited/termi
nated Numeric
```
(§14.5.5)
```
```
(followed by
```
Variable-length
alphanumeric
```
(§14.5.6) for
```
any characters
after the initial
```
n digits)
```
Variable-length
numeric string
without encoding
indicator
§14.5.13
```
(using 4-bit
```
length indicator,
```
b LI = 4)
```
Custom domain
name or
hostname
§14.5.16
- Note that for the CPI++ and other other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 279 of 448
```
14.6.10 Global Coupon Number (SGCN)
```
```
A lone, 96-bit coding scheme (SGCN-96) is specified for the SGCN, allowing for the full range of coupon serial component numbers up to 12
```
```
numeric characters (including leading zeros) as specified in [GS1GS]. Only SGCNs that include the serial number may be represented as
```
EPCs. A GCN without a serial number represents a coupon class, rather than a specific coupon, and therefore may not be used as an EPC
```
(just as a non-serialised GTIN may not be used as an EPC).
```
The SGCN coding scheme makes reference to the following partition table.
Table 14-39 SGCN Partition Table
Partition Value
```
(P)
```
Company Prefix Coupon Reference
Bits
```
(M)
```
Digits
```
(L)
```
Bits
```
(N)
```
Digits
0 40 12 1 0
1 37 11 4 1
2 34 10 7 2
3 30 9 11 3
4 27 8 14 4
5 24 7 17 5
6 20 6 21 6
14.6.10.1 SGCN-96 coding table
Table 14-40 SGCN-96 coding table
Scheme SGCN-96
URI
Template
```
urn:epc:tag:sgcn-96:F.C.D.S
```
GS1 Digital
Link URI
syntax
```
https://id.gs1.org/255/{gcn}
```
Total Bits 96
Logical
Segment
EPC Header Filter Partition GS1
Company
Prefix
Coupon
Reference
Serial Component
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 280 of 448
Scheme SGCN-96
Logical
Segment
Bit Count
8 3 3 20-40 21-1 41
Logical
Segment
Character
Count
1 digit
```
(0-7)
```
1 digit
```
(6-0)
```
6-12 digits 6-0 digits Up to 12 digits
with preservation
of leading zeros
Coding
Segment
EPC Header Filter Partition + Company Prefix + Coupon
Reference
Serial
URI
portion
F C.D S
Coding
Segment
Bit Count
8 3 44 41
Bit Position
```
(counting
```
```
down)
```
b95b94 …b88 b87b86b85 b84b83 …b41 b40b39 …b0
Bit Position
```
(counting
```
```
up)
```
b0b1 …b7 b8b9b10 b11b12 …b54 b55b56 …b95
Coding
Method
00111111 Integer
§14.3.1
§14.4.1
Partition Table 14-39
§14.3.3
§14.4.3
Numeric String
§14.3.6
§14.4.6
14.6.10.2 SGCN+
The SGCN+ coding scheme uses the following coding table.
Table 14-41 SGCN+ coding table
Scheme SGCN+
GS1 Digital Link
URI syntax
```
https://id.gs1.org/255/{gcn}
```
Total Bits Up to 108 bits **
Logical
Segment
EPC Header +Data
Toggle
Filter GCN without
optional serial
component
GCN serial
component
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 281 of 448
Scheme SGCN+
Corresponding
GS1 AI
```
(255)
```
Logical
Segment Bit
Count
8 1 3 52 4 bit length
indicator +
up to 40 bits
Logical
Segment
Character
Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
13 digits Up to 12 digits
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b63 b64b65b66 …
Coding Method 11111000 +AIDC
Data
Toggle Bit
§14.5.1
Fixed-Bit-
Length
Numeric
String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Variable-length
numeric string
without encoding
indicator
§14.5.13
```
(using 4-bit
```
length indicator,
```
b LI = 4)
```
- Note that for the SGCN+ and other other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
14.6.10.3 SGCN++
The SGCN++ coding scheme uses the following coding table.
Table 14-41 SGCN++ coding table
Scheme SGCN++
GS1 Digital
Link URI
syntax
```
https://{hostname}/255/{gcn}
```
Total Bits Variable **
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 282 of 448
Scheme SGCN++
Logical
Segment
EPC Header +Data
Toggle
Filter GCN without
optional
serial
component
GCN serial
component
Hostname
Correspondin
g
GS1 AI
```
(255)
```
Logical
Segment Bit
Count
8 1 3 52 4 bit length
indicator +
up to 40 bits
1 bit encoding
indicator +
6 bit length
indicator +
up to *** bits
Logical
Segment
Character
Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
13 digits Up to 12 digits up to 63
characters
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b63 b64b65b66 … bnbn+1bn+2 …
Coding
Method
11101100 +AIDC
Data
Toggle
Bit
§14.5.1
Fixed-
Bit-
Length
Numeri
c String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Variable-length
numeric string
without encoding
indicator
§14.5.13
```
(using 4-bit
```
length indicator,
```
b LI = 4)
```
Custom domain
name or
hostname
§14.5.16
- Note that for the SGCN++ and other other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 283 of 448
```
14.6.11 Individual Trade Item Piece (ITIP)
```
```
Two coding schemes for the ITIP are specified, a 110-bit encoding (ITIP-110) and a 212-bit encoding (ITIP-212). The ITIP-212 encoding
```
allows for the full range of serial numbers up to 20 alphanumeric characters as specified in [GS1GS]. The ITIP-110 encoding allows for
```
numeric-only serial numbers, without leading zeros, whose value is less than 2 38 (that is, from 0 through 274,877,906,943, inclusive).
```
Both ITIP coding schemes make reference to the following partition table.
Table 14-42 ITIP Partition Table
```
Partition Value (P) GS1 Company Prefix Indicator/Pad Digit and Item Reference
```
Bits
```
(M)
```
Digits
```
(L)
```
Bits
```
(N)
```
Digits
0 40 12 4 1
1 37 11 7 2
2 34 10 10 3
3 30 9 14 4
4 27 8 17 5
5 24 7 20 6
6 20 6 24 7
14.6.11.1 ITIP-110 coding table
Table 14-43 ITIP-110 coding table
Scheme ITIP-110
URI
Template
```
urn:epc:tag:itip-110:F.C.I.PT.S
```
GS1
Digital
Link URI
syntax
```
https://id.gs1.org/8006/{itip}/21/{serial}
```
Total Bits 110
Logical
Segment
EPC
Header
Filter Partiti
on
GS1
Compa
ny
Prefix
```
(*)
```
Indicato
```
r (**) /
```
Item
Referen
ce
Piece Total Serial
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 284 of 448
Scheme ITIP-110
Logical
Segment
Bit Count
8 3 3 20-40 24-4 7 7 38
Logical
Segment
Character
Count
1 digit
```
(0-7)
```
1 digit
```
(0-6)
```
6-12
digits
7-1
digits
2 digits 2 digits up to 12
digits in
range
0 –
274,877,90
6,943
without
preservation
of leading
zeros
Coding
Segment
EPC
Header
Filter GTIN Piece Total Serial
URI
portion
F C.I P T S
Coding
Segment
Bit Count
8 3 47 7 7 38
Bit
Position
```
(counting
```
```
down)
```
b109b108
…b102
b101b100b99 b98b97 …b52 b51b50…
b45
b44b43…b38 b37b36 …b0
Bit
Position
```
(counting
```
```
up)
```
b0b1 …b7 b8b9b10 b11b12 …b57 b58b59…
b64
b65b66…b71 b72b73 …b109
Coding
Method
010000
00
Integer
§14.3.1
§14.4.1
Partition Table 14-16
§14.3.3
§14.4.3
Fixed
Width
Integer
§14.3.1
0
§14.4.1
0
Fixed Width
Integer
§14.3.10
§14.4.10
Integer
§14.3.1
§14.4.1
```
(*) See Section 7.3.2 for the case of an SGTIN derived from a GTIN-8.
```
```
(**) Note that in the case of an ITIP derived from a GTIN-12 or GTIN-13, a zero pad digit takes the place of the Indicator Digit. In all cases,
```
```
see Section 7.2.3 for the definition of how the Indicator Digit (or zero pad) and the Item Reference are combined into this segment of the
```
EPC.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 285 of 448
14.6.11.2 ITIP-212 coding table
Table 14-44 ITIP-212 coding table
Scheme ITIP-212
URI
Templat
e
```
urn:epc:tag:itip-212:F.C.I.PT.S
```
GS1
Digital
Link
URI
syntax
```
https://id.gs1.org/8006/{itip}/21/{serial}
```
Total
Bits
212
Logical
Segment
EPC
Header
Filter Partitio
n
GS1
Compan
y Prefix
```
(*)
```
Indicator
```
(**) /
```
Item
Referenc
e
Piece Total Serial
Logical
Segment
Bit
Count
8 3 3 20-40 24-4 7 7 140
Logical
Segment
Character
Count
1 digit
```
(0-7)
```
1 digit
```
(0-6)
```
6-12
digits
7-1
digits
2 digits 2 digits up to 20
character
s
with
preservati
on of
leading
zeros
Coding
Segment
EPC
Header
Filter GTIN Piece Total Serial
URI
portion
F C.I P T S
Coding
Segment
Bit
Count
8 3 47 7 7 140
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 286 of 448
Scheme ITIP-212
Bit
Position
```
(counting
```
```
down)
```
b211b210 …b2
04
b203b202b2
01
b200b199 …b154 b153b152…b1
47
b146b145…b1
40
b139b138 …
b0
Bit
Position
```
(counting
```
```
up)
```
b0b1 …b7 b8b9b10 b11b12 …b57 b58b59…b64 b65b66…b71 b72b73 …b2
11
Coding
Method
01000001 Integer
§14.3.1
§14.4.1
Partition Table 14-16
§14.3.3
§14.4.3
Fixed
Width
Integer
§14.3.10
§14.4.10
Fixed
Width
Integer
§14.3.10
§14.4.10
String
§14.3.2
§14.4.2
```
(*) See Section 7.3.2 for the case of an SGTIN derived from a GTIN-8.
```
```
(**) Note that in the case of an ITIP derived from a GTIN-12 or GTIN-13, a zero pad digit takes the place of the Indicator Digit. In all cases,
```
```
see Section 7.2.3 for the definition of how the Indicator Digit (or zero pad) and the Item Reference are combined into this segment of the
```
EPC.
14.6.11.3 ITIP+
The ITIP+ coding scheme uses the following coding table.
Table 14-45 ITIP+ coding table
Scheme ITIP+
GS1 Digital
Link URI
syntax
```
https://id.gs1.org/8006/{itip}/21/{serial}
```
Total Bits Up to 232 bits **
Logical
Segment
EPC Header +Data
Toggle
Filter ITIP Serial Number
Corresponding
GS1 AI
```
(8006) (21)
```
Logical
Segment Bit
Count
8 1 3 72 3 bit encoding
indicator +
5 bit length
indicator +
up to 140 bits
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 287 of 448
Scheme ITIP+
Logical
Segment
Character
Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
18 digits up to 20
characters
with
preservation of
leading zeros
Bit Position
```
(counting up)*
```
b0b1 …b7 b8 b9b10b11 b12b13 …b83 b84b85b86 …
Coding Method 11110011 +AIDC
Data
Toggle
Bit
§14.5.1
Fixed-
Bit-
Length
Numeric
String
§14.5.2
Fixed-
Length
Numeric
§14.5.4
Variable-
length
alphanumeric
§14.5.6
- Note that for the ITIP+ and other other EPC schemes new to TDS 2.0, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
14.6.11.4 ITIP++
The ITIP++ coding scheme uses the following coding table.
Table 14-45 ITIP++ coding table
Scheme ITIP++
GS1 Digital
Link URI
syntax
```
https://{hostname}/8006/{itip}/21/{serial}
```
Total Bits Variable
Logical
Segment
EPC
Header
+Data
Toggle
Filter ITIP Serial Number Hostname
Correspondin
g
GS1 AI
```
(8006) (21)
```
Logical
Segment Bit
Count
8 1 3 72 3 bit encoding
indicator +
5 bit length
indicator +
up to 140 bits
1 bit encoding
indicator +
6 bit length
indicator +
up to *** bits
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 288 of 448
Scheme ITIP++
Logical
Segment
Character
Count
1 digit
```
(0 or 1)
```
1 digit
```
(0-7)
```
18 digits up to 20 characters
with preservation of
leading zeros
up to 63 characters
Bit Position
```
(counting up)*
```
b0b1 …b
7
b8 b9b10b11 b12b13 …b83 b84b85b86 … bnbn+1bn+2 …
Coding
Method
11110
011
+AIDC
Data
Toggle
Bit
§14.5.1
Fixed-
Bit-
Length
Numeric
String
§14.5.2
Fixed-Length
Numeric
§14.5.4
Variable-length
alphanumeric
§14.5.6
Custom domain
name or hostname
§14.5.16
- Note that for the ITIP++ and other other EPC schemes new to TDS 2.x, the "Bit Position" row of each new EPC coding table is
shown only with a 'counting up' approach from left to right, in which b0 is the left-most bit and b0 -b7 bits always correspond to the
EPC header bits.
** Note that the EPC and any optional "AIDC data" appended to the EPC itself have a practical upper limit of 464 bits on tags
```
which support XPC_W1 (see Section 9.3, "PC bits"), or 496 bits on tags which do not support XPC_W1. This is due to the limitation of the
```
```
"Length" bits (10h-14h) in the PC Bits, which represent the number of 16-bit words comprising the EPC field (beginning with bit 20h),
```
including any optional "AIDC data".
```
14.6.12 General Identifier (GID)
```
One coding scheme for the GID is specified: the 96-bit encoding GID-96. No partition table is required.
14.6.12.1 GID-96 coding table
Table 14-29 GID-96 coding table
Scheme GID-96
URI Template urn:epc:tag:gid-96:M.C.S
Total Bits 96
Logical Segment EPC Header General Manager
Number3
Object Class Serial Number
3 NOTE that General Manager Number issuance has been discontinued, effective June 2023.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 289 of 448
Scheme GID-96
Logical Segment
Bit Count
8 28 24 36
Coding Segment EPC Header General Manager
Number
Object Class Serial Number
URI portion M C S
Coding Segment
Bit Count
8 28 24 36
Bit Position
```
(counting down)
```
b95b94 …b88 b87b86 …b60 b59b58 …b36 b35b34 …b0
Bit Position
```
(counting up)
```
b0b1 …b7 b8b9 …b35 b36b37 …b59 b60b61 …b95
Coding Method 00110101 Integer
§14.3.1
§14.4.1
Integer
§14.3.1
§14.4.1
Integer
§14.3.1
§14.4.1
14.6.13 DoD Identifier
At the time of this writing, the details of the DoD encoding is explained in a document titled "United States Department of Defense
Supplier's Passive RFID Information Guide" that can be obtained at the United States Department of Defense's web site
```
(https://www.dla.mil/Portals/104/Documents/TroopSupport/CloTex/CT_RFID_GUIDE_2011.pdf ).
```
```
14.6.14 ADI Identifier (ADI)
```
One coding scheme for the ADI identifier is specified: the variable-length encoding ADI-var. No partition table is required.
14.6.14.1 ADI-var coding table
Table 14-30 ADI-var coding table
Scheme ADI-var
URI
Template
```
urn:epc:tag:adi-var:F.D.P.S
```
```
Total Bits Variable: between 68 and 434 bits (inclusive)
```
Logical
Segment
EPC Header Filter CAGE/ DoDAAC Part Number Serial
Number
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 290 of 448
Scheme ADI-var
Logical
Segment Bit
Count
8 6 36 Variable Variable
Logical
Segment
Character
Count
6 characters 1-33
characters
2-31
characters
Coding
Segment
EPC Header Filter CAGE/ DoDAAC Part Number Serial
Number
URI Portion F D P S
Coding
Segment Bit
Count
```
8 6 36 Variable (6 –
```
```
198)
```
Variable
```
(12 – 186)
```
Bit Position
```
(counting
```
```
down)
```
b B-1 b B-2…b B-8 b B-9 b B-10…b B-14 b B-15 b B-16…b B-50 b B-51 b B-52… …b 1 b 0
Bit Position
```
(counting up)
```
b 0 ..b 7 b 8 ..b 13 b 14 ..b 49 b 50 b 51 … …b B-2 b B-1
Coding
Method
00111011 Integer
§14.3.1
§14.4.1
6-bit CAGE/
DoDAAC
§14.3.7
§14.4.7
6-bit Variable
String
§14.3.8
§14.4.8
6-bit
Variable
String
§14.3.8
§14.4.8
```
Notes:
```
The number of characters in the Part Number segment must be greater than or equal to zero and less than or equal to 32. In the binary
encoding, a 6-bit zero terminator is always present.
The number of characters in the Serial Number segment must be greater than or equal to one and less than or equal to 30. In the binary
encoding, a 6-bit zero terminator is always present.
```
The "#" character (represented in the URI by the escape sequence %23) may appear as the first character of the Serial Number segment,
```
but otherwise may not appear in the Part Number segment or elsewhere in the Serial Number segment.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 291 of 448
15 EPC Memory Bank contents
This section specifies how to translate the EPC Tag URI and EPC Raw URI into the binary contents of the EPC memory bank of a Gen 2 Tag,
and vice versa.
15.1 Encoding procedures
This section specifies how to translate the EPC Tag URI and EPC Raw URI into the binary contents of the EPC memory bank of a Gen 2 Tag.
15.1.1 EPC Tag URI into Gen 2 EPC Memory Bank
```
Given:
```
■ An EPC Tag URI beginning with urn:epc:tag:
Encoding procedure:
1. If the URI is not syntactically valid according to Section 12.4, stop: this URI cannot be encoded.
2. Apply the encoding procedure of Section 14.3 to the URI. The result is a binary string of N bits. If the encoding procedure fails, stop:
this URI cannot be encoded.
3. Fill in the Gen 2 EPC Memory Bank according to the following table:
Table 15-1 Recipe to Fill In Gen 2 EPC Memory Bank from EPC Tag URI
Bits Field Contents
```
00 h – 0Fh CRC CRC code calculated from the remainder of the memory bank. (Normally, this is
```
calculated automatically by the reader, and so software that implements this
```
procedure need not be concerned with it.)
```
10 h – 14 h Length The number of bits, N, in the EPC binary encoding determined in Step 2 above,
divided by 16, and rounded up to the next higher integer if N was not a multiple
of 16.
15 h User Memory
Indicator
If the EPC Tag URI includes a control field [umi=1], a one bit.
If the EPC Tag URI includes a control field [umi=0] or does not contain a umi
control field, a zero bit.
Note that certain Gen 2 Tags may ignore the value written to this bit, and
instead calculate the value of the bit from the contents of user memory. See
[UHFC1G2].
16 h XPC Indicator This bit is calculated by the tag and ignored by the tag when the tag is written,
and so is disregarded by this encoding procedure.
17 h Toggle 0, indicating that the EPC bank contains an EPC
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 292 of 448
Bits Field Contents
18 h – 1Fh Attribute Bits If the EPC Tag URI includes a control field [att=xNN], the value NN
considered as an 8-bit hexadecimal number.
If the EPC Tag URI does not contain such a control field, zero.
20 h – ? EPC/UII The N bits obtained from the EPC binary encoding procedure in Step 2 above,
followed by enough zero bits to bring the total number of bits to a multiple of
```
16 (0 – 15 extra zero bits)
```
15.1.2 EPC Raw URI into Gen 2 EPC Memory Bank
```
Given:
```
■ An EPC Raw URI beginning with urn:epc:raw:. Such a URI has one of the following three forms:
```
urn:epc:raw:OptionalControlFields:Length.xHexPayload
```
```
urn:epc:raw:OptionalControlFields:Length.xAFI.xHexPayload
```
```
urn:epc:raw:OptionalControlFields:Length.DecimalPayload
```
Encoding procedure:
1. If the URI is not syntactically valid according to the grammar in Section 12.4, stop: this URI cannot be encoded.
2. Extract the leftmost NonZeroComponent according to the grammar (the Length field in the templates above). This component
```
immediately follows the rightmost colon (:) character. Consider this as a decimal integer, N. This is the number of bits in the raw
```
payload.
3. Determine the toggle bit and AFI (if any):
a. If the body of the URI matches the DecimalRawURIBody or HexRawURIBody production of the grammar (the first and third
```
templates above), the toggle bit is zero.
```
b. If the body of the URI matches the AFIRawURIBody production of the grammar (the second template above), the toggle bit is one.
```
The AFI is the value of the leftmost HexComponent within the AFIRawURIBody (the AFI field in the template above), considered
```
as an 8-bit unsigned hexadecimal integer. If the value of the HexComponent is greater than or equal to 256, stop: this URI cannot
be encoded.
4. Determine the EPC/UII payload:
c. If the body of the URI matches the HexRawURIBody production of the grammar (first template above) or AFIRawURIBody
```
production of the grammar (second template above), the payload is the rightmost HexComponent within the body (the
```
```
HexPayload field in the templates above), considered as an N-bit unsigned hexadecimal integer, where N is as determined in
```
Step 2 above. If the value of this HexComponent greater than or equal to 2N, stop: this URI cannot be encoded.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 293 of 448
d. If the body of the URI matches the DecimalRawURIBody production of the grammar (third template above), the payload is the
```
rightmost NumericComponent within the body (the DecimalPayload field in the template above), considered as an N-bit
```
unsigned decimal integer, where N is as determined in Step 2 above. If the value of this NumericComponent greater than or equal
to 2N, stop: this URI cannot be encoded.
5. Fill in the Gen 2 EPC Memory Bank according to the following table:
Table 15-2 Recipe to Fill In Gen 2 EPC Memory Bank from EPC Raw URI
Bits Field Contents
```
00 h – 0Fh CRC CRC code calculated from the remainder of the memory bank. (Normally, this is
```
calculated automatically by the reader, and so software that implements this
```
procedure need not be concerned with it.)
```
10 h – 14 h Length The number of bits, N, in the EPC binary encoding determined in Step 2 above,
divided by 16, and rounded up to the next higher integer if N was not a multiple
of 16.
15 h User Memory
Indicator
This bit is calculated by the tag and ignored by the tag when the tag is written,
and so is disregarded by this encoding procedure.
16 h XPC Indicator This bit is calculated by the tag and ignored by the tag when the tag is written,
and so is disregarded by this encoding procedure.
17 h Toggle The value determined in Step 3, above.
18 h – 1Fh AFI / Attribute
Bits
If the toggle determined in Step 3 is one, the value of the AFI determined in
Step 3.2. Otherwise,
If the URI includes a control field [att=xNN], the value NN considered as an
8-bit hexadecimal number.
If the URI does not contain such a control field, zero.
20 h – ? EPC/UII The N bits determined in Step 4 above, followed by enough zero bits to bring
```
the total number of bits to a multiple of 16 (0 – 15 extra zero bits)
```
15.2 Decoding procedures
This section specifies how to translate the binary contents of the EPC memory bank of a Gen 2 Tag into the EPC Tag URI and EPC Raw URI.
15.2.1 Gen 2 EPC Memory Bank into EPC Raw URI
```
Given:
```
■ The contents of the EPC Memory Bank of a Gen 2 tag
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 294 of 448
```
Procedure:
```
1. Extract the length bits, bits 10h – 14 h. Consider these bits to be an unsigned integer L.
2. Calculate N = 16L.
3. If bit 17h is set to one, extract bits 18 h – 1Fh and consider them to be an unsigned integer A. Construct a string consisting of the letter
```
"x", followed by A as a 2-digit hexadecimal numeral (using digits and uppercase letters only), followed by a period (".").
```
4. Apply the decoding procedure of Section 15.2.4 to decode control fields.
5. Extract N bits beginning at bit 20h and consider them to be an unsigned integer V. Construct a string consisting of the letter "x" followed
```
by V as a (N/4)-digit hexadecimal numeral (using digits and uppercase letters only).
```
6. Construct a string consisting of "urn:epc:raw:", followed by the result from Step 4 (if not empty), followed by N as a decimal
```
numeral without leading zeros, followed by a period ("."), followed by the result from Step 3 (if not empty), followed by the result from
```
Step 5. This is the final EPC Raw URI.
15.2.2 Gen 2 EPC Memory Bank into EPC Tag URI
This procedure decodes the contents of a Gen 2 EPC Memory bank into an EPC Tag URI beginning with urn:epc:tag: if the memory
contains a valid EPC, or into an EPC Raw URI beginning urn:epc:raw: otherwise.
```
Given:
```
■ The contents of the EPC Memory Bank of a Gen 2 tag
```
Procedure:
```
1. Extract the length bits, bits 10 h – 14 h. Consider these bits to be an unsigned integer L.
2. Calculate N = 16L.
3. Extract N bits beginning at bit 20h. Apply the decoding procedure of Section 14.3.9, passing the N bits as the input to that procedure.
4. If the decoding procedure of Section 14.3.9 fails, continue with the decoding procedure of Section 15.2.1 to compute an EPC Raw URI.
Otherwise, the decoding procedure of Section 14.3.9 yielded an EPC Tag URI beginning urn:epc:tag:. Continue to the next step.
5. Apply the decoding procedure of Section 15.2.4 to decode control fields.
6. Insert the result from Section 15.2.4 (including any trailing colon) into the EPC Tag URI obtained in Step 4, immediately following the
```
urn:epc:tag: prefix. (If Section 15.2.4 yielded an empty string, this result is identical to what was obtained in Step 4.) The result is
```
the final EPC Tag URI.
15.2.3 Gen 2 EPC Memory Bank into Pure Identity EPC URI
This procedure decodes the contents of a Gen 2 EPC Memory bank into a Pure Identity EPC URI beginning with urn:epc:id: if the memory
contains a valid EPC, or into an EPC Raw URI beginning urn:epc:raw: otherwise.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 295 of 448
```
Given:
```
■ The contents of the EPC Memory Bank of a Gen 2 tag
```
Procedure:
```
1. Apply the decoding procedure of Section 15.2.2 to obtain either an EPC Tag URI or an EPC Raw URI. If an EPC Raw URI is obtained, this
is the final result.
2. Otherwise, apply the procedure of Section 12.3.3 to the EPC Tag URI from Step 1 to obtain a Pure Identity EPC URI. This is the final
result.
15.2.4 Decoding of control information
This procedure is used as a subroutine by the decoding procedures in Sections 15.2.1 and 15.2.2. It calculates a string that is inserted
```
immediately following the urn:epc:tag: or urn:epc:raw: prefix, containing the values of all non-zero control information fields (apart
```
```
from the filter value). If all such fields are zero, this procedure returns an empty string, in which case nothing additional is inserted after the
```
```
urn:epc:tag: or urn:epc:raw: prefix.
```
```
Given:
```
■ The contents of the EPC Memory Bank of a Gen 2 tag
```
Procedure:
```
1. If bit 17h is zero, extract bits 18 h – 1F h and consider them to be an unsigned integer A. If A is non-zero, append the string [att=xAA]
```
(square brackets included) to CF, where AA is the value of A as a two-digit hexadecimal numeral.
```
2. If bit 15h is non-zero, append the string [umi=1] (square brackets included) to CF.
3. If bit 16h is non-zero, extract bits 210h – 21Fh and consider them to be an unsigned integer X. Append the string [xpc-w1=xXXXX]
```
(square brackets included) to CF, where XXXX is the value of X as a four-digit hexadecimal numeral. Note that in the Gen 2 air interface,
```
bits 210h – 21Fh are inserted into the backscattered inventory data immediately following bit 1F h, when bit 16h is non-zero. See
[UHFC1G2]. If bit 210h is non-zero, extract bits 220h – 22Fh and consider them to be an unsigned integer Y. Append the string
```
[xpc=xXXXXYYYY] (square brackets included) to CF, where YYYY is the value of Y as a four-digit hexadecimal numeral. Note that in
```
the Gen 2 air interface, bits 220 h – 22Fh are inserted into the backscattered inventory data immediately following bit 21F h, when bit
210h is non-zero. See [UHFC1G2].
4. Return the resulting string (which may be empty).
15.3 '+AIDC data' following new EPC schemes in the EPC/UII memory bank
```
All of the new EPC schemes introduced in TDS 2.x (DSGTIN+, SGTIN+ etc.) support appending of a AIDC data beyond the end of the EPC
```
within the EPC/UII memory bank.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 296 of 448
A single bit that follows immediately after the 8-bit EPC header of the new EPC schemes serves as a toggle bit for '+AIDC data'. If this bit is
set 1, additional AIDC data is expected after the EPC. If this bit is set to 0 no additional AIDC data is expected.
This is illustrated in the figure below:
Figure 15-1 Example of '+AIDC data' in EPC/UII memory
Each set of additional AIDC data begins with an 8-bit AIDC data header, which is interpreted as two 4-bit hexadecimal characters. If either
or both of these characters are in the range A-F, these indicate a special header typically used for optimisation purposes or reserved for
future use. Otherwise, if both of these characters are in the range 0 to 9, they should be interpreted as the first two digits of a GS1
```
Application Identifier key. GS1 Application Identifier keys consists of two, three or four digits, such as (01), (414), (8003). By consulting
```
Figure 7.8.1-2 within the GS1 General Specifications, it is possible to determine whether additional digits need to be read for GS1
Application Identifier keys that are three or four digits in length.
For example, in Figure 7.8.1-2 within the GS1 General Specifications, 41 is always the start of a 3-digit key 41n, while 80 is always the start
of a 4-digit key, 80nn. Table K is derived from GS1 Gen Specs Figure 7.8.1-2, adding an additional column to indicate how many additional
bits need to be read beyond the initial eight bits of the data header.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 297 of 448
Table K is shown in full below. It is derived from Figure 7.8.1-2 of the GS1 General Specifications and includes an extra column that
indicates the number of additional bits to be read.
First two
digits GS1 AI length
Additional
bits to read
First two
digits GS1 AI length
Additional
bits to read
00 2 0 37 2 0
01 2 0 39 4 8
02 2 0 40 3 4
10 2 0 41 3 4
11 2 0 42 3 4
12 2 0 43 4 8
13 2 0 70 4 8
15 2 0 71 3 4
16 2 0 72 4 8
17 2 0 80 4 8
20 2 0 81 4 8
21 2 0 82 4 8
22 2 0 90 2 0
23 3 4 91 2 0
24 3 4 92 2 0
25 3 4 93 2 0
31 4 8 94 2 0
32 4 8 95 2 0
33 4 8 96 2 0
34 4 8 97 2 0
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 298 of 448
First two
digits GS1 AI length
Additional
bits to read
First two
digits GS1 AI length
Additional
bits to read
35 4 8 98 2 0
36 4 8 99 2 0
If the first two digits are not shown in Table K, no GS1 Application Identifier key begins with those two digits.
If a 2-digit key is indicated, no additional bits must be read – the 8-bit data header is interpreted as a two-digit GS1 Application Identifier
key.
If a 3-digit key is indicated, four additional bits must be read beyond the 8-bit data header and interpreted as the third digit of the GS1
Application Identifier key.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 299 of 448
If a 4-digit key is indicated, a further eight bits must be read after the 8-bit data header and interpreted as the third and fourth digits of the
GS1 Application Identifier key. This is illustrated in the Figure below:
Figure 15-2 Reading and interpreting additional bits after the 8-bit data header
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 300 of 448
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 301 of 448
```
After determining the GS1 Application Identifier key (whether 2,3 or 4 digits), a lookup in column a of Table F explains how the
```
corresponding value is to be encoded. Most values consist of a single component which is either numeric or alphanumeric and may be fixed
length or variable length. However, a small number of values consist of two components where the second component is typically variable-
length and maybe alphanumeric or numeric, while the first component is typically fixed length.
Locate the row containing GS1 Application Identifier key in column a of Table F, then read column b to determine the encoding for the first
component of the value.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 302 of 448
If the first component is fixed-length, the number of characters is shown in column d and the number of bits is shown in column e. For the examples1
shown in the figure above, the extract of Table F is shown below:2
If the value is variable-length, column h indicates the maximum number of characters permitted for the first component and column g specifies the3
number of bits for the length indicator.4
Table F is shown in full below. Note that a small number of GS1 Application Identifiers have a second component in Table F, shown as values in columns5
i-o, which are analogous to columns b-h but apply to the second component that is encoded in binary immediately after the first component. The GS16
Application Identifiers that use a second component are the following:7
```
(253), (255), (3910)-(3919), (3930)-(3939), (421), (4330)-(4333), (7030)-(7039), (7040), (8003).8
```
9
Table F – GS1 Application Identifiers and details about the format of their values and encoding of their values in binary10
a b d e f g h i k l m n o
AI First component Second component
```
FormatFixedlength#chrFixedlength#bitsEncodingindicator#bitsLengthindicator#bitsrequiredMax.Length(chrs)FormatFixedlength#chrFixedlength#bitsEncodingindicator#bitsLengthindicator#bitsrequiredMax.Length(chrs)
```
L bLI L max L bLI L max
00 Fixed-length numeric
§14.5.4
18 72
01 Fixed-length numeric
§14.5.4
14 56
02 Fixed-length numeric
§14.5.4
14 56
10 Variable-length
alphanumeric §14.5.6
3 5 20
11 6-digit date YYMMDD
§14.5.8
6 16
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 303 of 448
12 6-digit date YYMMDD
§14.5.8
6 16
13 6-digit date YYMMDD
§14.5.8
6 16
15 6-digit date YYMMDD
§14.5.8
6 16
16 6-digit date YYMMDD
§14.5.8
6 16
17 6-digit date YYMMDD
§14.5.8
6 16
20 Fixed-Bit-Length
Numeric String §14.5.2
2 7
21 Variable-length
alphanumeric §14.5.6
3 5 20
22 Variable-length
alphanumeric §14.5.6
3 5 20
235 Variable-length
alphanumeric §14.5.6
3 5 28
240 Variable-length
alphanumeric §14.5.6
3 5 30
241 Variable-length
alphanumeric §14.5.6
3 5 30
242 Variable-length numeric
string without encoding
indicator §14.5.13
3 6
243 Variable-length
alphanumeric §14.5.6
3 5 20
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 304 of 448
250 Variable-length
alphanumeric §14.5.6
3 5 30
251 Variable-length
alphanumeric §14.5.6
3 5 30
253 Fixed-length numeric
§14.5.4
13 52 Variable-
length
alphanume
ric §14.5.6
3 5 17
254 Variable-length
alphanumeric §14.5.6
3 5 20
255 Fixed-length numeric
§14.5.4
13 52 Variable-
length
numeric
string
without
encoding
indicator
§14.5.13
4 12
30 Variable-length numeric
string without encoding
indicator §14.5.13
4 8
3100
-3105
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3110
-3115
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3120
-3125
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3130
-3135
Fixed-Bit-Length
Numeric String §14.5.2
6 20
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 305 of 448
3140
-3145
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3150
-3155
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3160
-3165
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3200
-3205
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3210
-3215
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3220
-3225
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3230
-3235
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3240
-3245
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3250
-3255
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3260
-3265
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3270
-3275
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3280
-3285
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3290
-3295
Fixed-Bit-Length
Numeric String §14.5.2
6 20
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 306 of 448
3300
-3305
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3310
-3315
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3320
-3325
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3330
-3335
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3340
-3345
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3350
-3355
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3360
-3365
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3370
-3375
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3400
-3405
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3410
-3415
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3420
-3425
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3430
-3435
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3440
-3445
Fixed-Bit-Length
Numeric String §14.5.2
6 20
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 307 of 448
3450
-3455
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3460
-3465
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3470
-3475
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3480
-3485
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3490
-3495
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3500
-3505
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3510
-3515
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3520
-3525
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3530
-3535
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3540
-3545
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3550
-3555
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3560
-3565
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3570
-3575
Fixed-Bit-Length
Numeric String §14.5.2
6 20
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 308 of 448
3600
-3605
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3610
-3615
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3620
-3625
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3630
-3635
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3640
-3645
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3650
-3655
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3660
-3665
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3670
-3675
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3680
-3685
Fixed-Bit-Length
Numeric String §14.5.2
6 20
3690
-3695
Fixed-Bit-Length
Numeric String §14.5.2
6 20
37 Variable-length numeric
string without encoding
indicator §14.5.13
4 8
3900
-3909
Variable-length numeric
string without encoding
indicator §14.5.13
4 15
3910
-3919
Fixed-Bit-Length
Numeric String §14.5.2
3 10 Variable-
length
4 15
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 309 of 448
numeric
string
without
encoding
indicator
§14.5.13
3920
-3929
Variable-length numeric
string without encoding
indicator §14.5.13
4 15
3930
-3939
Fixed-Bit-Length
Numeric String §14.5.2
3 10 Variable-
length
numeric
string
without
encoding
indicator
§14.5.13
4 15
3940
-3943
Fixed-Bit-Length
Numeric String §14.5.2
4 14
3950
-3953
Fixed-Bit-Length
Numeric String §14.5.2
6 20
400 Variable-length
alphanumeric §14.5.6
3 5 30
401 Variable-length
alphanumeric §14.5.6
3 5 30
402 Fixed-Bit-Length
Numeric String §14.5.2
17 57
403 Variable-length
alphanumeric §14.5.6
3 5 30
410
- 417
Fixed-length numeric
§14.5.4
13 52
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 310 of 448
420 Variable-length
alphanumeric §14.5.6
3 5 20
421 Fixed-Bit-Length
Numeric String §14.5.2
3 10 Variable-
length
alphanume
ric §14.5.6
3 4 9
422 Fixed-Bit-Length
Numeric String §14.5.2
3 10
423 Variable-length numeric
string without encoding
indicator §14.5.13
4 15
424 Fixed-Bit-Length
Numeric String §14.5.2
3 10
425 Variable-length numeric
string without encoding
indicator §14.5.13
4 15
426 Fixed-Bit-Length
Numeric String §14.5.2
3 10
427 Variable-length
alphanumeric §14.5.6
3 2 3
4300 Variable-length
alphanumeric §14.5.6
3 6 35
4301 Variable-length
alphanumeric §14.5.6
3 6 35
4302 Variable-length
alphanumeric §14.5.6
3 7 70
4303 Variable-length
alphanumeric §14.5.6
3 7 70
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 311 of 448
4304 Variable-length
alphanumeric §14.5.6
3 7 70
4305 Variable-length
alphanumeric §14.5.6
3 7 70
4306 Variable-length
alphanumeric §14.5.6
3 7 70
4307 Country code
```
(ISO 3166-1 alpha-2)
```
§14.5.12
2 12
4308 Variable-length
alphanumeric §14.5.6
3 5 30
4309 Fixed-Bit-Length
Numeric String §14.5.2
20 67
4310 Variable-length
alphanumeric §14.5.6
3 6 35
4311 Variable-length
alphanumeric §14.5.6
3 6 35
4312 Variable-length
alphanumeric §14.5.6
3 7 70
4313 Variable-length
alphanumeric §14.5.6
3 7 70
4314 Variable-length
alphanumeric §14.5.6
3 7 70
4315 Variable-length
alphanumeric §14.5.6
3 7 70
4316 Variable-length
alphanumeric §14.5.6
3 7 70
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 312 of 448
4317 Country code
```
(ISO 3166-1 alpha-2)
```
§14.5.12
2 12
4318 Variable-length
alphanumeric §14.5.6
3 5 20
4319 Variable-length
alphanumeric §14.5.6
3 5 30
4320 Variable-length
alphanumeric §14.5.6
3 6 35
4321 Single data bit
§14.5.7
1 1
4322 Single data bit
§14.5.7
1 1
4323 Single data bit
§14.5.7
1 1
4324 10-digit date+time
YYMMDDhhmm §14.5.9
10 27
4325 10-digit date+time
YYMMDDhhmm §14.5.9
10 27
4326 6-digit date YYMMDD
§14.5.8
6 16
4330 Fixed-Bit-Length
Numeric String §14.5.2
6 20 Optional
minus sign
in 1 bit
```
(§14.5.14)
```
1 1
4331 Fixed-Bit-Length
Numeric String §14.5.2
6 20 Optional
minus sign
in 1 bit
```
(§14.5.14)
```
1 1
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 313 of 448
4332 Fixed-Bit-Length
Numeric String §14.5.2
6 20 Optional
minus sign
in 1 bit
```
(§14.5.14)
```
1 1
4333 Fixed-Bit-Length
Numeric String §14.5.2
6 20 Optional
minus sign
in 1 bit
```
(§14.5.14)
```
1 1
7001 Fixed-Bit-Length
Numeric String §14.5.2
13 44
7002 Variable-length
alphanumeric §14.5.6
3 5 30
7003 10-digit date+time
YYMMDDhhmm §14.5.9
10 27
7004 Variable-length numeric
string without encoding
indicator §14.5.13
3 4
7005 Variable-length
alphanumeric §14.5.6
3 4 12
7006 6-digit date YYMMDD
§14.5.8
6 16
7007 Variable-format date /
date range §14.5.10
7008 Variable-length
alphanumeric §14.5.6
3 2 3
7009 Variable-length
alphanumeric §14.5.6
3 4 10
7010 Variable-length
alphanumeric §14.5.6
3 2 2
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 314 of 448
7011 Variable-precision
date+time §14.5.11
7020 Variable-length
alphanumeric §14.5.6
3 5 20
7021 Variable-length
alphanumeric §14.5.6
3 5 20
7022 Variable-length
alphanumeric §14.5.6
3 5 20
7023 Delimited/terminated
numeric §14.5.5
3 5 30
7030
-7039
Fixed-Bit-Length
Numeric String §14.5.2
3 10 Variable-
length
alphanume
ric §14.5.6
3 5 27
7040 Variable-length
alphanumeric §14.5.6
3 3 4
7041 Variable-length
alphanumeric §14.5.6
3 3 4
710
- 716
Variable-length
alphanumeric §14.5.6
3 5 20
7230
-7239
Variable-length
alphanumeric §14.5.6
3 5 30
7240 Variable-length
alphanumeric §14.5.6
3 5 20
7241 Fixed-length numeric
§14.5.4
2 8
7242 Variable-length
alphanumeric §14.5.6
3 5 25
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 315 of 448
7250 Fixed-Bit-Length
Numeric String §14.5.2
8 27
7251 Fixed-Bit-Length
Numeric String §14.5.2
12 40
7252 Fixed-Bit-Length
Numeric String §14.5.2
1 4
7253 Variable-length
alphanumeric §14.5.6
3 6 40
7254 Variable-length
alphanumeric §14.5.6
3 6 30
7255 Variable-length
alphanumeric §14.5.6
3 4 10
7256 Variable-length
alphanumeric §14.5.6
3 7 90
7257 Variable-length
alphanumeric §14.5.6
3 7 70
7258 Sequence indicator
§14.5.15
3 8
7259 Variable-length
alphanumeric §14.5.6
3 6 40
8001 Fixed-Bit-Length
Numeric String §14.5.2
14 47
8002 Variable-length
alphanumeric §14.5.6
3 5 20
8003 Fixed-length numeric
§14.5.4
14 56 Variable-
length
alphanume
ric §14.5.6
3 5 16
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 316 of 448
8004 Delimited/terminated
numeric §14.5.5
3 5 30
8005 Fixed-Bit-Length
Numeric String §14.5.2
6 20
8006 Fixed-length numeric
§14.5.4
18 72
8007 Variable-length
alphanumeric §14.5.6
3 5 24
8008 Variable-precision
date+time §14.5.11
8009 Variable-length
alphanumeric §14.5.6
3 6 50
8010 Delimited/terminated
numeric §14.5.5
3 5 30
8011 Variable-length numeric
string without encoding
indicator §14.5.13
4 12
8012 Variable-length
alphanumeric §14.5.6
3 5 20
8013 Variable-length
alphanumeric §14.5.6
3 5 25
8017 Fixed-length numeric
§14.5.4
18 72
8018 Fixed-length numeric
§14.5.4
18 72
8019 Variable-length numeric
string without encoding
indicator §14.5.13
4 10
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 317 of 448
8020 Variable-length
alphanumeric §14.5.6
3 5 25
8026 Fixed-length numeric
§14.5.4
18 72
8030 Variable-length
alphanumeric §14.5.6
3 7 90
8110 Variable-length
alphanumeric §14.5.6
3 7 70
8111 Fixed-Bit-Length
Numeric String §14.5.2
4 14
8112 Variable-length
alphanumeric §14.5.6
3 7 70
8200 Variable-length
alphanumeric §14.5.6
3 7 70
90 Variable-length
alphanumeric §14.5.6
3 5 30
91-99 Variable-length
alphanumeric §14.5.6
3 7 90
11
Note that the following data attributes are intentionally omitted:12
```
Identification of a Made-to-order (MtO) trade item (GTIN) [AI (03)] and Highly Individualised Device Registration Identifier (HIDRI) [AI (8014)] are13
```
```
defined for the Master Unique Device Identifiers – Device Identifier (M-UDI-DI) restricted application, and as such are not permitted for use in an14
```
EPC/RFID data carrier.15
16
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 318 of 448
```
Table E (see Section 14.5.6) lists the permitted values for encoding indicator together with the encoding methods and the character ranges17
```
supported by each method.18
Note that variable-length numeric values do not use an encoding indicator but typically do use a length indicator. The exception to the19
statement above is for the GIAI and CPI, which use the 'terminated/delimited' encoding method, in which a delimiter or terminator20
character marks the end of an initial all-numeric sequence. If the remainder is an alphanumeric sequence, the delimiter character is21
followed by an encoding indicator, length indicator and the encoding of the alphanumeric sequence.22
Where present, the length indicator always indicates the total number of characters or digits for that value or component. For example a23
value 00101 indicates a length of 5 characters.24
The figure below shows two examples for encoding a batch/lot number, one all-numeric, the other alphanumeric. The two examples25
illustrate different values of encoding indicator and length indicator, as well as the corresponding bit layouts. Note that because the first26
example is all-numeric, integer encoding at 3.32bits per digit can be used, whereas the second example is mixed case alphanumeric, but27
because it is not using any symbol characters, we can use file-safe URI-safe base64 encoding at 6 bits per character.28
29
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 319 of 448
Figure 15-3 Examples of encoding all-numeric and alphanumeric batch/lot number30
31
```
The number of bits required for the length indicator depends on the maximum permitted length for the value (or the value of the first /32
```
```
second component shown in Table F). Columns g and n of Table F indicate the number of bits to be used for the length indicator (where33
```
```
present), for the first and second components respectively.34
```
Date values and date-time values use particularly optimised encodings to save bits and column b of Table F indicates dedicated methods for35
efficiently encoding/decoding date value or date+time values.36
It is possible to encode more than one AIDC data value after the EPC by repeating the procedure and adding further data headers for each37
successive GS1 Application Identifier and its value. This is illustrated in the following figure. All remaining bits up to the next 16-bit word38
boundary SHALL be set to '0'.39
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 320 of 448
Figure 15-4 Encoding more than one AIDC data value after the EPC40
41
When decoding +AIDC data encoded after the EPC, the decoding procedure should be repeated if the number of 16-bit words indicated by42
the Gen 2 Protocol Control bits 10h – 14h indicate that further bits have been encoded. If fewer than 8 bits remain before the indicated43
word count is reached, there can be no further +AIDC data. Otherwise, if at least 8 further bits remain, consider the following three44
```
options:45
```
■ If the next 8-bits are not '00000000', repeat the procedure, considering those 8 bits as the next +AIDC data header.46
```
■ If the next 8 bit are '00000000' and at least 72 bits remain, consider those 8 bits as a +AIDC data header for an SSCC (00) and decode47
```
the following 72 bits using the Fixed-length Numeric method described in §14.5.4.48
```
■ If the next 8 bit are '00000000' and fewer than 72 bits remain, stop, since this cannot be decoded as an SSCC (00).49
```
All additional AIDC data expressed within the EPC/UII memory bank SHALL observe the rules regarding mandatory associations and invalid50
pairs of GS1 Application Identifiers, defined in the GS1 General Specifications and considering the GS1 Application Identifiers that are51
```
effectively already expressed by the EPC identifier itself, e.g. (01) and (21) in the case of SGTIN+.52
```
The non-binary values decoded for AIDC data expressed within the EPC/UII memory bank SHALL observe the rules regarding format and53
content that are defined for the corresponding GS1 Application Identifier within the GS1 General Specifications.54
```
Table B (shown below) calculates the number of bits required to encode the value of a string of length L depending on the encoding55
```
method selected. This table may be used to avoid the need for floating-point arithmetic calculations.56
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 321 of 448
Encoding
indicator 000
Encoding
indicator 001
or 010
Encoding indicator
101
Encoding indicator
011
Encoding indicator 100
```
L = Number of digits
```
or characters
Integer encoding
@ ≈ 3.32 bits /
digit
Numeric string
encoding
@ 4 bits / digit
URN Code 40
encoding
@ 16 bits per 3
characters
File-safe base 64
encoding
@ 6 bits per
character
Truncated ASCII
encoding
@7 bits per character
1 4 4 16 6 7
2 7 8 16 12 14
3 10 12 16 18 21
4 14 16 32 24 28
5 17 20 32 30 35
6 20 24 32 36 42
7 24 28 48 42 49
8 27 32 48 48 56
9 30 36 48 54 63
10 34 40 64 60 70
11 37 44 64 66 77
12 40 48 64 72 84
13 44 52 80 78 91
14 47 56 80 84 98
15 50 60 80 90 105
16 54 64 96 96 112
17 57 68 96 102 119
18 60 72 96 108 126
19 64 76 112 114 133
20 67 80 112 120 140
21 70 84 112 126 147
22 74 88 128 132 154
23 77 92 128 138 161
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 322 of 448
Encoding
indicator 000
Encoding
indicator 001
or 010
Encoding indicator
101
Encoding indicator
011
Encoding indicator 100
24 80 96 128 144 168
25 84 100 144 150 175
26 87 104 144 156 182
27 90 108 144 162 189
28 94 112 160 168 196
29 97 116 160 174 203
30 100 120 160 180 210
31 103 124 176 186 217
32 107 128 176 192 224
33 110 132 176 198 231
34 113 136 192 204 238
35 117 140 192 210 245
36 120 144 192 216 252
37 123 148 208 222 259
38 127 152 208 228 266
39 130 156 208 234 273
40 133 160 224 240 280
41 137 164 224 246 287
42 140 168 224 252 294
43 143 172 240 258 301
44 147 176 240 264 308
45 150 180 240 270 315
46 153 184 256 276 322
47 157 188 256 282 329
48 160 192 256 288 336
49 163 196 272 294 343
50 167 200 272 300 350
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 323 of 448
Encoding
indicator 000
Encoding
indicator 001
or 010
Encoding indicator
101
Encoding indicator
011
Encoding indicator 100
51 170 204 272 306 357
52 173 208 288 312 364
53 177 212 288 318 371
54 180 216 288 324 378
55 183 220 304 330 385
56 187 224 304 336 392
57 190 228 304 342 399
58 193 232 320 348 406
59 196 236 320 354 413
60 200 240 320 360 420
61 203 244 336 366 427
62 206 248 336 372 434
63 210 252 336 378 441
64 213 256 352 384 448
65 216 260 352 390 455
66 220 264 352 396 462
67 223 268 368 402 469
68 226 272 368 408 476
69 230 276 368 414 483
70 233 280 384 420 490
71 236 284 384 426 497
72 240 288 384 432 504
73 243 292 400 438 511
74 246 296 400 444 518
75 250 300 400 450 525
76 253 304 416 456 532
77 256 308 416 462 539
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 324 of 448
Encoding
indicator 000
Encoding
indicator 001
or 010
Encoding indicator
101
Encoding indicator
011
Encoding indicator 100
78 260 312 416 468 546
79 263 316 432 474 553
80 266 320 432 480 560
81 270 324 432 486 567
82 273 328 448 492 574
83 276 332 448 498 581
84 280 336 448 504 588
85 283 340 464 510 595
86 286 344 464 516 602
87 290 348 464 522 609
88 293 352 480 528 616
89 296 356 480 534 623
90 299 360 480 540 630
57
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 325 of 448
```
16 Tag Identification (TID) Memory Bank Contents58
```
```
To conform to this specification, the Tag Identification memory bank (bank 10) SHALL contain an 8 bit ISO/IEC 15963 [ISO15963]59
```
allocation class identifier of E2h at memory locations 00h to 07 h. TID memory above location 07h SHALL be configured as follows:60
```
■ 08h: XTID (X) indicator (whether a Tag implements Extended Tag Identification, XTID)61
```
```
■ 09h: Security (S) indicator (whether a Tag supports the Authenticate and/or Challenge commands)62
```
```
■ 0A h: File (F) indicator (whether a Tag supports the FileOpen command)63
```
```
■ 0B h to 13h: a 9-bit mask-designer identifier (MDID) available from GS164
```
```
■ 14h to 1Fh : a 12-bit, Tag-manufacturer-defined Tag Model Number (TMN)65
```
■ above 1Fh: as defined in section 16.2 below66
```
The Tag model number (TMN) may be assigned any value by the holder of a given MDID. However, [UHFC1G2] states "TID memory67
```
locations above 07h shall be defined according to the registration authority defined by this class identifier value and shall contain, at a68
minimum, sufficient identifying information for an Interrogator to uniquely identify the custom commands and/or optional features that a69
Tag supports." For the allocation class identifier of E2h this information is the MDID and TMN, regardless of whether the extended TID is70
present or not. If two tags differ in custom commands and/or optional features, they must be assigned different MDID/TMN combinations.71
In particular, if two tags contain an extended TID and the values in their respective extended TIDs differ in any value other than the value72
```
of the serial number, they must be assigned a different MDID/TMN combination. (The serial number by definition must be different for any73
```
```
two tags having the same MDID and TMN, so that the Serialised Tag Identification specified in Section 16.2.6 is globally unique.) For tags74
```
that do not contain an extended TID, it should be possible in principle to use the MDID and TMN to look up the same information that would75
be encoded in the extended TID were it actually present on the tag, and so again a different MDID/TMN combination must be used if two76
tags differ in the capabilities as they would be described by the extended TID, were it actually present.77
TID memory locations 00 h to 1Fh SHALL be permalocked at time of manufacture. If the Tag implements an XTID then the entire XTID SHALL78
also be permalocked at time of manufacture.79
As of Gen2v3, tags with allocation class identifier E2 h SHALL support a serialised TID by using a unique serial number, as80
defined in section 16.2.2 below.81
```
16.1 Short Tag Identification (TID)82
```
```
If the XTID indicator ("X" bit 08h of the TID bank) is set to zero, the TID bank only contains the allocation class identifier, XTID ("X"),83
```
```
Security ("S") and File ("F") indicators, the mask designer identifier (MDID), and Tag model number (TMN), as specified above. Readers and84
```
applications that are not configured to handle the extended TID will treat all TIDs as short tag identification, regardless of whether the XTID85
indicator is zero or one.86
```
Note: The memory maps depicted in this document are identical to how they are depicted in [UHFC1G2]. The lowest word87
```
address starts at the bottom of the map and increases as you go up the map. The bit address reads from left to right starting with bit88
```
zero and ending with bit fifteen. The fields (MDID, TMN, etc) described in the document put their most significant bit (highest bit89
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 326 of 448
```
number) into the lowest bit address in memory and the least significant bit (bit zero) into the highest bit address in memory. Take90
```
the ISO/IEC 15963 [ISO15963] allocation class identifier of E2h = 111000102 as an example. The most significant bit of this field is a91
one and it resides at address 00h of the TID memory bank. The least significant bit value is a zero and it resides at address 07h of92
the TID memory bank. When tags backscatter data in response to a read command they transmit each word starting from bit address93
zero and ending with bit address fifteen.94
Table 16-1 Short TID format95
TID MEM
BANK BIT
ADDRESS
```
BIT ADDRESS WITHIN WORD (In Hexadecimal)
```
0 1 2 3 4 5 6 7 8 9 A B C D E F
10 h -1Fh MDID[3:0] TAG MODEL NUMBER[11:0]
00 h -0Fh E2 h X S F MDID [8:4]
```
16.2 Extended Tag identification (XTID)96
```
The XTID is intended to provide more information to end users about the capabilities of tags that are observed in their RFID applications.97
The XTID extends the format by adding support for serialisation and information about key features implemented by the tag.98
```
If the XTID bit (bit 08 h of the TID bank) is set to one, the TID bank SHALL contain the allocation class identifier, mask designer identifier99
```
```
(MDID), and Tag model number (TMN) as specified above, and SHALL also contain additional information as specified in this section.100
```
If the XTID bit as defined above is one, TID memory locations 20 h to 2Fh SHALL contain a 16-bit XTID header as specified in Section 16.2.1.101
The values in the XTID header specify what additional information is present in memory locations 30 h and above. TID memory locations 00h102
```
through 2Fh are the only fixed location fields in the extended TID; all fields following the XTID header can vary in their location in memory103
```
depending on the values in the XTID header.104
The information in the XTID following the XTID header SHALL consist of zero or more multi-word "segments," each segment being divided105
into one or more "fields," each field providing certain information about the tag as specified below. The XTID header indicates which of the106
XTID segments the tag mask-designer has chosen to include. The order of the XTID segments in the TID bank shall follow the order that107
they are listed in the XTID header from most significant bit to least significant bit. If an XTID segment is not present then segments at less108
significant bits in the XTID header shall move to lower TID memory addresses to keep the XTID memory structure contiguous. In this way a109
minimum amount of memory is used to provide a serial number and/or describe the features of the tag. A fully populated XTID is shown in110
the table below.111
Non-Normative: The XTID header corresponding to this memory map would be 00111100000000002 . If the tag only112
contained a 48 bit serial number the XTID header would be 00100000000000002 . The serial number would start at bit address 30h113
and end at bit address 5Fh . If the tag contained just the BlockWrite and BlockErase segment and the User Memory and114
BlockPermaLock segment the XTID header would be 00001100000000002 . The BlockWrite and BlockErase segment would start at bit115
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 327 of 448
address 30h and end at bit address 6Fh . The User Memory and BlockPermaLock segment would start at bit address 70h and end at bit116
address 8Fh.117
```
Table 16-2 Non-Normative example: Extended Tag Identification (XTID) format for the TID memory bank118
```
TDS
Reference
Section
TID MEM
BANK BIT
ADDRESS
```
BIT ADDRESS WITHIN WORD (In Hexadecimal)
```
0 1 2 3 4 5 6 7 8 9 A B C D E F
16.2.5 C0 h -CFh User Memory and BlockPermaLock Segment [15:0]
B0 h -BFh User Memory and BlockPermaLock Segment [31:16]
16.2.4 A0 h -AFh BlockWrite and BlockErase Segment [15:0]
90 h -9Fh BlockWrite and BlockErase Segment [31:16]
80 h -8Fh BlockWrite and BlockErase Segment [47:32]
70 h -7Fh BlockWrite and BlockErase Segment [63:48]
16.2.3 60 h -6Fh Optional Command Support Segment [15:0]
16.2.2 50 h -5Fh Serial Number Segment [15:0]
40 h -4Fh Serial Number Segment [31:16]
30 h -3Fh Serial Number Segment [47:32]
16.2.1 20 h -2Fh XTID Header Segment [15:0]
16.1 10 h -1Fh Refer to Table 16-1
00 h -0Fh
```
Note that this example depicts the memory mapping when the serialisation bits in the XTID header (see Table 16-3), are set to 001,119
```
indicating the XTID Serial Number is 48 bits long. Other settings of the serialisation bits in the XTID header will shift the addresses of the120
Optional Command Support Segment, the BlockWrite and BlockErase Segment and the User Memory and BlockPermaLock Segment.121
16.2.1 XTID Header122
```
The XTID header is shown in Table 16-3. It contains defined and reserved for future use (RFU) bits. The extended header bit and RFU bits123
```
```
(bits 9 through 0) shall be set to zero to comply with this version of the specification. Bits 15 through 13 of the XTID header word indicate124
```
the presence and size of serialisation on the tag. If they are set to zero then there is no serialisation in the XTID. If they are not zero then125
there is a tag serial number immediately following the header. The optional features currently in bits 12 through 10 are handled differently.126
A zero indicates the reader needs to perform a database look up or that the tag does not support the optional feature. A one indicates that127
the tag supports the optional feature and that the XTID contains the segment describing this feature.128
Note that the contents of the XTID header uniquely determine the overall length of the XTID as well as the starting address for each129
included XTID segment.130
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 328 of 448
Table 16-3 The XTID header131
Bit Position
in Word
Field Description
0 Extended Header
Present
If non-zero, specifies that additional XTID header bits are present beyond
the 16 XTID header bits specified herein. This provides a mechanism to
extend the XTID in future versions of the EPC Tag Data Standard. This bit
SHALL be set to zero to comply with this version of the EPC Tag Data
Standard.
If zero, specifies that the XTID header only contains the 16 bits defined
herein.
1 - 8 RFU Reserved for future use. These bits SHALL be zero to comply with this
version of the EPC Tag Data Standard
9 Lock Bit Segment If non-zero, specifies that the XTID includes the Lock Bit segment
specified in Section 16.2.6.
If zero, specifies that the XTID does not include the Lock Bit segment
word.
10 User Memory and
Block Perma Lock
Segment Present
If non-zero, specifies that the XTID includes the User Memory and Block
PermaLock segment specified in Section 16.2.5.
If zero, specifies that the XTID does not include the User Memory and
Block PermaLock words.
11 BlockWrite and
BlockErase
Segment Present
If non-zero, specifies that the XTID includes the BlockWrite and
BlockErase segment specified in Section 16.2.4.
If zero, specifies that the XTID does not include the BlockWrite and
BlockErase words.
12 Optional Command
Support Segment
Present
If non-zero, specifies that the XTID includes the Optional Command
Support segment specified in Section 16.2.3.
If zero, specifies that the XTID does not include the Optional Command
Support word.
13 – 15 Serialisation If non-zero, specifies that the XTID includes a unique serial number,
```
whose length in bits is 48 + 16(N – 1), where N is the value of this field.
```
If zero, specifies that the XTID does not include a unique serial number.
As of Gen2v3, tags with allocation class identifier E2 h SHALL support a
serialised TID by using a unique serial number.
```
Bit 15 is the MSB; bit 13 is the LSB.
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 329 of 448
16.2.2 XTID Serialisation132
The length of the XTID serialisation is specified in the XTID header. The managing entity specified by the tag mask designer ID is133
responsible for assigning unique serial numbers for each tag model number. The length of the serial number uses the following algorithm:134
0: Indicates no serialisation135
```
1-7: Length in bits = 48 + ((Value-1) * 16)136
```
16.2.3 Optional Command Support segment137
If bit twelve is set in the XTID header then the following word is added to the XTID. Bit fields that are left as zero indicate that the tag does138
not support that feature. The description of the features is as follows.139
Table 16-4 Optional Command Support XTID Word140
Bit Position
in Segment
Field Description
0-4 Max EPC Size This five bit field shall indicate the maximum size that can be programmed
into the first five bits of the PC.
5 Recom Support If this bit is set, the tag supports recommissioning as specified in
[UHFC1G2].
6 Access If this bit is set, it indicates that the tag supports the access command.
7 Separate
Lockbits
If this bit is set, it means that the tag supports lock bits for each memory
bank rather than the simplest implementation of a single lock bit for the
entire tag.
8 Auto UMI
Support
If this bit is set, it means that the tag automatically sets its user memory
indicator bit in the PC word.
9 PJM Support If this bit is set, it indicates that the tag supports phase jitter modulation.
This is an optional modulation mode supported only in Gen 2 HF tags.
10 BlockErase
Supported
If set, this indicates that the tag supports the BlockErase command. How
the tag supports the BlockErase command is described in Section 16.2.4.
A manufacture may choose to set this bit, but not include the BlockWrite
and BlockErase field if how to use the command needs further explanation
through a database lookup.
11 BlockWrite
Supported
If set, this indicates that the tag supports the BlockWrite command. How
the tag supports the BlockErase command is described in Section 16.2.4.
A manufacture may choose to set this bit, but not include the BlockWrite
and BlockErase field if how to use the command needs further explanation
through a database lookup.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 330 of 448
Bit Position
in Segment
Field Description
12 BlockPermaLock
Supported
If set, this indicates that the tag supports the BlockPermaLock command.
How the tag supports the BlockPermaLock command is described in
Section 16.2.5. A manufacture may choose to set this bit, but not include
the BlockPermaLock and User Memory field if how to use the command
needs further explanation through a database lookup.
13-15 [RFU] These bits are RFU and should be set to zero.
16.2.4 BlockWrite and BlockErase segment141
If bit eleven of the XTID header is set then the XTID shall include the four-word BlockWrite and BlockErase segment. To indicate that a142
command is not supported, the tag shall have all fields related to that command set to zero. This SHALL always be the case when the143
```
Optional Command Support Segment (Section 16.2.3) is present and it indicates that BlockWrite or BlockErase is not supported. The144
```
descriptions of the fields are as follows.145
Table 16-5 XTID Block Write and Block Erase Information146
Bit Position
in Segment
Field Description
0-7 Block Write Size Max block size that the tag supports for the BlockWrite command. This
value should be between 1-255 if the BlockWrite command is described in
this field.
8 Variable Size
Block Write
This bit is used to indicate if the tag supports BlockWrite commands with
variable sized blocks.
If the value is zero the tag only supports writing blocks exactly the
maximum block size indicated in bits [7-0].
If the value is one the tag supports writing blocks less than the maximum
block size indicated in bits [7-0].
9-16 Block Write EPC
Address Offset
This indicates the starting word address of the first full block that may be
written to using BlockWrite in the EPC memory bank.
17 No Block Write
EPC address
alignment
This bit is used to indicate if the tag memory architecture has hard block
boundaries in the EPC memory bank.
If the value is zero the tag has hard block boundaries in the EPC memory
bank. The tag will not accept BlockWrite commands that start in one block
and end in another block. These block boundaries are determined by the
max block size and the starting address of the first full block. All blocks have
the same maximum size.
If the value is one the tag has no block boundaries in the EPC memory
bank. It will accept all BlockWrite commands that are within the memory
bank.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 331 of 448
Bit Position
in Segment
Field Description
18-25 Block Write
User Address
Offset
This indicates the starting word address of the first full block that may be
written to using BlockWrite in the User memory.
26 No Block Write
User Address
Alignment
This bit is used to indicate if the tag memory architecture has hard block
boundaries in the USER memory bank.
If the value is zero the tag has hard block boundaries in the USER memory
bank. The tag will not accept BlockWrite commands that start in one block
and end in another block. These block boundaries are determined by the
max block size and the starting address of the first full block. All blocks have
the same maximum size.
If the value is one the tag has no block boundaries in the USER memory
bank. It will accept all BlockWrite commands that are within the memory
bank.
27-31 [RFU] These bits are RFU and should be set to zero.
32-39 Size of Block
Erase
Max block size that the tag supports for the BlockErase command. This
value should be between 1-255 if the BlockErase command is described in
this field.
40 Variable Size
Block Erase
This bit is used to indicate if the tag supports BlockErase commands with
variable sized blocks.
If the value is zero the tag only supports erasing blocks exactly the
maximum block size indicated in bits [39-32].
If the value is one the tag supports erasing blocks less than the maximum
block size indicated in bits [39-32].
41-48 Block Erase EPC
Address Offset
This indicates the starting address of the first full block that may be erased
in EPC memory bank.
49 No Block Erase
EPC Address
Alignment
This bit is used to indicate if the tag memory architecture has hard block
boundaries in the EPC memory bank.
If the value is zero the tag has hard block boundaries in the EPC memory
bank. The tag will not accept BlockErase commands that start in one block
and end in another block. These block boundaries are determined by the
max block size and the starting address of the first full block. All blocks have
the same maximum size.
If the value is one the tag has no block boundaries in the EPC memory
bank. It will accept all BlockErase commands that are within the memory
bank.
50-57 Block Erase
User Address
Offset
This indicates the starting address of the first full block that may be erased
in User memory bank.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 332 of 448
Bit Position
in Segment
Field Description
58 No Block Erase
User Address
Alignment
Bit 58: This bit is used to indicate if the tag memory architecture has hard
block boundaries in the USER memory bank.
If the value is zero the tag has hard block boundaries in the USER memory
bank. The tag will not accept BlockErase commands that start in one block
and end in another block. These block boundaries are determined by the
max block size and the starting address of the first full block. All blocks have
the same maximum size.
If the value is one the tag has no block boundaries in the USER memory
bank. It will accept all BlockErase commands that are within the memory
bank.
59-63 [RFU] These bits are reserved for future use and should be set to zero.
16.2.5 User Memory and BlockPermaLock segment147
This two-word segment is present in the XTID if bit 10 of the XTID header is set. Bits 15-0 shall indicate the size of user memory in words.148
Bits 31-16 shall indicate the size of the blocks in the USER memory bank in words for the BlockPermaLock command. Note: These block149
sizes only apply to the BlockPermaLock command and are independent of the BlockWrite and BlockErase commands.150
Table 16-6 XTID Block PermaLock and User Memory Information151
Bit Position in
Segment
Field Description
0-15 User Memory Size Number of 16-bit words in user memory.
16-31 BlockPermaLock Block
Size
If non-zero, the size in words of each block that may be block
permalocked. That is, the block permalock feature allows
blocks of N*16 bits to be locked, where N is the value of this
field.
If zero, then the XTID does not describe the block size for the
BlockPermaLock feature. The tag may or may not support
block permalocking.
This field SHALL be zero if the Optional Command Support
```
Segment (Section 16.2.3) is present and its
```
BlockPermaLockSupported bit is zero.
16.2.6 Optional Lock Bit segment152
This one-word segment is present in the XTID if bit 9 of the XTID header is set. Bits 0-5 shall indicate the current lock bit settings for the153
memory banks on the tag.154
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 333 of 448
Table 16-7 Lock Bit Information155
Bit Position
in Segment
Field Description
```
0 File_0 memory (permalock) The lock bits are defined by the Lock command in the air
```
protocol specification available at
```
https://www.gs1.org/standards/epc-rfid/uhf-air-interface-
```
protocol
```
1 File_0 memory (pwd write)
```
```
2 TID memory (permalock)
```
```
3 TID memory (pwd write)
```
```
4 EPC memory (permalock)
```
```
5 EPC memory (pwd writ–)
```
6-15 [RFU] These bits are reserved for future use and should be set to
zero.
```
16.3 Serialised Tag Identification (STID)156
```
```
This section specifies a URI form for the serialisation encoded within an XTID, called the Serialised Tag Identifier (STID). The STID URI form157
```
may be used by business applications that use the serialised TID to uniquely identify the tag onto which an EPC has been programmed. The158
STID URI is intended to supplement, not replace, the EPC for those applications that make use of RFID tag serialisation in addition to the159
```
EPC that uniquely identifies the physical object to which the tag is affixed; e.g., in an application that uses the STID to help ensure a tag160
```
has not been counterfeited.161
16.3.1 STID URI grammar162
The syntax of the STID URI is specified by the following grammar:163
```
STID-URI = %s"urn:epc:stid:" 2( %s"x" HexComponent "." ) %s"x" HexComponent164
```
where the first and second HexComponents SHALL consist of exactly three UpperHexChars and the third HexComponent SHALL consist of165
12, 16, 20, 24, 28, 32, or 36 UpperHexChars.166
The first HexComponent is the value of bits 08h-13h. For tags using the Gen2 v1.x air interface, this consists of the 12-bit Tag Mask167
```
Designer ID (MDID); for tags using Gen2 v2 and later versions of the air interface, these twelve bits consist of the three X, S and F168
```
```
indicators (bits 08h-0Ah), followed by the 9-bit MDID (bits 0Bh-13h) as specified in Section 16.1.169
```
The second HexComponent is the value of the Tag Model Number as specified in Section 16.1.170
The third HexComponent is the value of the XTID serial number as specified in Sections 16.2.1 and 16.2.2. The number of171
UpperHexChars in the third HexComponent is equal to the number of bits in the XTID serial number divided by four.172
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 334 of 448
16.3.2 Decoding procedure: TID Bank Contents to STID URI173
The following procedure specifies how to construct an STID URI given the contents of the TID bank of a Gen 2 Tag.174
```
Given:175
```
■ The contents of the TID memory bank of a Gen 2 Tag, as a bit string b0b1 …bN-1 , where the number of bits N is at least 48.176
```
Yields:177
```
■ An STID-URI178
```
Procedure:179
```
1. Bits b0 …b7 should match the value 11100010. If not, stop: this TID bank contents does not contain a TDS-compliant XTID.180
2. Bit b8 should be set to one. If not, stop: this TID bank contents does not contain a TDS-compliant XTID.181
3. Consider bits b8 …b19 as a 12-bit unsigned integer. For tags using the Gen2 v1.x air interface, this consists of the 12-bit Tag Mask182
```
Designer ID (MDID); for tags using Gen2 v2 and later versions of the air interface, these twelve bits consist of the three X, S and F183
```
```
indicators (b8 ,b9,b10 ), followed by the 9-bit MDID (b11 …b19 ).184
```
4. Consider bits b20 …b3 1 as a 12-bit unsigned integer. This is the Tag Model Number.185
5. Consider bits b32 …b34 as a 3-bit unsigned integer V. If V equals zero, stop: this TID bank contents does not contain a serial number.186
```
Otherwise, calculate the length of the serial number L = 4– + 16(V − 1). Consider bits b48b49…b48+L-1 as an L-bit unsigned integer. This187
```
is the serial number.188
6. Construct the STID-URI by concatenating the following strings: the prefix urn:epc:stid:, the lowercase letter x, the value of b8 …b19189
```
from Step 3 as a 3-character hexadecimal numeral, a dot (.) character, the lowercase letter x, the value of the Tag Model Number from190
```
```
Step 4 as a 3-character hexadecimal numeral, a dot (.) character, the lowercase letter x, and the value of the serial number from191
```
```
Step 5 as a (L/4)-character hexadecimal numeral. Only uppercase letters A through F shall be used in constructing the hexadecimal192
```
numerals.193
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 335 of 448
17 User Memory Bank Contents194
The User Memory Bank provides a variable size memory to store additional data attributes related to the object identified in the EPC195
Memory Bank of the tag.196
```
User memory may or may not be present on a given tag. The User Memory Indicator (UMI), within the PC bits, is specified in section 9.3.197
```
```
To conform with this specification, the first eight bits of the User Memory Bank SHALL contain a Data Storage Format Identifier (DSFID) as198
```
specified in [ISO15962]. This maintains compatibility with other standards. The DSFID consists of three logical fields: Access Method,199
Extended Syntax Indicator, and Data Format. The Access Method is specified in the two most significant bits of the DSFID, and is encoded200
with the value "10" to designate the "Packed Objects" Access Method as specified in Annex I herein if the "Packed Objects" Access Method is201
employed, and is encoded with the value "00" to designate the "No-Directory" Access Method as specified in [ISO15962] if the "No-202
Directory" Access Method is employed. The next bit is set to one if there is a second DSFID byte present. The five least significant bits203
```
specify the Data Format, which indicates what data system predominates in the memory contents. If GS1 Application Identifiers (AIs)204
```
predominate, the value of "01001" specifies the GS1 Data Format 9 as registered with ISO, which provides most efficient support for the205
use of AI data elements. Annex I through Annex M of this specification contain the complete specification of the "Packed Objects" Access206
```
Method; this content appears in ISO/IEC 15962 [ISO15962] as Annex I through M, respectively,. A complete definition of the DSFID is207
```
```
specified in [ISO15962]. A complete definition of the table that governs the Packed Objects encoding of Application Identifiers (AIs) is208
```
specified by GS1 and registered with ISO under the procedures of [ISO15962], and is reproduced in F. This table is similar in format to the209
hypothetical example shown as Table L-1 in L, but with entries to accommodate encoding of all valid Application Identifiers.210
A tag whose User Memory Bank programming conforms to this specification SHALL be encoded using either the Packed Objects Access211
Method or the No-Directory Access Method, provided that if the No-Directory Access Method is used that the "application-defined"212
compaction mode as specified in [ISO15962] SHALL NOT be used. A tag whose User Memory Bank programming conforms to this213
specification MAY use any registered Data Format including Data Format 9.214
```
An ISO/IEC 20248 [ISO20248] digital signature (to authenticate the tag data) may be stored in User Memory encoded as GS1 AI (8030)215
```
```
using Packed Objects (Data Format 9) or natively and more efficiently using Data Format 17, since the CIDSnip is encoded as binary data.216
```
```
The CIDSnip corresponds to the value of AI (8030) and consists of the [ISO20248] Domain Authority Identifier (DAID – the party who is217
```
```
accountable for the digital signature), the Certificate Identifier (CID), signature, timestamp and optional client-specific data fields, though218
```
these are typically absent. In both cases the EPC is included in the signature using the [ISO20248] readmethod pragma. It is recommended219
```
to include the TID (using the readmethod pragma) in the digital signature to provide for tag data copy detection. The [ISO20248] Domain220
```
```
Authority Identifier (DAID – the party who is accountable for the digital signature) and the GS1 Party GLN (PGLN) -- corresponding to GS1221
```
```
AI (417) -- are equivalent. Whenever a [ISO20248] digital signature is associated with a GS1 element string, the DAID SHALL use the222
```
PGLN. See [ISO20248] clause 7.5.223
```
An ISO/IEC 20248 DigSig construct expressed using GS1 Application Identifer (8030) can be most efficiently encoded in User Memory using224
```
```
Data Format 17 (rather than Packed Objects using Data Format 9) which is a total length of 352 bits when the signing period is one225
```
calendar year with a resolution of minutes. The length remains the same with any additional data signed, which is placed elsewhere, for226
example an authentication code printed in UV-fluorescent ink or embedded in an hologram or watermark. Such data is included in the227
signature, but not stored in the DigSig construct.228
```
Where the Packed Objects specification in I makes reference to Extensible Bit Vectors (EBVs), the format specified in Annex D SHALL be229
```
used.230
A hardware or software component that conforms to this specification for User Memory Bank reading and writing SHALL fully implement the231
```
Packed Objects Access Method as specified in Annexes I through M of this specification (implying support for all registered Data Formats),232
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 336 of 448
SHALL implement the No-Directory Access Method as specified in [ISO15962], and MAY implement other Access Methods defined in233
[ISO15962] and subsequent versions of that standard. A hardware or software component NEED NOT, however, implement the "application-234
defined" compaction mode of the No-Directory Access Method as specified in [ISO15962]. A hardware or software component whose235
```
intended function is only to initialise tags (e.g., a printer) may conform to a subset of this specification by implementing either the Packed236
```
Objects or the No-Directory access method, but in this case NEED NOT implement both.237
Non-Normative: Explanation: This specification allows two methods of encoding data in user memory. The ISO/IEC 15962238
"No-Directory" Access Method has an installed base owing to its longer history and acceptance within certain end user communities.239
The Packed Objects Access Method was developed to provide for more efficient reading and writing of tags, and less tag memory240
consumption.241
The "application-defined" compaction mode of the No-Directory Access Method is not allowed because it cannot be understood by a242
receiving system unless both sides have the same definition of how the compaction works.243
Note that the Packed Objects Access Method supports the encoding of data either with or without a directory-like structure for244
random access. The fact that the other access method is named "No-Directory" in [ISO15962] should not be taken to imply that the245
Packed Objects Access Method always includes a directory.246
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 337 of 448
18 Conformance247
TDS by its nature has an impact on many parts of the GS1 System Architecture. Unlike other standards that define a specific hardware or248
software interface, TDS defines data formats, along with procedures for converting between equivalent formats. Both the data formats and249
the conversion procedures are employed by a variety of hardware, software, and data components in any given system.250
This section defines what it means to conform to TDS. As noted above, there are many types of system components that have the potential251
to conform to various parts of the TDS, and these are enumerated below.252
18.1 Conformance of RFID Tag Data253
The data programmed on a Gen 2 RFID tag may be in conformance with TDS as specified below. Conformance may be assessed separately254
for the contents of each memory bank.255
Each memory bank may be in an "uninitialised" state or an "initialised" state. The uninitialised state indicates that the memory bank256
contains no data, and is typically only used between the time a tag is manufactured and the time it is first programmed for use by an257
application. The conformance requirements are given separately for each state, where applicable.258
```
18.1.1 Conformance of Reserved Memory Bank (Bank 00)259
```
```
The contents of the Reserved memory bank (Bank 00) of a Gen 2 tag is not subject to conformance to the EPC Tag Data Standard. The260
```
contents of the Reserved memory bank is specified in [UHFC1G2].261
```
18.1.2 Conformance of EPC Memory Bank (Bank 01)262
```
```
The contents of the EPC memory bank (Bank 01) of a Gen 2 tag are subject to conformance to the EPC Tag Data Standard (TDS) as follows.263
```
The contents of the EPC memory bank conform to TDS in the uninitialised state if all of the following are true:264
■ Bit 17h SHALL be set to zero.265
```
■ Bits 18h through 1Fh (inclusive), the Attribute bits, SHALL be set to zero.266
```
```
■ Bits 20h through 27h (inclusive) SHALL be set to zero, indicating an uninitialised EPC Memory Bank.267
```
■ All other bits of the EPC memory bank SHALL be as specified in Section 9 and/or [UHFC1G2], as applicable.268
The contents of the EPC memory bank conform to TDS in the initialised state if all of the following are true:269
■ Bit 17h SHALL be set to zero.270
```
■ Bits 18h through 1Fh (inclusive), the Attribute bits, SHALL be as specified in Sections 9.3 and 9.4.271
```
```
■ Bits 20h through 27h (inclusive) SHALL be set to a valid EPC header value as specified in Table 14-1 that is, a header value not marked as272
```
"reserved" or "unprogrammed tag" in the table.273
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 338 of 448
■ Let N be the value of the "encoding length" column of the row of Table 14-1 corresponding to the header value, and let M be equal to 20 h + N –274
1. Bits 20h through M SHALL be a valid EPC binary encoding; that is, the decoding procedure of Section 14.3.7 when applied to these bits SHALL275
NOT raise an exception.276
```
■ Bits M+1 through the end of the EPC memory bank or bit 20Fh (whichever occurs first) SHALL be set to zero.277
```
■ All other bits of the EPC memory bank SHALL be as specified in Section 9 and/or [UHFC1G2], as applicable.278
Non-Normative: Explanation: A consequence of the above requirements is that to conform to this specification, no279
```
additional application data (such as a second EPC) may be put in the EPC memory bank beyond the EPC that begins at bit 20 h.280
```
```
18.1.3 Conformance of TID Memory Bank (Bank 10)281
```
```
The contents of the TID memory bank (Bank 10) of a Gen 2 tag is subject to conformance to TDS, as specified in Section 16.282
```
```
18.1.4 Conformance of User Memory Bank (Bank 11)283
```
```
The contents of the User memory bank (Bank 11) of a Gen 2 tag is subject to conformance to TDS, as specified in Section 17.284
```
18.2 Conformance of Hardware and Software Components285
Hardware and software components may process data that is read from or written to Gen 2 RFID tags. Hardware and software components286
may also manipulate Electronic Product Codes in various forms regardless of whether RFID tags are involved. All such uses may be subject287
to conformance to TDS as specified below. Exactly what is required to conform depends on what the intended or claimed function of the288
hardware or software component is.289
18.2.1 Conformance of hardware and software Components That Produce or Consume Gen 2 Memory Bank Contents290
This section specifies conformance of hardware and software components that produce and consume the contents of a memory bank of a291
Gen 2 tag. This includes components that interact directly with tags via the Gen 2 Air Interface as well as components that manipulate a292
software representation of raw memory contents293
```
Definitions:294
```
```
■ Bank X Consumer (where X is a specific memory bank of a Gen 2 tag): A hardware or software component that accepts as input via some external295
```
```
interface the contents of Bank X of a Gen 2 tag. This includes components that read tags via the Gen 2 Air Interface (i.e., readers), as well as296
```
```
components that manipulate a software representation of raw memory contents (e.g., "middleware" software that receives a hexadecimal-formatted297
```
```
image of tag memory from an interrogator as input).298
```
```
■ Bank X Producer (where X is a specific memory bank of a Gen 2 tag): A hardware or software component that outputs via some external interface299
```
```
the contents of Bank X of a Gen 2. This includes components that interact directly with tags via the Gen 2 Air Interface (i.e., write-capable300
```
```
interrogators and printers – the memory contents delivered to the tag is an output via the air interface), as well as components that manipulate a301
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 339 of 448
```
software representation of raw memory contents (e.g., software that outputs a "write" command to an interrogator, delivering a hexadecimal-302
```
```
formatted image of tag memory as part of the command).303
```
A hardware or software component that "passes through" the raw contents of tag memory Bank X from one external interface to another is304
simultaneously a Bank X Consumer and a Bank X Producer. For example, consider a reader device that accepts as input from an application305
via its network "wire protocol" a command to write EPC tag memory, where the command includes a hexadecimal-formatted image of the306
tag memory that the application wishes to write, and then writes that image to a tag via the Gen 2 Air Interface. That device is a Bank 01307
Consumer with respect to its "wire protocol," and a Bank 01 Producer with respect to the Gen 2 Air Interface. The conformance308
requirements below insure that such a device is capable of accepting from an application and writing to a tag any EPC bank contents that is309
valid according to this specification.310
The following conformance requirements apply to Bank X Consumers and Producers as defined above:311
```
■ A Bank 01 (EPC bank) Consumer SHALL accept as input any memory contents that conforms to this specification, as conformance is specified in312
```
Section 18.1.2.313
■ If a Bank 01 Consumer interprets the contents of the EPC memory bank received as input, it SHALL do so in a manner consistent with the314
definitions of EPC memory bank contents in this specification.315
```
■ A Bank 01 (EPC bank) Producer SHALL produce as output memory contents that conforms to this specification, as conformance is specified in316
```
Section 18.1.2, whenever the hardware or software component produces output for Bank 01 containing an EPC. A Bank 01 Producer MAY produce317
output containing a non-EPC if it sets bit 17h to one.318
■ If a Bank 01 Producer constructs the contents of the EPC memory bank from component parts, it SHALL do so in a manner consistent with this.319
```
■ A Bank 10 (TID Bank) Consumer SHALL accept as input any memory contents that conforms to this specification, as conformance is specified in320
```
Section 18.1.3.321
■ If a Bank 10 Consumer interprets the contents of the TID memory bank received as input, it SHALL do so in a manner consistent with the322
definitions of TID memory bank contents in this specification.323
```
■ A Bank 10 (TID bank) Producer SHALL produce as output memory contents that conforms to this specification, as conformance is specified in324
```
Section 18.1.3.325
■ If a Bank 10 Producer constructs the contents of the TID memory bank from component parts, it SHALL do so in a manner consistent with this326
specification.327
```
■ Conformance for hardware or software components that read or write the User memory bank (Bank 11) SHALL be as specified in Section 17.328
```
18.2.2 Conformance of hardware and software Components that Produce or Consume URI Forms of the EPC329
This section specifies conformance of hardware and software components that use URIs as specified herein as inputs or outputs.330
```
Definitions:331
```
■ EPC URI Consumer: A hardware or software component that accepts an EPC URI as input via some external interface. An EPC URI Consumer332
may be further classified as a Pure Identity URI EPC Consumer if it accepts an EPC Pure Identity URI as an input, or an EPC Tag/Raw URI333
Consumer if it accepts an EPC Tag URI or EPC Raw URI as input.334
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 340 of 448
■ EPC URI Producer: A hardware or software component that produces an EPC URI as output via some external interface. An EPC URI Producer335
may be further classified as a Pure Identity URI EPC Producer if it produces an EPC Pure Identity URI as an output, or an EPC Tag/Raw URI336
Producer if it produces an EPC Tag URI or EPC Raw URI as output.337
A given hardware or software component may satisfy more than one of the above definitions, in which case it is subject to all of the relevant338
conformance tests below.339
The following conformance requirements apply to Pure Identity URI EPC Consumers:340
■ A Pure Identity URI EPC Consumer SHALL accept as input any string that satisfies the grammar of Section 6, including all constraints on the341
number of characters in various components.342
■ A Pure Identity URI EPC Consumer SHALL reject as invalid any input string that begins with the characters urn:epc:id: that does not satisfy343
the grammar of Section 6, including all constraints on the number of characters in various components.344
■ If a Pure Identity URI EPC Consumer interprets the contents of a Pure Identity URI, it SHALL do so in a manner consistent with the definitions of345
```
the Pure Identity EPC URI in this specification and the specifications referenced herein (including the GS1 General Specifications).346
```
The following conformance requirements apply to Pure Identity URI EPC Producers:347
■ A Pure Identity EPC URI Producer SHALL produce as output strings that satisfy the grammar in Section 6, including all constraints on the number348
of characters in various components.349
■ A Pure Identity EPC URI Producer SHALL NOT produce as output a string that begins with the characters urn:epc:id: that does not satisfy the350
grammar of Section 6, including all constraints on the number of characters in various components.351
■ If a Pure Identity EPC URI Producer constructs a Pure Identity EPC URI from component parts, it SHALL do so in a manner consistent with this352
specification.353
The following conformance requirements apply to EPC Tag/Raw URI Consumers:354
■ An EPC Tag/Raw URI Consumer SHALL accept as input any string that satisfies the TagURI production of the grammar of Section 12.4, and that355
can be encoded according to Section 14.3 without causing an exception.356
■ An EPC Tag/Raw URI Consumer MAY accept as input any string that satisfies the RawURI production of the grammar of Section 12.4.357
■ An EPC Tag/Raw URI Consumer SHALL reject as invalid any input string that begins with the characters urn:epc:tag: that does not satisfy the358
grammar of Section 12.4, or that causes the encoding procedure of Section 14.3 to raise an exception.359
■ An EPC Tag/Raw URI Consumer that accepts EPC Raw URIs as input SHALL reject as invalid any input string that begins with the characters360
```
urn:epc:raw: that does not satisfy the grammar of Section 12.4.361
```
■ To the extent that an EPC Tag/Raw URI Consumer interprets the contents of an EPC Tag URI or EPC Raw URI, it SHALL do so in a manner362
```
consistent with the definitions of the EPC Tag URI and EPC Raw URI in this specification and the specifications referenced herein (including the363
```
```
GS1 General Specifications).364
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 341 of 448
The following conformance requirements apply to EPC Tag/Raw URI Producers:365
■ An EPC Tag/Raw URI Producer SHALL produce as output strings that satisfy the TagURI production or the RawURI production of the grammar of366
Section 12.4, provided that any output string that satisfies the TagURI production must be encodable according to the encoding procedure of367
Section 14.3 without raising an exception.368
■ An EPC Tag/Raw URI Producer SHALL NOT produce as output a string that begins with the characters urn:epc:tag: or urn:epc:raw: except as369
specified in the previous bullet.370
■ If an EPC Tag/Raw URI Producer constructs an EPC Tag URI or EPC Raw URI from component parts, it SHALL do so in a manner consistent with371
this specification.372
18.2.3 Conformance of hardware and software components that translate between EPC Forms373
This section specifies conformance for hardware and software components that translate between EPC forms, such as translating an EPC374
binary encoding to an EPC Tag URI, an EPC Tag URI to a Pure Identity EPC URI, a Pure Identity EPC URI to an EPC Tag URI, or an EPC Tag375
URI to the contents of the EPC memory bank of a Gen 2 tag. Any such component by definition accepts these forms as inputs or outputs,376
and is therefore also subject to the relevant parts of Sections 18.2.1 and 18.2.2.377
■ A hardware or software component that takes the contents of the EPC memory bank of a Gen 2 tag as input and produces the corresponding EPC378
Tag URI or EPC Raw URI as output SHALL produce an output equivalent to applying the decoding procedure of Section 15.2.2 to the input.379
■ A hardware or software component that takes the contents of the EPC memory bank of a Gen 2 tag as input and produces the corresponding EPC380
Tag URI or EPC Raw URI as output SHALL produce an output equivalent to applying the decoding procedure of Section 15.2.3 to the input.381
■ A hardware or software component that takes an EPC Tag URI as input and produces the corresponding Pure Identity EPC URI as output SHALL382
produce an output equivalent to applying the procedure of Section 12.3.3 to the input.383
■ A hardware or software component that takes an EPC Tag URI as input and produces the contents of the EPC memory bank of a Gen 2 tag as384
```
output (whether by actually writing a tag or by producing a software representation of raw memory contents as output) SHALL produce an output385
```
equivalent to applying the procedure of Section 15.1.1 to the input.386
18.3 Conformance of Human Readable Forms of the EPC and of EPC Memory Bank contents387
This section specifies conformance for human readable representations of an EPC. Human readable representations may be used on printed388
labels, in documents, etc. This section does not specify the conditions under which a human readable representation of an EPC or RFID tag389
```
contents shall or should be printed on any label, packaging, or other medium; it only specifies what is a conforming human readable390
```
representation when it is desired to include one.391
■ To conform to this specification, a human readable representation of an electronic product code SHALL be a Pure Identity EPC URI as specified in392
Section 6.393
■ To conform to this specification, a human readable representation of the entire contents of the EPC memory bank of a Gen 2 tag SHALL be an394
```
EPC Tag URI or an EPC Raw URI as specified in Section 12. An EPC Tag URI SHOULD be used when it is possible to do so (that is, when the395
```
```
memory bank contents contains a valid EPC).396
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 342 of 448
A Character Set for Alphanumeric Serial Numbers397
The following table specifies the characters that are permitted by the GS1 General Specifications [GS1GS] for use in alphanumeric serial398
numbers. The columns are as follows:399
■ Graphic symbol: The printed representation of the character as used in human-readable forms.400
■ Name: The common name for the character401
■ Hex Value: A hexadecimal numeral that gives the 7-bit binary value for the character as used in EPC binary encodings. This hexadecimal value is402
```
always equal to the ISO/IEC 646 [ISO646] (ASCII) code for the character.403
```
■ URI Form: The representation of the character within Pure Identity EPC URI and EPC Tag URI forms. This is either a single character whose404
ASCII code is equal to the value in the "hex value" column, or an escape triplet consisting of a percent character followed by two characters405
giving the hexadecimal value for the character.406
Table I.3.1-1 Characters Permitted in Alphanumeric Serial Numbers407
Graphic
symbol
Name Hex Value URI Form Graphic
symbol
Name Hex Value URI Form
! Exclamation
Mark
21 ! M Capital
Letter M
4D M
" Quotation Mark 22 %22 N Capital
Letter N
4E N
% Percent Sign 25 %25 O Capital
Letter O
4F O
& Ampersand 26 %26 P Capital
Letter P
50 P
' Apostrophe 27 ' Q Capital
Letter Q
51 Q
```
( Left
```
Parenthesis
```
28 ( R Capital
```
Letter R
52 R
```
) Right
```
Parenthesis
```
29 ) S Capital
```
Letter S
53 S
- Asterisk 2A * T Capital
Letter T
54 T
- Plus sign 2B + U Capital
Letter U
55 U
, Comma 2C , V Capital
Letter V
56 V
- Hyphen/ Minus 2D - W Capital
Letter W
57 W
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 343 of 448
Graphic
symbol
Name Hex Value URI Form Graphic
symbol
Name Hex Value URI Form
. Full Stop 2E . X Capital
Letter X
58 X
/ Solidus 2F %2F Y Capital
Letter Y
59 Y
0 Digit Zero 30 0 Z Capital
Letter Z
5A Z
1 Digit One 31 1 _ Low Line 5F _
2 Digit Two 32 2 a Small
Letter a
61 a
3 Digit Three 33 3 b Small
Letter b
62 b
4 Digit Four 34 4 c Small
Letter c
63 c
5 Digit Five 35 5 d Small
Letter d
64 d
6 Digit Six 36 6 e Small
Letter e
65 e
7 Digit Seven 37 7 f Small
Letter f
66 f
8 Digit Eight 38 8 g Small
Letter g
67 g
9 Digit Nine 39 9 h Small
Letter h
68 h
: Colon 3A : i Small
Letter i
69 i
```
; Semicolon 3B ; j Small
```
Letter j
6A j
< Less-than Sign 3C %3C k Small
Letter k
6B k
= Equals Sign 3D = l Small
Letter l
6C l
> Greater-than
Sign
3E %3E m Small
Letter m
6D m
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 344 of 448
Graphic
symbol
Name Hex Value URI Form Graphic
symbol
Name Hex Value URI Form
? Question Mark 3F %3F n Small
Letter n
6E n
A Capital Letter A 41 A o Small
Letter o
6F o
B Capital Letter B 42 B p Small
Letter p
70 p
C Capital Letter C 43 C q Small
Letter q
71 q
D Capital Letter
D
44 D r Small
Letter r
72 r
E Capital Letter E 45 E s Small
Letter s
73 s
F Capital Letter F 46 F t Small
Letter t
74 t
G Capital Letter
G
47 G u Small
Letter u
75 u
H Capital Letter H 48 H v Small
Letter v
76 v
I Capital Letter I 49 I w Small
Letter w
77 w
J Capital Letter J 4A J x Small
Letter x
78 x
K Capital Letter K 4B K y Small
Letter y
79 y
L Capital Letter L 4C L z Small
Letter z
7A z
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 345 of 448
```
B Glossary (non-normative)408
```
Please refer to the www.gs1.org/glossary for the latest version of the glossary.409
Term Defined Where Meaning
Application
```
Identifier (AI)
```
[GS1GS] A numeric code that identifies a data element within a GS1 element
string.
Attribute Bits Sections 9.3
and 9.4
An 8-bit field of control information that is stored in the EPC Memory
Bank of a Gen 2 RFID Tag when the tag contains an EPC. The
Attribute Bits includes data that guides the handling of the object to
which the tag is affixed, for example a bit that indicates the presence
of hazardous material.
Barcode A data carrier that holds text data in the form of light and dark
markings which may be read by an optical reader device.
Control
Information
Section 9.1 Information that is used by data capture applications to help control
the process of interacting with RFID Tags. Control Information
includes data that helps a capturing application filter out tags from
large populations to increase read efficiency, special handling
information that affects the behaviour of capturing application,
information that controls tag security features, and so on. Control
Information is typically not passed directly to business applications,
though Control Information may influence how a capturing
application presents business data to the business application level.
Unlike Business Data, Control Information has no equivalent in bar
codes or other data carriers.
Data Carrier Generic term for a marking or device that is used to physically attach
data to a physical object. Examples of data carriers include Bar Codes
and RFID Tags.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 346 of 448
Term Defined Where Meaning
Electronic Product
```
Code (EPC)
```
Section 4 A universal identifier for any physical object. The EPC is designed so
that every physical object of interest to information systems may be
given an EPC that is globally unique and persistent through time.
The primary representation of an EPC was previously in the form of a
```
Pure Identity EPC URI (q.v.), which is a unique string that may be
```
used in information systems, electronic messages, databases, and
other contexts. A secondary representation, the EPC Binary Encoding
```
(q.v.) is available for use in RFID Tags and other settings where a
```
compact binary representation is required.
Starting in TDS 2.0 and EPCIS 2.0 / CBV 2.0, there is now
```
recognition that a GS1 Digital Link URI (or a constrained subset of
```
these, specifically at instance-level granularity and without additional
```
data attributes) is an equivalent way to denote a specific physical
```
object within business applications and traceability data, with a
number of advantages, such as ease of linking/redirection to multiple
kinds of online information and services, making use of multiple link
types and the resolver infrastructure for GS1 Digital Link. GS1
Digital Link URIs can also be used as identifiers within machine-
interpretable Linked Data that expresses factual claims.
EPC Section 4 See Electronic Product Code
```
EPC Bank (of a
```
```
Gen 2 RFID Tag)
```
[UHFC1G2] Bank 01 of a Gen 2 RFID Tag as specified in [UHFC1G2]. The EPC
Bank holds the EPC Binary Encoding of an EPC, together with
additional control information as specified in Section 7.11.
EPC Binary
Encoding
Section 13 A compact encoding of an Electronic Product Code, together with a
```
filter value (if the encoding scheme includes a filter value), into a
```
binary bit string that is suitable for storage in RFID Tags, including
the EPC Memory Bank of a Gen 2 RFID Tag. Owing to trade-offs
between data capacity and the number of bits in the encoded value,
more than one binary encoding scheme exists for certain EPC
schemes.
EPC Binary
Encoding Scheme
Section 13 A particular format for the encoding of an Electronic Product Code,
together with a Filter Value in some cases, into an EPC Binary
Encoding. Each EPC Scheme has at least one corresponding EPC
Binary Encoding Scheme. from a specified combination of data
elements. Owing to trade-offs between data capacity and the number
of bits in the encoded value, more than one binary encoding scheme
exists for certain EPC schemes. An EPC Binary Encoding begins with
an 8-bit header that identifies which binary encoding scheme is used
```
for that binary encoding; this serves to identify how the remainder of
```
the binary encoding is to be interpreted.
EPC Pure Identity
URI
Section 6 See Pure Identity EPC URI.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 347 of 448
Term Defined Where Meaning
EPC Raw URI Section 12 A representation of the complete contents of the EPC Memory Bank
of a Gen 2 RFID Tag,
EPC Scheme Section 6 A particular format for the construction of an Electronic Product Code
from a specified combination of data elements. A Pure Identity EPC
URI begins with the name of the EPC Scheme used for that URI,
which both serves to ensure global uniqueness of the complete URI
as well as identify how the remainder of the URI is to be interpreted.
Each type of GS1 key has a corresponding EPC Scheme that allows
for the construction of an EPC that corresponds to the value of a GS1
key, under certain conditions. Other EPC Schemes exist that allow for
construction of EPCs not related to GS1 keys.
EPC Tag URI Section 12 A representation of the complete contents of the EPC Memory Bank
of a Gen 2 RFID Tag, in the form of an Internet Uniform Resource
Identifier that includes a decoded representation of EPC data fields,
usable when the EPC Memory Bank contains a valid EPC Binary
Encoding. Because the EPC Tag URI represents the complete contents
of the EPC Memory Bank, it includes control information in addition to
the EPC, in contrast to the Pure Identity EPC URI.
Extended Tag
Identification
```
(XTID)
```
Section 16 Information that may be included in the TID Bank of a Gen 2 RFID
Tag in addition to the make and model information. The XTID may
include a manufacturer-assigned unique serial number and may also
include other information that describes the capabilities of the tag.
Filter Value Section 10 A 3-bit field of control information that is stored in the EPC Memory
Bank of a Gen 2 RFID Tag when the tag contains certain types of
EPCs. The filter value makes it easier to read desired RFID Tags in an
environment where there may be other tags present, such as reading
a pallet tag in the presence of a large number of item-level tags.
Gen 2 RFID Tag Section 7.11 An RFID Tag that conforms to one of the EPCglobal Gen 2 family of
air interface protocols. This includes the UHF Class 1 Gen 2 Air
Interface [UHFC1G2], and other standards currently under
development within GS1.
GS1 Company
Prefix
[GS1GS] Part of the GS1 System identification number consisting of a GS1
Prefix and a Company Number, both of which are allocated by GS1
Member Organisations.
GS1 element
string
[GS1GS] The combination of a GS1 Application Identifier and GS1 Application
Identifier Data Field.
GS1 key [GS1GS] A generic term for identification keys defined in the GS1 General
Specifications [GS1GS], namely the GTIN, SSCC, GLN, GRAI, GIAI,
GSRN, GDTI, GSIN, GINC, CPID, GCN and GMN.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 348 of 448
Term Defined Where Meaning
Pure Identity EPC
URI
Section 6 A concrete representation of an Electronic Product Code. The Pure
Identity EPC URI is an Internet Uniform Resource Identifier that
contains an Electronic Product Code and no other information.
Radio-Frequency
Identification
```
(RFID) Tag
```
A data carrier that holds binary data, which may be affixed to a
physical object, and which communicates the data to a interrogator
```
("reader") device through radio.
```
```
Reserved Bank (of
```
```
a Gen 2 RFID Tag)
```
[UHFC1G2] Bank 00 of a Gen 2 RFID Tag as specified in [UHFC1G2]. The
Reserved Bank holds the access password and the kill password.
Tag Identification
```
(TID)
```
[UHFC1G2] Information that describes a Gen 2 RFID Tag itself, as opposed to
describing the physical object to which the tag is affixed. The TID
includes an indication of the make and model of the tag, and may
```
also include Extended TID (XTID) information.
```
```
TID Bank (of a
```
```
Gen 2 RFID Tag)
```
[UHFC1G2] Bank 10 of a Gen 2 RFID Tag as specified in [UHFC1G2]. The TID
```
Bank holds the TID and XTID (q.v.).
```
Uniform Resource
```
Identifier (URI)
```
[RFC3986] A compact sequence of characters that identifies an abstract or
physical resource. A URI may be further classified as a Uniform
```
Resource Name (URN) or a Uniform Resource Locator (URL), q.v.
```
Uniform Resource
```
Locator (URL)
```
```
[RFC3986] A Uniform Resource Identifier (URI) that, in addition to identifying a
```
resource, provides a means of locating the resource by describing its
```
primary access mechanism (e.g., its network "location").
```
Uniform Resource
```
Name (URN)
```
[RFC3986],
[RFC2141]
```
A Uniform Resource Identifier (URI) that is part of the urn scheme
```
as specified by [RFC2141]. Such URIs refer to a specific resource
independent of its network location or other method of access, or
which may not have a network location at all. The term URN may also
refer to any other URI having similar properties.
Because an Electronic Product Code is a unique identifier for a
physical object that does not necessarily have a network location or
other method of access, URNs are used to represent EPCs.
User Memory Bank
```
(of a Gen 2 RFID
```
```
Tag)
```
[UHFC1G2] Bank 11 of a Gen 2 RFID Tag as specified in [UHFC1G2]. The User
Memory may be used to hold additional business data elements
beyond the EPC.
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 349 of 448
C References410
```
[ASN.1] CCITT, "Specification of Basic Encoding Rules for Abstract Syntax Notation One (ASN.1)", CCITT Recommendation X.209, January411
```
1988.412
[EPCAF] F. Armenio et al, "EPCglobal Architecture Framework," Version 1.7, May 2015, https://www.gs1.org/id-keys-epcrfid-epcis/epc-rfid-413
architecture-framework/1-6414
[GS1Arch] "The GS1 System Architecture," GS1 technical document,415
```
http://www.gs1.org/docs/gsmp/architecture/GS1_System_Architecture.pdf416
```
[GS1DL] GS1 Digital Link Standard: https://www.gs1.org/standards/gs1-digital-link417
[GS1GS] "GS1 General Specifications", GS1, https://www.gs1.org/standards/barcodes-epcrfid-id-keys/gs1-general-specifications.418
```
[ISO15961] ISO/IEC 15961, "Information technology – Radio frequency identification (RFID) for item management – Data protocol:419
```
application interface".420
```
[ISO15962] ISO/IEC 15962, "Information technology – Radio frequency identification (RFID) for item management – Data protocol: data421
```
encoding rules and logical memory functions".422
[ISO15963] ISO/IEC 15963, "Information technology — Radio frequency identification for item management — Unique identification for RF423
tags"424
[ISO18000-63] ISO/IEC 18000-63, "Information technology — Radio frequency identification for item management — Part 63: Parameters425
for air interface communications at 860 MHz to 960 MHz Type C"426
[ISO20248] ISO/IEC 20248, "Information technology — Automatic identification and data capture techniques — Digital signature data427
structure schema".428
[ISO646] ISO/IEC 646, "Information technology — ISO 7-bit coded character set for information interchange"429
[ISO8859-6] ISO/IEC 8859-6, "Information technology — 8-bit single-byte coded graphic character sets — Part 6: Latin/Arabic alphabet"430
```
[ISODir2] ISO, "Rules for the structure and drafting of International Standards (ISO/IEC Directives, Part 2 , 2001, 4th edition)," July 2002.431
```
[RFC2141] R. Moats, "URN Syntax," RFC2141, May 1997, http://www.ietf.org/rfc/rfc2141.432
```
[RFC3986] T. Berners-Lee, R. Fielding, L. Masinter, "Uniform Resource Identifier (URI): Generic Syntax," RFC3986, January 2005,433
```
```
http://www.ietf.org/rfc/rfc3986.434
```
[RFC5234] D. Crocker, P. Overell, "Augmented BNF for Syntax Specifications: ABNF" RFC5234, January 2008,435
```
http://www.ietf.org/rfc/rfc5234.436
```
[RFC7405] P. Kyzivat, "Case-Sensitive String Support in ABNF" RFC7405, December 2014, http://www.ietf.org/rfc/rfc7405.437
```
[ONS] EPCglobal, "EPCglobal Object Naming Service (ONS), Version 1.0.1," EPCglobal Ratified Standard, May 2008,438
```
```
http://www.epcglobalinc.org/standards/ons/ons_1_0_1-standard-20080529.pdf.439
```
[SPEC2000] Air Transport Association, "Spec 2000 E-Business Specification for Materials Management," May 2009,440
```
http://www.spec2000.com.441
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 350 of 448
[UHFC1G2] EPCglobal, "EPC™ Radio-Frequency Identity Protocols Class-1 Generation-2 UHF RFID Protocol for Communications at 860 MHz442
– 960 MHz Version 1.2.0," EPCglobal Specification, May 2008, http://www.epcglobalinc.org/standards/uhfc1g2/uhfc1g2_1_2_0-standard-443
20080511.pdf.444
```
[UID] "United States Department of Defense Guide to Uniquely Identifying Items " Version 3.0 (December 2, 2014),445
```
```
https://dodprocurementtoolbox.com/cms/sites/default/files/resources/DoD%20Guide%20to%20Uniquely%20Identify%20Items%20v3.0.pd446
```
f.447
[USDOD] "United States Department of Defense Suppliers’ Passive RFID Information Guide,"448
```
https://www.acq.osd.mil/log/LOG/.AIT.html/DoD_Suppliers_Passive_RFID_Info_Guide_v15update.pdf449
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 351 of 448
D Extensible Bit Vectors450
```
An Extensible Bit Vector (EBV) is a data structure with an extensible data range.451
```
An EBV is an array of blocks. Each block contains a single extension bit followed by a specific number of data bits. If B is the total number of452
```
bits in one block, then a block co–tains B − 1 data bits. The notation EBV-n used in this specification indicates an EBV with a block size of n;453
```
e.g., EBV-8 denotes an EBV with B=8.454
The data value represented by an EBV is simply the bit string formed by the data bits as read from left to right, ignoring all extension bits.455
```
The last block of an EBV has an extension bit of zero, and all blocks of an EBV preceding the last block (if any) have an extension bit of one.456
```
The following table illustrates different values represented in EBV-6 format and EBV-8 format. Spaces are added to the EBVs for visual457
clarity.458
Value EBV-6 EBV-8
0 000000 00000000
1 000001 00000001
```
31 (2 5−1) 011111 00011111
```
```
32 (2 5 ) 100001 000000 00100000
```
```
33 (2 5 +1) 100001 000001 00100001
```
```
127 (2 7−1) 100011 011111 01111111
```
```
128 (2 7 ) 100100 000000 10000001 00000000
```
```
129 (2 7 +1) 100100 000001 10000001 00000001
```
```
16384 (2 14 ) 110000 100000 000000 10000001 10000000 00000000
```
The Packed Objects specification in I makes use of EBV-3, EBV-6, and EBV-8.459
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 352 of 448
```
E (non-normative) Examples: EPC encoding and decoding460
```
```
This section presents two detailed examples showing encoding and decoding between the Serialised Global Identification Number (SGTIN)461
```
and the EPC memory bank of a Gen 2 RFID tag, and summary examples showing various encodings of all EPC schemes.462
As these are merely illustrative examples, in all cases the indicated normative sections of this specification should be consulted for the463
definitive rules for encoding and decoding. The diagrams and accompanying notes in this section are not intended to be a complete464
specification for encoding or decoding, but instead serve only to illustrate the highlights of how the normative encoding and decoding465
procedures function. The procedures for encoding other types of identifiers are different in significant ways, and the appropriate sections of466
this specification should be consulted.467
```
E.1 Encoding a Serialised Global Trade Item Number (SGTIN) to SGTIN-96468
```
```
This example illustrates the encoding of a GS1 element string containing a Serialised Global Trade Item Number (SGTIN) into an EPC Gen 2469
```
RFID tag using the SGTIN-96 EPC scheme, with intermediate steps including the EPC URI, the EPC Tag URI, and the EPC Binary Encoding.470
In some applications, only a part of this illustration is relevant. For example, an application may only need to transform a GS1 element471
string into an EPC URI, in which case only the top of the illustration is needed.472
The illustration below makes reference to the following notes:473
■ Note 1: The step of converting a GS1 element string into the EPC Pure Identity URI requires that the number of digits in the GS1 Company Prefix474
```
be determined; e.g., by reference to an external table of company prefixes. In this example, the GS1 Company Prefix is shown to be seven digits.475
```
■ Note 2: The check digit in GTIN as it appears in the GS1 element string is not included in the EPC Pure Identity URI.476
```
■ Note 3: The SGTIN-96 EPC scheme may only be used if the Serial Number meets certain constraints. Specifically, the serial number must (a)477
```
```
consist only of digit characters; (b) not begin with a zero digit (unless the entire serial number is the single digit ‘0’); and (c) correspond to a478
```
```
decimal numeral whose numeric value that is less than 2 38 (less than 274,877,906,944). For all other serial numbers, the SGTIN-198 EPC479
```
scheme must be used. Note that the EPC URI is identical regardless of whether SGTIN-96 or SGTIN-198 is used in the RFID Tag.480
■ Note 4: EPC Binary Encoding header values are defined in Section 14.2.481
■ Note 5: The number of bits in the GS1 Company Prefix and Indicator/Item Reference fields in the EPC Binary Encoding depends on the number482
of digits in the GS1 Company Prefix portion of the EPC URI, and this is indicated by a code in the Partition field of the EPC Binary Encoding. See483
```
14.2. (for the SGTIN EPC only).484
```
■ Note 6: The Serial field of the EPC Binary Encoding for SGTIN-96 is 38 bits.485
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 353 of 448
```
486 (01) 09506000134352(21)6789
```
```
(01) 0 95060001343 5 2 (21) 6789
```
```
urn:epc:id:sgtin: 95060001343 . 05 . 6789
```
```
urn:epc:id:sgtin:95060001343.05.6789
```
GS1 element string
GS1 element string to EPC
Pure Identity URI
```
(Section 7.2.3)
```
```
urn:epc:id:sgtin:95060001343.05.6789
```
EPC Pure Identity URI to
EPC Tag URI
```
(Section 12.3.2)
```
```
urn:epc:tag:sgtin-96:3.95060001343.05.6789
```
EPC Pure Identity URI
Filter Value = 3
```
(Section 10.2)
```
```
urn:epc:tag:sgtin-96:3.95060001343.05.6789
```
EPC Tag URI
```
urn:epc:tag:sgtin-96:3.95060001343.05.6789
```
EPC Tag URI
to EPC Binary Encoding
```
(Section 14.3)
```
001100000110011011000100010000001001000001000111111000010100000000000
000000000000001101010000101EPC Binary
00110000
Header
011
Filter
001
Partition
101100010001000000100100
0001000111111
GS1 Company Prefix
0000101
Indicator/Item Ref
0000000000000000000
0000001101010000101
```
Serial (38 bits)
```
EPC Binary Encoding
to Gen 2 memory
```
(Section 15.1) …
```
```
CRC (16 bits)
```
0
Toggle
00000000
AttributeBits
00110000…10000101
EPC binary
0
XPC
0
UMI
00110
Length
00 h 15 h 16 h 17 h 20 h18 h 1Fh0Fh 7FhMemory Address
Note 1 Note 2
Note 5 Note 6
96-bit EPC
Scheme Selected
Note 3
Note 4
```
https://id.gs1.org/01/09506000134352/21/6789GS1 Digital Link URI
```
```
urn:epc:tag:sgtin-96:3.95060001343.05.6789
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 354 of 448
```
E.2 Decoding an SGTIN-96 to a Serialised Global Trade Item Number (SGTIN)487
```
This example illustrates the decoding of an EPC Gen 2 RFID tag containing an SGTIN-96 EPC Binary Encoding into a GS1 element string488
```
containing a Serialised Global Trade Item Number (SGTIN), with intermediate steps including the EPC Binary Encoding, the EPC Tag URI,489
```
and the EPC URI.490
In some applications, only a part of this illustration is relevant. For example, an application may only need to convert an EPC binary491
encoding to an EPC URI, in which case only the top of the illustration is needed.492
The illustration below makes reference to the following notes:493
■ Note 1: The EPC Binary Encoding header indicates how to interpret the remainder of the binary data, and the EPC scheme name to be included494
in the EPC Tag URI. EPC Binary Encoding header values are defined in Section 14.2.495
■ Note 2: The Partition field of the EPC Binary Encoding contains a code that indicates the number of bits in the GS1 Company Prefix field and the496
Indicator/Item Reference field. The partition code also determines the number of decimal digits to be used for those fields in the EPC Tag URI497
```
(the decimal representation for those two fields is padded on the left with zero characters as necessary). See Section 14.2. (for the SGTIN EPC498
```
```
only).499
```
■ Note 3: For the SGTIN-96 EPC scheme, the Serial Number field is decoded by interpreting the bits as a binary integer and converting to a500
```
decimal numeral without leading zeros (unless all serial number bits are zero, which decodes as the string "0"). Serial numbers containing non-501
```
digit characters or that begin with leading zero characters may only be encoded in the SGTIN-198 EPC scheme.502
■ Note 4: The check digit in the GS1 element string is calculated from other digits in the EPC Pure Identity URI, as specified in Section 7.2.3.503
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 355 of 448
504
```
urn:epc:tag:sgtin-96:3.95060001343.05.6789
```
EPC Binary Encoding
to EPC Tag URI
```
(Section 14.3.7)
```
00110000
Header
011
Filter
001
Partition
101100010001000000100100
0001000111111
GS1 Company Prefix
0000101
Indicator/Item Ref
0000000000000000000
0000001101010000101
```
Serial (38 bits)
```
Gen 2 memory to
EPC Binary Enco-
```
ding (Section 15.2)
```
…
```
CRC (16 bits)
```
0
Toggle
00000000
AttributeBits
00110000…10000101
EPC binary
0
XPC
0
UMI
00110
Length
00 h 15 h 16 h 17 h 20 h18 h 1Fh0Fh 7FhMemory Address
```
(01)09506000134352(21)6789
```
```
https://id.gs1.org/01/09506000134352/21/6789
```
GS1 element string
GS1 Digital Link URI
```
urn:epc:id:sgtin:9506000134305.05.6789
```
EPC Pure Identity URI
Filter Value = 3
```
(Section 10.2)
```
```
urn:epc:tag:sgtin-96:3.9506000134305.6789EPC Tag URI
```
001100000110011011000100010000001001000001000111111000010100000000000
000000000000001101010000101EPC Binary
```
(01) 0 9506000134305 2 (21) 6789
```
EPC Pure Identity URI to
GS1 Element String
```
(Section 7.2.3)
```
Note 1
Note 2
96-bit EPC
Scheme Selected
```
urn:epc:id:sgtin:9506000134305.05.6789
```
EPC Tag URI to EPC Pure
Identity URI
```
(Section 12.3)
```
```
urn:epc:tag:sgtin-96:3.9506000134305.05.6789
```
```
urn:epc:id:sgtin:9506000134305.05.6789
```
ΣNote 4
Note 3
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 356 of 448
E.3 Summary Examples of All EPC schemes505
SGTIN-96
```
GS1 element string (01)09506000134352(21)123456789
```
GS1 Digital Link URI https://id.gs1.org/01/09506000134352/21/123456789
EPC URI urn:epc:id:sgtin:95060001343.05.1234567896789
EPC Tag URI urn:epc:tag:sgtin-96:3.95060001343.05.123456789
EPC Binary Encoding
```
(hex)
```
3066C4409047E140075BCD15
506
SGTIN-198
GS1 element
string
```
(01)09506000134352(21)32a/b
```
GS1 Digital Link
URI
```
https://id.gs1.org/01/09506000134352/21/32a%2Fb
```
EPC URI urn:epc:id:sgtin:95060001343.05.32a%2Fb
EPC Tag URI urn:epc:tag:sgtin-198:3.95060001343.05.32a%2Fb
EPC Binary
```
Encoding (hex)
```
3666C4409047E159B2C2BF100000000000000000000000000000
507
```
SGTIN+ (assuming filter value 3 and no +AIDC data)
```
```
GS1 element string (01)79521141123453(21)32a/b
```
GS1 Digital Link URI https://id.gs1.org/01/79521141123453/21/32a%2Fb
```
EPC Binary Encoding (hex) F73795211411234538566CB0AFC4
```
508
```
DSGTIN+ (assuming filter value 3 and no +AIDC data)
```
```
GS1 element string (01)79521141123453(21)32a/b(17)220630
```
GS1 Digital Link URI https://id.gs1.org/01/79521141123453/21/32a%2Fb?17=220630
```
(https://id.gs1.org/01/79521141123453/21/32a%2Fb in EPCIS)
```
```
EPC Binary Encoding (hex) FB342CDE795211411234538566CB0AFC4
```
509
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 357 of 448
```
SGTIN++ (assuming filter value 3 and no +AIDC data)
```
```
GS1 element string (01)79521141123453(21)32a/b
```
GS1 Digital Link URI https://example.com/01/79521141123453/21/32a%2Fb
```
EPC Binary Encoding (hex) FD3795211411234538566CB0AFC525065F1876F0D996D800
```
510
```
DSGTIN++ (assuming filter value 3 and no +AIDC data)
```
```
GS1 element string (01)79521141123453(21)32a/b(17)220630
```
GS1 Digital Link URI https://example.com/01/79521141123453/21/32a%2Fb?17=220630
```
(https://example.com/01/79521141123453/21/32a%2Fb in EPCIS)
```
```
EPC Binary Encoding (hex) FC342CDE795211411234538566CB0AFC525065F1876F0D996D80
```
511
SSCC-96
```
GS1 element string (00)095201234567891235
```
GS1 Digital Link URI https://example.com/00/095201234567891235
```
GCP length 6 (partition value "6")
```
EPC URI urn:epc:id:sscc:952012.03456789123
```
Filter value "All Others" (0)
```
EPC Tag URI urn:epc:tag:sscc-96:0.952012.03456789123
```
EPC Binary Encoding (hex) 311BA1B300CE0A6A83000000
```
512
SSCC+
```
GS1 element string (00)095201234567891235
```
GS1 Digital Link URI https://id.gs1.org/00/095201234567891235
```
+Data appended to EPC? no (0)
```
```
Filter value "All Others" (0)
```
```
EPC Binary Encoding (hex) F90095201234567891235
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 358 of 448
513
SSCC++
```
GS1 element string (00)095201234567891235
```
GS1 Digital Link URI https://id.example.com/00/095201234567891235
```
+Data appended to EPC? no (0)
```
```
Filter value "All Others" (0)
```
```
EPC Binary Encoding (hex) F9009520123456789123592832F8C3B786CCB6C0
```
514
SGLN-96
```
GS1 element string (414)9521141123454(254)5678
```
GS1 Digital Link URI https://example.com/414/9521141123454/254/5678
EPC URI urn:epc:id:sgln:9521141.12345.5678
EPC Tag URI urn:epc:tag:sgln-96:3.9521141.12345.5678
```
EPC Binary Encoding (hex) 3276451FD46072000000162E
```
515
SGLN-195
```
GS1 element string (414)9521141123454(254)32a/b
```
GS1 Digital Link URI https://example.com/414/9521141123454/254/32a%2Fb
EPC URI urn:epc:id:sgln:9521141.12345.32a%2Fb
EPC Tag URI urn:epc:tag:sgln-195:3.9521141.12345.32a%2Fb
```
EPC Binary Encoding (hex) 3976451FD46072CD9615F8800000000000000000000000000000
```
516
SGLN+
```
GS1 element string (414)9521141123454(254)32a/b
```
GS1 Digital Link URI https://id.gs1.org/414/9521141123454/254/32a%2Fb
```
EPC Binary Encoding (hex) F2395211411234548566CB0AFC4
```
517
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 359 of 448
SGLN++
```
GS1 element string (414)9521141123454(254)32a/b
```
GS1 Digital Link URI https://id.example.com/414/9521141123454/254/32a%2Fb
```
EPC Binary Encoding (hex) E9395211411234548566CB0AFC525065F1876F0D996D8000
```
518
GRAI-96
```
GS1 element string (8003)095211411234545678
```
GS1 Digital Link URI https://example.com/8003/095211411234545678
EPC URI urn:epc:id:grai:9521141.12345.5678
EPC Tag URI urn:epc:tag:grai-96:3.9521141.12345.5678
```
EPC Binary Encoding (hex) 3376451FD40C0E400000162E
```
519
GRAI-170
```
GS1 element string (8003)0952114112345432a/b
```
GS1 Digital Link URI https://example.com/8003/0952114112345432a%2Fb
EPC URI urn:epc:id:grai:9521141.12345.32a%2Fb
EPC Tag URI urn:epc:tag:grai-170:3.9521141.12345.32a%2Fb
```
EPC Binary Encoding (hex) 3776451FD40C0E59B2C2BF1000000000000000000000
```
520
GRAI+
```
GS1 element string (8003)0952114112345432a/b
```
GS1 Digital Link URI https://id.gs1.org/8003/0952114112345432a%2Fb
```
EPC Binary Encoding (hex) F13095211411234548566CB0AFC4
```
521
GRAI++
```
GS1 element string (8003)0952114112345432a/b
```
GS1 Digital Link URI https://id.example.com/8003/0952114112345432a%2Fb
```
EPC Binary Encoding (hex) EB3095211411234548566CB0AFC525065F1876F0D996D800
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 360 of 448
522
GIAI-96
```
GS1 element string (8004)95211415678
```
GS1 Digital Link URI https://example.com/8004/95211415678
EPC URI urn:epc:id:giai:9521141.5678
EPC Tag URI urn:epc:tag:giai-96:3.9521141.5678
```
EPC Binary Encoding (hex) 3476451FD40000000000162E
```
523
GIAI-202
```
GS1 element string (8004)952114132a/b
```
GS1 Digital Link URI https://example.com/8004/952114132a%2Fb
EPC URI urn:epc:id:giai:9521141.32a%2Fb
EPC Tag URI urn:epc:tag:giai-202:3.9521141.32a%2Fb
```
EPC Binary Encoding (hex) 3876451FD59B2C2BF10000000000000000000000000000000000
```
524
GIAI+
```
GS1 element string (8004)952114132a/b
```
GS1 Digital Link URI https://id.gs1.org/8004/952114132a%2Fb
```
EPC Binary Encoding (hex) FA3952114132E83C2BF10
```
525
GIAI++
```
GS1 element string (8004)952114132a/b
```
GS1 Digital Link URI https://id.example.com/8004/952114132a%2Fb
```
EPC Binary Encoding (hex) EE3952114132E83C2BF1494197C61DBC3665B600
```
526
GSRN-96
```
GS1 element string (8018)952114112345678906
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 361 of 448
GSRN-96
GS1 Digital Link URI https://example.com/8018/952114112345678906
EPC URI urn:epc:id:gsrn:9521141.1234567890
EPC Tag URI urn:epc:tag:gsrn-96:3.9521141.1234567890
```
EPC Binary Encoding (hex) 2D76451FD4499602D2000000
```
527
GSRN+
```
GS1 element string (8018)952114112345678906
```
GS1 Digital Link URI https://id.gs1.org/8018/952114112345678906
```
EPC Binary Encoding (hex) F43952114112345678906
```
528
GSRN++
```
GS1 element string (8018)952114112345678906
```
GS1 Digital Link URI https://id.example.com/8018/952114112345678906
```
EPC Binary Encoding (hex) E7395211411234567890692832F8C3B786CCB6C0
```
529
GSRNP-96
```
GS1 element string (8017)952114112345678906
```
GS1 Digital Link URI https://example.com/8017/952114112345678906
EPC URI urn:epc:id:gsrnp:9521141.1234567890
EPC Tag URI urn:epc:tag:gsrnp-96:3.9521141.1234567890
```
EPC Binary Encoding (hex) 2E76451FD4499602D2000000
```
530
GSRNP+
```
GS1 element string (8017)952114112345678906
```
GS1 Digital Link URI https://id.gs1.org/8017/952114112345678906
```
EPC Binary Encoding (hex) F53952114112345678906
```
531
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 362 of 448
GSRNP++
```
GS1 element string (8017)952114112345678906
```
GS1 Digital Link URI https://id.example.com/8017/952114112345678906
```
EPC Binary Encoding (hex) E8395211411234567890692832F8C3B786CCB6C0
```
532
GDTI-96
```
GS1 element string (253)95211411234545678
```
GS1 Digital Link URI https://example.com/253/95211411234545678
EPC URI urn:epc:id:gdti:9521141.12345.5678
EPC Tag URI urn:epc:tag:gdti-96:3.9521141.12345.5678
```
EPC Binary Encoding (hex) 2C76451FD46072000000162E
```
533
GDTI-174
```
GS1 element string (253)9521141987650ABCDefgh012345678
```
GS1 Digital Link URI https://example.com/253/9521141987650ABCDefgh012345678
EPC URI urn:epc:id:gdti:9521141.98765.ABCDefgh012345678
EPC Tag URI urn:epc:tag:gdti-174:3.9521141.98765.ABCDefgh012345678
```
EPC Binary Encoding (hex) 3E76451FD7039B061438997367D0C18B266D1AB66EE0
```
534
GDTI+
```
GS1 element string (253)95211411234545678
```
GS1 Digital Link URI https://id.gs1.org/253/95211411234545678
```
EPC Binary Encoding (hex) F6395211411234540458B8
```
535
GDTI++
```
GS1 element string (253)95211411234545678
```
GS1 Digital Link URI https://id.example.com/253/95211411234545678
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 363 of 448
GDTI++
```
EPC Binary Encoding (hex) EA395211411234540458BA4A0CBE30EDE1B32DB0
```
536
CPI-96
```
GS1 element string (8010)952114198765(8011)12345
```
GS1 Digital Link URI https://example.com/8010/952114198765/8011/12345
EPC URI urn:epc:id:cpi:9521141.98765.12345
EPC Tag URI urn:epc:tag:cpi-96:3.9521141.98765.12345
```
EPC Binary Encoding (hex) 3C76451FD400C0E680003039
```
537
CPI-var
```
GS1 element string (8010)95211415PQ7/Z43(8011)12345
```
GS1 Digital Link URI https://example.com/8010/95211415PQ7%2FZ43/8011/12345
EPC URI urn:epc:id:cpi:9521141.5PQ7%2FZ43.12345
EPC Tag URI urn:epc:tag:cpi-var:3.9521141.5PQ7%2FZ43.12345
```
EPC Binary Encoding (hex) 3D76451FD75411DEF6B4CC00000003039000
```
538
CPI+
```
GS1 element string (8010)95211415PQ7/Z43(8011)12345
```
GS1 Digital Link URI https://id.gs1.org/8010/95211415PQ7%2FZ43/8011/12345
```
EPC Binary Encoding (hex) F0395211415E87A145BAFB4D19A8C0E4
```
539
CPI++
```
GS1 element string (8010)95211415PQ7/Z43(8011)12345
```
GS1 Digital Link URI https://id.example.com/8010/95211415PQ7%2FZ43/8011/12345
```
EPC Binary Encoding (hex) E6395211415E87A145BAFB4D19A8C0E64A0CBE30EDE1B32DB000
```
540
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 364 of 448
SGCN-96
```
GS1 element string (255)952114167890904711
```
GS1 Digital Link URI https://example.com/255/952114167890904711
EPC URI urn:epc:id:sgcn:9521141.67890.04711
EPC Tag URI urn:epc:tag:sgcn-96:3.9521141.67890.04711
```
EPC Binary Encoding (hex) 3F76451FD612640000019907
```
541
SGCN+
```
GS1 element string (255)952114167890904711
```
GS1 Digital Link URI https://id.gs1.org/255/952114167890904711
```
EPC Binary Encoding (hex) F839521141678909509338
```
542
SGCN++
```
GS1 element string (255)952114167890904711
```
GS1 Digital Link URI https://id.example.com/255/952114167890904711
```
EPC Binary Encoding (hex) EC3952114167890950933C94197C61DBC3665B60
```
543
GID-96
EPC URI urn:epc:id:gid:952056.2718.1414
EPC Tag URI urn:epc:tag:gid-96:952056.2718.1414
```
EPC Binary Encoding (hex) 3500E86F8000A9E000000586
```
544
USDOD-96
EPC URI urn:epc:id:usdod:CAGEY.5678
EPC Tag URI urn:epc:tag:usdod-96:3.CAGEY.5678
```
EPC Binary Encoding (hex) 2F320434147455900000162E
```
545
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 365 of 448
ADI-var
EPC URI urn:epc:id:adi:35962.PQ7VZ4.M37GXB92
EPC Tag URI urn:epc:tag:adi-var:3.35962.PQ7VZ4.M37GXB92
```
EPC Binary Encoding (hex) 3B0E0CF5E76C9047759AD00373DC7602E7200
```
546
ITIP-110
```
GS1 element string (8006)095211411234540102(21)981
```
GS1 Digital Link URI https://example.com/8006/095211411234540102/21/981
EPC URI urn:epc:id:itip:9521141.012345.01.02.981
EPC Tag URI urn:epc:tag:itip-110:3.9521141.012345.01.02.981
```
EPC Binary Encoding (hex) 4076451FD40C0E40820000000F54
```
547
ITIP-212
```
GS1 element string (8006)095211411234540102(21)mw133
```
GS1 Digital Link URI https://example.com/8006/095211411234540102/21/mw133
EPC URI urn:epc:id:itip:9521141.012345.01.02.mw133
EPC Tag URI urn:epc:tag:itip-212:3.9521141.012345.01.02.mw133
```
EPC Binary Encoding (hex) 4176451FD40C0E4082DBDD8B36600000000000000000000000000000
```
548
ITIP+
```
GS1 element string (8006)095211411234540102(21)rif981
```
GS1 Digital Link URI https://id.gs1.org/8006/095211411234540102/21/rif981
```
EPC Binary Encoding (hex) F3309521141123454010266AE27FDF35
```
549
ITIP++
```
GS1 element string (8006)095211411234540102(21)rif981
```
GS1 Digital Link URI https://id.example.com/8006/095211411234540102/21/rif981
```
EPC Binary Encoding (hex) F3309521141123454010266AE27FDF3592832F8C3B786CCB6C00
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 366 of 448
F Packed objects ID Table for Data Format 9550
This section provides the Packed Objects ID Table for Data Format 9, which defines Packed Objects ID values, OIDs, and format strings for551
GS1 Application Identifiers.552
Section F.1 is a non-normative listing of the content of the ID Table for Data Format 9, in a human readable, tabular format. Section F.2 is553
the normative table, in machine readable, comma-separated-value format, as registered with ISO. As of TDS 2.1, Section F.2 is554
supplemented with an external, normative artefact in CSV format.555
Note that the following data attributes are intentionally omitted:556
```
Identification of a Made-to-order (MtO) trade item (GTIN) [AI (03)] and Highly Individualised Device Registration Identifier (HIDRI) [AI557
```
```
(8014)] are defined for the Master Unique Device Identifiers – Device Identifier (M-UDI-DI) restricted application, and as such are not558
```
permitted for use in an EPC/RFID data carrier.559
```
F.1 Tabular Format (non-normative)560
```
This section is a non-normative listing of the content of the ID Table for Data Format 9, in a human readable, tabular format. See561
Section F.2 for the normative, machine readable, comma-separated-value format, as registered with ISO.562
K-Text = GS1 AI ID Table for ISO/IEC 15961 Format 9
K-Version = 1.00
K-ISO15434=05
K-Text = Primary Base Table
K-TableID = F9B0
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 90
AI or AIs IDvalue OIDs IDstring Name Data Title FormatString
```
00 1 0 00 SSCC (Serial
```
Shipping
```
Container Code)
```
SSCC 18n
01 2 1 01 Global Trade Item
Number
GTIN 14n
```
02 + 37 3 (2)(37) (02)(37) GTIN + Count of
```
trade items
contained in a
logistic unit
CONTENT +
COUNT
```
(14n)(1*8n)
```
10 4 10 10 Batch or lot
number
BATCH/LOT 1*20an
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 367 of 448
K-Text = GS1 AI ID Table for ISO/IEC 15961 Format 9
11 5 11 11 Production date
```
(YYMMDD)
```
PROD DATE 6n
12 6 12 12 Due date
```
(YYMMDD)
```
DUE DATE 6n
13 7 13 13 Packaging date
```
(YYMMDD)
```
PACK DATE 6n
15 8 15 15 Best before date
```
(YYMMDD)
```
BEST BEFORE OR
SELL BY
6n
17 9 17 17 Expiration date
```
(YYMMDD)
```
USE BY OR
EXPIRY
6n
20 10 20 20 Internal product
variant
VARIANT 2n
21 11 21 21 Serial number SERIAL 1*20an
22 12 22 22 Consumer product
variant
CPV 1*20an
240 13 240 240 Additional product
identification
assigned by the
manufacturer
ADDITIONAL ID 1*30an
241 14 241 241 Customer part
number
CUST. PART NO. 1*30an
242 15 242 242 Made-to-Order
Variation Number
VARIATION
NUMBER
1*6n
250 16 250 250 Secondary serial
number
SECONDARY
SERIAL
1*30an
251 17 251 251 Reference to
source entity
REF. TO SOURCE 1*30an
253 18 253 253 Global Document
Type Identifier
DOC. ID 13n 0*17an
30 19 30 30 Variable count of
```
items (Variable
```
Measure Trade
```
Item)
```
VAR. COUNT 1*8n
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 368 of 448
K-Text = GS1 AI ID Table for ISO/IEC 15961 Format 9
310n
320n etc
20 K-Secondary
= S00
Net weight,
kilograms or
pounds or troy oz
```
(Variable Measure
```
```
Trade Item)
```
311n
321n etc
21 K-Secondary
= S01
Length of first
dimension
```
(Variable Measure
```
```
Trade Item)
```
312n
324n etc
22 K-Secondary
= S02
Width, diameter,
or second
dimension
```
(Variable Measure
```
```
Trade Item)
```
313n
327n etc
23 K-Secondary
= S03
Depth, thickness,
height, or third
dimension
```
(Variable Measure
```
```
Trade Item)
```
314n
350n etc
24 K-Secondary
= S04
```
Area (Variable
```
Measure Trade
```
Item)
```
315n
316n etc
25 K-Secondary
= S05
Net volume
```
(Variable Measure
```
```
Trade Item)
```
330n or
340n
26 330%x30-36
/ 340%x30-
36
330%x30-
36 /
340%x30-
36
Logistic weight,
kilograms or
pounds
GROSS WEIGHT
```
(kg) or (lb)
```
6n / 6n
331n,
341n, etc
27 K-Secondary
= S09
Length or first
dimension
332n,
344n, etc
28 K-Secondary
= S10
Width, diameter,
or second
dimension
333n,
347n, etc
29 K-Secondary
= S11
Depth, thickness,
height, or third
dimension
334n
353n etc
30 K-Secondary
= S07
Logistic Area
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 369 of 448
K-Text = GS1 AI ID Table for ISO/IEC 15961 Format 9
335n
336n etc
31 K-Secondary
= S06
335%x30-
36
Logistic volume
```
337(***) 32 337%x30-36 337%x30-
```
36
Kilograms per
square metre
KG PER m^2 6n
390n or
391n
33 390%x30-39
/ 391%x30-
39
390%x30-
39 /
391%x30-
39
Amount payable -
single monetary
area or with ISO
currency code
AMOUNT 1*15n / 4*18n
392n or
393n
34 392%x30-39
/ 393%x30-
39
392%x30-
39 /
393%x30-
39
Amount payable
for Variable
Measure Trade
Item - single
monetary unit or
ISO cc
PRICE 1*15n / 4*18n
400 35 400 400 Customer's
purchase order
number
ORDER NUMBER 1*30an
401 36 401 401 Global
Identification
Number for
Consignment
GINC 1*30an
402 37 402 402 Global Shipment
Identification
Number
GSIN 17n
403 38 403 403 Routing code ROUTE 1*30an
410 39 410 410 Ship to - Deliver
to Global Location
Number
SHIP TO LOC 13n
411 40 411 420 Bill to - Invoice to
Global Location
Number
BILL TO 13n
412 41 412 412 Purchased from
Global Location
Number
PURCHASE FROM 13n
413 42 413 413 Ship for - Deliver
for - Forward to
Global Location
Number
SHIP FOR LOC 13n
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 370 of 448
K-Text = GS1 AI ID Table for ISO/IEC 15961 Format 9
414 and
254
```
43 (414) [254] (414)
```
[254]
Identification of a
physical location
GLN, and optional
Extension
LOC No + GLN
EXTENSION
```
(13n) [1*20an]
```
415 and
8020
```
44 (415) (8020) (415)
```
```
(8020)
```
Global Location
Number of the
Invoicing Party
and Payment Slip
Reference
Number
```
PAY + REF No (13n) (1*25an)
```
420 or
421
```
45 (420/421) (420/421) Ship-to / Deliver-
```
to postal code
```
SHIP TO POST (1*20an / 3n
```
```
1*9an)
```
422 46 422 422 Country of origin
of a trade item
ORIGIN 3n
423 47 423 423 Country of initial
processing
COUNTRY -
INITIAL PROCESS
3*15n
424 48 424 424 Country of
processing
COUNTRY -
INITIAL PROCESS
3n
425 49 425 425 Country of
disassembly
COUNTRY -
DISASSEMBLY
3n
426 50 426 426 Country covering
full process chain
COUNTRY - FULL
PROCESS
3n
7001 51 7001 7001 NATO stock
number
NSN 13n
7002 52 7002 7002 UN/ECE meat
carcasses and
cuts classification
MEAT CUT 1*30an
7003 53 7003 7003 Expiration Date
and Time
EXPIRY
DATE/TIME
10n
7004 54 7004 7004 Active Potency ACTIVE POTENCY 1*4n
703s 55 7030 7030 Approval number
of processor with
ISO country code
PROCESSOR # s 3n 1*27an
703s 56 7031 7031 Approval number
of processor with
ISO country code
PROCESSOR # s 3n 1*27an
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 371 of 448
K-Text = GS1 AI ID Table for ISO/IEC 15961 Format 9
703s 57 7032 7032 Approval number
of processor with
ISO country code
PROCESSOR # s 3n 1*27an
703s 58 7033 7033 Approval number
of processor with
ISO country code
PROCESSOR # s 3n 1*27an
703s 59 7034 7034 Approval number
of processor with
ISO country code
PROCESSOR # s 3n 1*27an
703s 60 7035 7035 Approval number
of processor with
ISO country code
PROCESSOR # s 3n 1*27an
703s 61 7036 7036 Approval number
of processor with
ISO country code
PROCESSOR # s 3n 1*27an
703s 62 7037 7037 Approval number
of processor with
ISO country code
PROCESSOR # s 3n 1*27an
703s 63 7038 7038 Approval number
of processor with
ISO country code
PROCESSOR # s 3n 1*27an
703s 64 7039 7039 Approval number
of processor with
ISO country code
PROCESSOR # s 3n 1*27an
8001 65 8001 8001 Roll products -
width, length,
core diameter,
direction, splices
DIMENSIONS 14n
8002 66 8002 8002 Electronic serial
identifier for
cellular mobile
telephones
CMT No 1*20an
8003 67 8003 8003 Global Returnable
Asset Identifier
GRAI 14n 0*16an
8004 68 8004 8004 Global Individual
Asset Identifier
GIAI 1*30an
8005 69 8005 8005 Price per unit of
measure
PRICE PER UNIT 6n
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 372 of 448
K-Text = GS1 AI ID Table for ISO/IEC 15961 Format 9
8006 70 8006 8006 Identification of
the component of
a trade item
ITIP 18n
8007 71 8007 8007 International
Bank Account
Number
IBAN 1*34an
8008 72 8008 8008 Date and time of
production
PROD TIME 8*12n
8018 73 8018 8018 Global Service
Relation Number -
Recipient
GSRN -
RECIPIENT
18n
8100
8101 etc
74 K-Secondary
= S08
Coupon Codes
90 75 90 90 Information
mutually agreed
between trading
partners
```
(including FACT
```
```
DIs)
```
INTERNAL 1*30an
91 76 91 91 Company internal
information
INTERNAL 1*an
92 77 92 92 Company internal
information
INTERNAL 1*an
93 78 93 93 Company internal
information
INTERNAL 1*an
94 79 94 94 Company internal
information
INTERNAL 1*an
95 80 95 95 Company internal
information
INTERNAL 1*an
96 81 96 96 Company internal
information
INTERNAL 1*an
97 82 97 97 Company internal
information
INTERNAL 1*an
98 83 98 98 Company internal
information
INTERNAL 1*an
99 84 99 99 Company internal
information
INTERNAL 1*an
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 373 of 448
K-Text = GS1 AI ID Table for ISO/IEC 15961 Format 9
nnn 85 K-Secondary
= S12
Additional AIs
K-TableEnd = F9B0
563
```
K-Text = Sec. IDT - Net weight, kilograms or pounds or troy oz (Variable Measure Trade Item)
```
K-TableID = F9S00
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 4
AI or AIs IDvalue OIDs IDstring Name Data Title FormatString
```
310(***) 0 310%x30-35 310%x30-35 Net weight,
```
```
kilograms (Variable
```
Measure Trade
```
Item)
```
NET WEIGHT
```
(kg)
```
6n
```
320(***) 1 320%x30-35 320%x30-35 Net weight, pounds
```
```
(Variable Measure
```
```
Trade Item)
```
NET WEIGHT
```
(lb)
```
6n
```
356(***) 2 356%x30-35 356%x30-35 Net weight, troy
```
```
ounces (Variable
```
Measure Trade
```
Item)
```
NET WEIGHT
```
(tr oz)
```
6n
K-TableEnd = F9S00
564
```
K-Text = Sec. IDT - Length of first dimension (Variable Measure Trade Item)
```
K-TableID = F9S01
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 4
AI or AIs IDvalue OIDs IDstring Name Data Title FormatString
```
311(***) 0 311%x30-35 311%x30-35 Length of first
```
dimension,
```
metres (Variable
```
Measure Trade
```
Item)
```
```
LENGTH (m) 6n
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 374 of 448
```
K-Text = Sec. IDT - Length of first dimension (Variable Measure Trade Item)
```
```
321(***) 1 321%x30-35 321%x30-35 Length or first
```
dimension,
```
inches (Variable
```
Measure Trade
```
Item)
```
```
LENGTH (i) 6n
```
```
322(***) 2 322%x30-35 322%x30-35 Length or first
```
dimension, feet
```
(Variable
```
Measure Trade
```
Item)
```
```
LENGTH (f) 6n
```
```
323(***) 3 323%x30-35 323%x30-35 Length or first
```
dimension,
```
yards (Variable
```
Measure Trade
```
Item)
```
```
LENGTH (y) 6n
```
K-TableEnd = F9S01
565
```
K-Text = Sec. IDT - Width, diameter, or second dimension (Variable Measure Trade Item)
```
K-TableID = F9S02
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 4
AI or AIs IDvalue OIDs IDstring Name Data Title FormatString
```
312(***) 0 312%x30-35 312%x30-35 Width,
```
diameter, or
second
dimension,
```
metres (Variable
```
Measure Trade
```
Item)
```
```
WIDTH (m) 6n
```
```
324(***) 1 324%x30-35 324%x30-35 Width,
```
diameter, or
second
dimension,
```
inches (Variable
```
Measure Trade
```
Item)
```
```
WIDTH (i) 6n
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 375 of 448
```
K-Text = Sec. IDT - Width, diameter, or second dimension (Variable Measure Trade Item)
```
```
325(***) 2 325%x30-35 325%x30-35 Width,
```
diameter, or
second
dimension,
```
(Variable
```
Measure Trade
```
Item)
```
```
WIDTH (f) 6n
```
```
326(***) 3 326%x30-35 326%x30-35 Width,
```
diameter, or
second
dimension,
```
yards (Variable
```
Measure Trade
```
Item)
```
```
WIDTH (y) 6n
```
K-TableEnd = F9S02
566
```
K-Text = Sec. IDT - Depth, thickness, height, or third dimension (Variable Measure Trade Item)
```
K-TableID = F9S03
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 4
AI or AIs IDvalue OIDs IDstring Name Data Title FormatString
```
313(***) 0 313%x30-35 313%x30-35 Depth,
```
thickness,
height, or third
dimension,
```
metres (Variable
```
Measure Trade
```
Item)
```
```
HEIGHT (m) 6n
```
```
327(***) 1 327%x30-35 327%x30-35 Depth,
```
thickness,
height, or third
dimension,
```
inches (Variable
```
Measure Trade
```
Item)
```
```
HEIGHT (i) 6n
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 376 of 448
```
K-Text = Sec. IDT - Depth, thickness, height, or third dimension (Variable Measure Trade Item)
```
```
328(***) 2 328%x30-35 328%x30-35 Depth,
```
thickness,
height, or third
dimension, feet
```
(Variable
```
Measure Trade
```
Item)
```
```
HEIGHT (f) 6n
```
```
329(***) 3 329%x30-35 329%x30-35 Depth,
```
thickness,
height, or third
dimension,
```
yards (Variable
```
Measure Trade
```
Item)
```
```
HEIGHT (y) 6n
```
K-TableEnd = F9S03
567
```
K-Text = Sec. IDT - Area (Variable Measure Trade Item)
```
K-TableID = F9S04
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 4
AI or AIs IDvalue OIDs IDstring Name Data Title FormatString
```
314(***) 0 314%x30-35 314%x30-35 Area, square
```
```
metres (Variable
```
Measure Trade
```
Item)
```
```
AREA (m^2) 6n
```
```
350(***) 1 350%x30-35 350%x30-35 Area, square
```
```
inches (Variable
```
Measure Trade
```
Item)
```
```
AREA (i^2) 6n
```
```
351(***) 2 351%x30-35 351%x30-35 Area, square
```
```
feet (Variable
```
Measure Trade
```
Item)
```
```
AREA (f2) 6n
```
```
352(***) 3 352%x30-35 352%x30-35 Area, square
```
```
yards (Variable
```
Measure Trade
```
Item)
```
```
AREA (y2) 6n
```
K-TableEnd = F9S04
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 377 of 448
568
```
K-Text = Sec. IDT - Net volume (Variable Measure Trade Item)
```
K-TableID = F9S05
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 8
AI or AIs IDvalue OIDs IDstring Name Data Title FormatString
```
315(***) 0 315%x30-35 315%x30-35 Net volume,
```
```
litres (Variable
```
Measure Trade
```
Item)
```
NET VOLUME
```
(l)
```
6n
```
316(***) 1 316%x30-35 316%x30-35 Net volume,
```
cubic metres
```
(Variable
```
Measure Trade
```
Item)
```
NET VOLUME
```
(m3)
```
6n
```
357(***) 2 357%x30-35 357%x30-35 Net weight (or
```
```
volume), ounces
```
```
(Variable
```
Measure Trade
```
Item)
```
NET VOLUME
```
(oz)
```
6n
```
360(***) 3 360%x30-35 360%x30-35 Net volume,
```
```
quarts (Variable
```
Measure Trade
```
Item)
```
NET VOLUME
```
(qt (US))
```
6n
```
361(***) 4 361%x30-35 361%x30-35 Net volume,
```
gallons U.S.
```
(Variable
```
Measure Trade
```
Item)
```
NET VOLUME
```
(gal (US))
```
6n
```
364(***) 5 364%x30-35 364%x30-35 Net volume,
```
cubic inches
VOLUME
```
(i^3), log
```
6n
```
365(***) 6 365%x30-35 365%x30-35 Net volume,
```
cubic feet
```
(Variable
```
Measure Trade
```
Item)
```
VOLUME
```
(f3), log
```
6n
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 378 of 448
```
K-Text = Sec. IDT - Net volume (Variable Measure Trade Item)
```
```
366(***) 7 366%x30-35 366%x30-35 Net volume,
```
cubic yards
```
(Variable
```
Measure Trade
```
Item)
```
VOLUME
```
(y3), log
```
6n
K-TableEnd = F9S05
569
K-Text = Sec. IDT - Logistic Volume
K-TableID = F9S06
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 8
AI or AIs IDvalue OIDs IDstring Name Data Title FormatString
```
335(***) 0 335%x30-35 335%x30-35 Logistic volume,
```
litres
```
VOLUME (l),
```
log
6n
```
336(***) 1 336%x30-35 336%x30-35 Logistic volume,
```
cubic meters
VOLUME
```
(m^3), log
```
6n
```
362(***) 2 362%x30-35 362%x30-35 Logistic volume,
```
quarts
```
VOLUME (qt
```
```
(US)), log
```
6n
```
363(***) 3 363%x30-35 363%x30-35 Logistic volume,
```
gallons
```
VOLUME (gal
```
```
(US)), log
```
6n
```
367(***) 4 367%x30-35 367%x30-35 Logistic volume,
```
cubic inches
```
VOLUME (q),
```
log
6n
```
368(***) 5 368%x30-35 368%x30-35 Logistic volume,
```
cubic feet
```
VOLUME (g),
```
log
6n
```
369(***) 6 369%x30-35 369%x30-35 Logistic volume,
```
cubic yards
VOLUME
```
(i^3), log
```
6n
K-TableEnd = F9S06
570
K-Text = Sec. IDT - Logistic Area
K-TableID = F9S07
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 4
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 379 of 448
K-Text = Sec. IDT - Logistic Area
AI or AIs IDvalue OIDs IDstring Name Data Title FormatString
```
334(***) 0 334%x30-35 334%x30-35 Area, square
```
metres
AREA
```
(m^2), log
```
6n
```
353(***) 1 353%x30-35 353%x30-35 Area, square
```
inches
```
AREA (i^2),
```
log
6n
```
354(***) 2 354%x30-35 354%x30-35 Area, square
```
feet
```
AREA (f^2),
```
log
6n
```
355(***) 3 355%x30-35 355%x30-35 Area, square
```
yards
```
AREA (y^2),
```
log
6n
K-TableEnd = F9S07
571
K-Text = Sec. IDT - Coupon Codes
K-TableID = F9S08
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 8
AI or
AIs
IDvalu
e
OIDs IDstring Name Data Title FormatString
8100 0 8100 8100 GS1-128 Coupon
Extended Code -
NSC + Offer Code
** DEPRECATED
as of GS15i2 **
- 6n
8101 1 8101 8101 GS1-128 Coupon
Extended Code -
NSC + Offer Code +
end of offer code
** DEPRECATED
as of GS15i2 **
- 10n
8102 2 8102 8102 GS1-128 Coupon
Extended Code -
NSC
** DEPRECATED
as of GS15i2 **
- 2n
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 380 of 448
K-Text = Sec. IDT - Coupon Codes
8110 3 8110 8110 Coupon Code
Identification for Use
in North America
1*70an
8111 4 8111 8111 Loyalty points of a
coupon
POINTS 4n
K-TableEnd = F9S08
572
K-Text = Sec. IDT - Length or first dimension
K-TableID = F9S09
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 4
AI or AIs IDvalu
e
OIDs IDstring Name Data Title FormatString
```
331(***) 0 331%x30-
```
35
331%x30-
35
Length or first
dimension,
metres
LENGTH
```
(m), log
```
6n
```
341(***) 1 341%x30-
```
35
341%x30-
35
Length or first
dimension,
inches
```
LENGTH (i),
```
log
6n
```
342(***) 2 342%x30-
```
35
342%x30-
35
Length or first
dimension,
feet
```
LENGTH (f),
```
log
6n
```
343(***) 3 343%x30-
```
35
343%x30-
35
Length or first
dimension,
yards
LENGTH
```
(y), log
```
6n
K-TableEnd = F9S09
573
K-Text = Sec. IDT - Width, diameter, or second dimension
K-TableID = F9S10
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 4
AI or AIs IDvalu
e
OIDs IDstring Name Data Title FormatString
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 381 of 448
K-Text = Sec. IDT - Width, diameter, or second dimension
```
332(***) 0 332%x30-
```
35
332%x30-
35
Width,
diameter, or
second
dimension,
metres
```
WIDTH (m),
```
log
6n
```
344(***) 1 344%x30-
```
35
344%x30-
35
Width,
diameter, or
second
dimension
```
WIDTH (i),
```
log
6n
```
345(***) 2 345%x30-
```
35
345%x30-
35
Width,
diameter, or
second
dimension
```
WIDTH (f),
```
log
6n
```
346(***) 3 346%x30-
```
35
346%x30-
35
Width,
diameter, or
second
dimension
```
WIDTH (y),
```
log
6n
K-TableEnd = F9S10
574
K-Text = Sec. IDT - Depth, thickness, height, or third dimension
K-TableID = F9S11
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 4
AI or AIs IDvalu
e
OIDs IDstring Name Data Title FormatString
```
333(***) 0 333%x30-
```
35
333%x30-
35
Depth,
thickness,
height, or third
dimension,
metres
HEIGHT
```
(m), log
```
6n
```
347(***) 1 347%x30-
```
35
347%x30-
35
Depth,
thickness,
height, or third
dimension
```
HEIGHT (i),
```
log
6n
```
348(***) 2 348%x30-
```
35
348%x30-
35
Depth,
thickness,
height, or third
dimension
```
HEIGHT (f),
```
log
6n
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 382 of 448
K-Text = Sec. IDT - Depth, thickness, height, or third dimension
```
349(***) 3 349%x30-
```
35
349%x30-
35
Depth,
thickness,
height, or third
dimension
```
HEIGHT (y),
```
log
6n
K-TableEnd = F9S11
575
K-Text = Sec. IDT - Additional AIs
K-TableID = F9S12
K-RootOID = urn:oid:1.0.15961.9
K-IDsize = 128
AI or AIs IDvalue OIDs IDstring Name Data Title FormatString
243 0 243 243 Packaging
Component
Number
PCN 1*20an
255 1 255 255 Global Coupon
Number
GCN 13n 0*12n
427 2 427 427 Country
Subdivision of
Origin Code for a
Trade Item
ORIGIN
SUBDIVISIO
N
1*3an
710 3 710 710 National
Healthcare
Reimbursement
Number -
```
Germany (PZN)
```
NHRN PZN 3n 1*27an
711 4 711 711 National
Healthcare
Reimbursement
Number - France
```
(CIP)
```
NHRN CIP 3n 1*27an
712 5 712 712 National
Healthcare
Reimbursement
Number - Spain
```
(CN)
```
NHRN CN 3n 1*27an
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 383 of 448
K-Text = Sec. IDT - Additional AIs
713 6 713 713 National
Healthcare
Reimbursement
Number - Brazil
```
(DRN)
```
NHRN DRN 3n 1*27an
8010 7 8010 8010 Component / Part
Identifier
CPID 1*30an
8011 8 8011 8011 Component / Part
Identifier Serial
Number
CPID Serial 1*12n
8017 9 8017 8017 Global Service
Relation Number
- Provider
GSRN -
PROVIDER
18n
8019 10 8019 8019 Service Relation
Instance Number
SRIN 1*10n
8200 11 8200 8200 Extended
Packaging URL
PRODUCT
URL
1*70an
16 12 16 16 Sell by date
```
(YYMMDD)
```
SELL BY 6n
394n 13 394%x30-
33
394%x30-
33
Percentage
discount of a
coupon
PCT OFF 4n
7005 14 7005 7005 Catch area CATCH
AREA
1*12an
7006 15 7006 7006 First freeze date FIRST
FREEZE
DATE
6n
7007 16 7007 7007 Harvest date HARVEST
DATE
6*12an
7008 17 7008 7008 Species for
fishery purposes
ACQUATIC
SPECIES
1*3an
7009 18 7009 7009 Fishing gear type FISHING
GEAR TYPE
1*10an
7010 19 7010 7010 Production
method
PROD
METHOD
1*2an
8012 20 8012 8012 Software version VERSION 1*20an
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 384 of 448
K-Text = Sec. IDT - Additional AIs
416 21 416 416 GLN of the
production or
service location
PROD/SERV
/LOC
13n
7020 22 7020 7020 Refurbishment lot
ID
REFURB LOT 1*20an
7021 23 7021 7021 Functional status FUNC STAT 1*20an
7022 24 7022 7022 Revision status REV STAT 1*20an
7023 25 7023 7023 Global Individual
Asset Identifier
```
(GIAI) of an
```
assembly
GIAI -
ASSEMBLY
1*30an
235 26 235 235 Third party
controlled,
serialised
extension of
GTIN
TPX 1*28an
417 27 417 417 Global Location
Number of Party
PARTY 13n
714 28 714 714 National
Healthcare
Reimbursement
Number -
```
Portugal (AIM)
```
NHRN AIM 1*an20
7040 29 7040 7040 Unique
Identification
Code with
```
Extensions (per
```
```
EU 2018/574)
```
UIC 1n 1*3an
8013 30 8013 8013 Global Model
Number
GMN 1*an30
8026 31 8026 8026 Identification of
pieces of a trade
```
item (ITIP)
```
contained in a
logistics unit
ITIP
CONTENT
18n
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 385 of 448
K-Text = Sec. IDT - Additional AIs
8112 32 8112 8112 Paperless coupon
code
identification for
use in North
America
1*an70
7240 33 7240 7240 Protocol ID PROTOCOL 1*20an
```
395(***) 34 395%x30-
```
35
395%x30-
35
Amount Payable
per unit of
measure single
monetary area
```
(variable
```
measure trade
```
item)
```
PRICE/UoM 6n
4300 35 4300 4300 Ship-to / Deliver-
to company
name
SHIP TO
COMP
1*35an
4301 36 4301 4301 Ship-to / Deliver-
to contact name:
AI
SHIP TO
NAME
1*35an
4302 37 4302 4302 Ship-to / Deliver-
to address line 1:
AI
SHIP TO
ADD1
1*70an
4303 38 4303 4303 Ship-to / Deliver-
to address line 2:
AI
SHIP TO
ADD2
1*70an
4304 39 4304 4304 Ship-to / Deliver-
to suburb
SHIP TO
SUB
1*70an
4305 40 4305 4305 Ship-to / Deliver-
to locality
SHIP TO
LOC
1*70an
4306 41 4306 4306 Ship-to / Deliver-
to region
SHIP TO
REG
1*70an
4307 42 4307 4307 Ship-to / Deliver-
to country code
SHIP TO
COUNTRY
2an
4308 43 4308 4308 Ship-to / Deliver-
to telephone
number
SHIP TO
PHONE
1*30an
4309 44 4309 4309 Ship-to / Deliver-
to GEO location
SHIP TO
GEO
20n
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 386 of 448
K-Text = Sec. IDT - Additional AIs
4310 45 4310 4310 Return-to
company name
RTN TO
COMP
1*35an
4311 46 4311 4311 Return-to contact
name
RTN TO
NAME
1*35an
4312 47 4312 4312 Return-to
address line 1
RTN TO
ADD1
1*70an
4313 48 4313 4313 Return-to
address line 2
RTN TO
ADD2
1*70an
4314 49 4314 4314 Return-to suburb RTN TO SUB 1*70an
4315 50 4315 4315 Return-to locality RTN TO LOC 1*70an
4316 51 4316 4316 Return-to region RTN TO REG 1*70an
4317 52 4317 4317 Return-to country
code
RTN TO
COUNTRY
2an
4318 53 4318 4318 Return-to postal
code
RTN TO
POST
1*20an
4319 54 4319 4319 Return-to
telephone
number
RTN TO
PHONE
1*30an
4320 55 4320 4320 Service code
description
SRV
DESCRIPTIO
N
1*35an
4321 56 4321 4321 Dangerous goods
flag
DANGEROU
S GOODS
1n
4322 57 4322 4322 Authority to leave
flag
AUTH LEAV 1n
4323 58 4323 4323 Signature
required flag
SIG
REQUIRED
1n
4324 59 4324 4324 Not before
delivery
date/time
NBEF DEL
DT
10n
4325 60 4325 4325 Not after delivery
date/time
NAFT DEL
DT
10n
4326 61 4326 4326 Release date REL DATE 6n
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 387 of 448
K-Text = Sec. IDT - Additional AIs
715 62 715 715 National
Healthcare
Reimbursement
Number - United
States of America
NDC
NHRN NDC 1*an20
723s 63 7230 7230 Certification
reference
CERT # s 2an 1*28an
723s 64 7231 7231 Certification
reference
CERT # s 2an 1*28an
723s 65 7232 7232 Certification
reference
CERT # s 2an 1*28an
723s 66 7233 7233 Certification
reference
CERT # s 2an 1*28an
723s 67 7234 7234 Certification
reference
CERT # s 2an 1*28an
723s 68 7235 7235 Certification
reference
CERT # s 2an 1*28an
723s 69 7236 7236 Certification
reference
CERT # s 2an 1*28an
723s 70 7237 7237 Certification
reference
CERT # s 2an 1*28an
723s 71 7238 7238 Certification
reference
CERT # s 2an 1*28an
723s 72 7239 7239 Certification
reference
CERT # s 2an 1*28an
7241 73 7241 7241 AIDC media type AIDC MEDIA
TYPE
2n
7242 74 7242 7242 Version Control
```
Number (VCN)
```
VCN 1*25an
8030 75 8030 8030 Digital Signature
```
(DigSig)
```
DIGSIG 1*90an
7011 76 7011 7011 Test by date TEST BY
DATE
6n 0*4n
4330 77 4330 4330 Maximum
temperature in
Fahrenheit
MAX TEMP F 6n 0*1an
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 388 of 448
K-Text = Sec. IDT - Additional AIs
4331 78 4331 4331 Maximum
temperature in
Celsius
MAX TEMP C 6n 0*1an
4332 79 4332 4332 Minimum
temperature in
Fahrenheit
MIN TEMP F 6n 0*1an
4333 80 4333 4333 Minimum
temperature in
Celsius
MIN TEMP F 6n 0*1an
7002 81 7002 7002 UNECE meat
carcasses and
cuts classification
MEAT CUT 1*30an
7041 82 7041 7041 UN/CEFACT
freight unit type
UFRGT UNIT
TYPE
1*an4
716 83 716 716 National
Healthcare
Reimbursement
Number - Italy
AIC
NHRN AIC 1*an20
7250 84 7250 7250 Date of birth DOB 8n
7251 85 7251 7251 Date and time of
birth
DOB TIME 12n
7252 86 7252 7252 Biological sex BIO SEX 1n
7253 87 7253 7253 Family name of
person
FAMILY
NAME
1*an40
7254 88 7254 7254 Given name of
person
GIVEN
NAME
1*an40
7255 89 7255 7255 Name suffix of
person
SUFFIX 1*an10
7256 90 7256 7256 Full name of
person
FULL NAME 1*an90
7257 91 7257 7257 Address of
person
PERSON
ADDR
1*an70
7258 92 7258 7258 Baby birth
sequence
indicator
BIRTH
SEQUENCE
1*an1 1n 1*an1
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 389 of 448
K-Text = Sec. IDT - Additional AIs
7259 93 7259 7259 Baby of family
name
BABY 1*an40
K-TableEnd = F9S12
```
F.2 Comma-Separated-Value (CSV) format576
```
```
This section is the Packed Objects ID Table for Data Format 9 (GS1 Application Identifiers) in machine readable, comma-separated-value577
```
format, as registered with ISO. See Section F.1 for a non-normative listing of the content of the ID Table for Data Format 9, in a human578
readable, tabular format.579
In the comma-separated-value format, line breaks are significant. However, certain lines are too long to fit within the margins of this580
document. In the listing below, the symbol █ at the end of line indicates that the ID Table line is continued on the following line. Such a line581
shall be interpreted by concatenating the following line and omitting the █ symbol.582
Note that, as of TDS 2.1, the Packed Objects ID Table for Data Format 9 in Section F.2 has been supplemented with an external,583
normative artefact in CSV format, which can be found online at https://ref.gs1.org/standards/tds/artefacts.584
585
K-Text = GS1 AI ID Table for ISO/IEC 15961 Format 9,,,,,,586
K-Version = 1.00,,,,,,587
K-ISO15434=05,,,,,,588
K-Text = Primary Base Table,,,,,,589
K-TableID = F9B0,,,,,,590
K-RootOID = urn:oid:1.0.15961.9,,,,,,591
K-IDsize = 90,,,,,,592
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString593
```
0,1,0,0,SSCC (Serial Shipping Container Code),SSCC,18n594
```
1,2,1,1,Global Trade Item Number,GTIN,14n595
```
02 + 37,3,(2)(37),(02)(37),GTIN + Count of trade items contained in a logistic█ unit,CONTENT + COUNT,(14n)(1*8n)596
```
10,4,10,10,Batch or lot number,BATCH/LOT,1*20an597
```
11,5,11,11,Production date (YYMMDD),PROD DATE,6n598
```
```
12,6,12,12,Due date (YYMMDD),DUE DATE,6n599
```
```
13,7,13,13,Packaging date (YYMMDD),PACK DATE,6n600
```
```
15,8,15,15,Best before date (YYMMDD),BEST BEFORE OR SELL BY,6n601
```
```
17,9,17,17,Expiration date (YYMMDD),USE BY OR EXPIRY,6n602
```
20,10,20,20,Internal product variant,VARIANT,2n603
21,11,21,21,Serial number,SERIAL,1*20an604
22,12,22,22,Consumer product variant,CPV,1*20an605
240,13,240,240,Additional product identification assigned by the manufacturer,ADDITIONAL ID,1*30an606
241,14,241,241,Customer part number,CUST. PART NO.,1*30an607
242,15,242,242,Made-to-Order Variation Number,VARIATION NUMBER,1*6n608
250,16,250,250,Secondary serial number,SECONDARY SERIAL,1*30an609
251,17,251,251,Reference to source entity,REF. TO SOURCE,1*30an610
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 390 of 448
253,18,253,253,Global Document Type Identifier,DOC. ID,13n 0*17an611
30,19,30,30,Variable count,VAR. COUNT,1*8n612
```
310n 320n etc,20,K-Secondary = S00,,"Net weight, kilograms or pounds or troy oz█ (Variable Measure Trade Item)",,613
```
```
311n 321n etc,21,K-Secondary = S01,,Length of first dimension (Variable Measure█ Trade Item),,614
```
```
312n 324n etc,22,K-Secondary = S02,,"Width, diameter, or second dimension (Variable█ Measure Trade Item)",,615
```
```
313n 327n etc,23,K-Secondary = S03,,"Depth, thickness, height, or third dimension█ (Variable Measure Trade Item)",,616
```
```
314n 350n etc,24,K-Secondary = S04,,Area (Variable Measure Trade Item),,617
```
```
315n 316n etc,25,K-Secondary = S05,,Net volume (Variable Measure Trade Item),,618
```
330n or 340n,26,330%x30-36 / 340%x30-36,330%x30-36 / 340%x30-36,"Logistic weight, █ kilograms or pounds",GROSS WEIGHT619
```
(kg) or (lb),6n / 6n620
```
"331n, 341n, etc",27,K-Secondary = S09,,Length or first dimension,,621
"332n, 344n, etc",28,K-Secondary = S10,,"Width, diameter, or second dimension",,622
"333n, 347n, etc",29,K-Secondary = S11,,"Depth, thickness, height, or third█ dimension",,623
334n 353n etc,30,K-Secondary = S07,,Logistic Area,,624
335n 336n etc,31,K-Secondary = S06,335%x30-36,Logistic volume,,625
```
337(***),32,337%x30-36,337%x30-36,Kilograms per square metre,KG PER m^2,6n626
```
390n or 391n,33,390%x30-39 / 391%x30-39,390%x30-39 / 391%x30-39,Amount payable -█ single monetary area or with ISO627
currency code,AMOUNT,1*15n / 4*18n628
392n or 393n,34,392%x30-39 / 393%x30-39,392%x30-39 / 393%x30-39,Amount payable for█ Variable Measure Trade Item -629
single monetary unit or ISO cc, PRICE,1*15n / 4*18n630
400,35,400,400,Customer's purchase order number,ORDER NUMBER,1*30an631
401,36,401,401,Global Identification Number for Consignment,GINC,1*30an632
402,37,402,402,Global Shipment Identification Number,GSIN,17n633
403,38,403,403,Routing code,ROUTE,1*30an634
410,39,410,410,Ship to - Deliver to Global Location Number,SHIP TO LOC,13n635
411,40,411,411,Bill to - Invoice to Global Location Number,BILL TO,13n636
412,41,412,412,Purchased from Global Location Number,PURCHASE FROM,13n637
413,42,413,413,Ship for - Deliver for - Forward to Global Location Number,SHIP FOR█ LOC,13n638
```
414 and 254,43,(414) [254],(414) [254],"Identification of a physical location GLN, █ and optional Extension",LOC No +639
```
```
GLN EXTENSION,(13n) [1*20an]640
```
```
415 and 8020,44,(415) (8020),(415) (8020),Global Location Number of the Invoicing█ Party and Payment Slip Reference641
```
```
Number,PAY + REF No,(13n) (1*25an)642
```
```
420 or 421,45,(420/421),(420/421),Ship-to / Deliver-to postal code,SHIP TO█ POST,(1*20an / 3n 1*9an)643
```
422,46,422,422,Country of origin of a trade item,ORIGIN,3n644
423,47,423,423,Country of initial processing,COUNTRY - INITIAL PROCESS.,3*15n645
424,48,424,424,Country of processing,COUNTRY - PROCESS.,3n646
425,49,425,425,Country of disassembly,COUNTRY - DISASSEMBLY,3n647
426,50,426,426,Country covering full process chain,COUNTRY - FULL PROCESS,3n648
7001,51,7001,7001,NATO stock number,NSN,13n649
7002,52,7002,7002,UN/ECE meat carcasses and cuts classification,MEAT CUT,1*30an650
7003,53,7003,7003,Expiration Date and Time,EXPIRY DATE/TIME,10n651
7004,54,7004,7004,Active Potency,ACTIVE POTENCY,1*4n652
703s,55,7030,7030,Approval number of processor with ISO country code,PROCESSOR #█ s,3n 1*27an653
703s,56,7031,7031,Approval number of processor with ISO country code,PROCESSOR #█ s,3n 1*27an654
703s,57,7032,7032,Approval number of processor with ISO country code,PROCESSOR #█ s,3n 1*27an655
703s,58,7033,7033,Approval number of processor with ISO country code,PROCESSOR #█ s,3n 1*27an656
703s,59,7034,7034,Approval number of processor with ISO country code,PROCESSOR #█ s,3n 1*27an657
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 391 of 448
703s,60,7035,7035,Approval number of processor with ISO country code,PROCESSOR #█ s,3n 1*27an658
703s,61,7036,7036,Approval number of processor with ISO country code,PROCESSOR #█ s,3n 1*27an659
703s,62,7037,7037,Approval number of processor with ISO country code,PROCESSOR #█ s,3n 1*27an660
703s,63,7038,7038,Approval number of processor with ISO country code,PROCESSOR #█ s,3n 1*27an661
703s,64,7039,7039,Approval number of processor with ISO country code,PROCESSOR #█ s,3n 1*27an662
8001,65,8001,8001,"Roll products - width, length, core diameter, direction, █ splices",DIMENSIONS,14n663
8002,66,8002,8002,Electronic serial identifier for cellular mobile telephones,CMT█ No,1*20an664
8003,67,8003,8003,Global Returnable Asset Identifier,GRAI,14n 0*16an665
8004,68,8004,8004,Global Individual Asset Identifier,GIAI,1*30an666
8005,69,8005,8005,Price per unit of measure,PRICE PER UNIT,6n667
8006,70,8006,8006,Identification of the component of a trade item,GCTIN,18n668
8007,71,8007,8007,International Bank Account Number,IBAN,1*30an669
8008,72,8008,8008,Date and time of production,PROD TIME,8*12n670
8018,73,8018,8018,Global Service Relation Number - Recipient,GSRN - RECIPIENT,18n671
8100 8101 etc,74,K-Secondary = S08,,Coupon Codes,,672
```
90,75,90,90,Information mutually agreed between trading partners (including FACT█ DIs),INTERNAL,1*30an673
```
91,76,91,91,Company internal information,INTERNAL,1*an674
92,77,92,92,Company internal information,INTERNAL,1*an675
93,78,93,93,Company internal information,INTERNAL,1*an676
94,79,94,94,Company internal information,INTERNAL,1*an677
95,80,95,95,Company internal information,INTERNAL,1*an678
96,81,96,96,Company internal information,INTERNAL,1*an679
97,82,97,97,Company internal information,INTERNAL,1*an680
98,83,98,98,Company internal information,INTERNAL,1*an681
99,84,99,99,Company internal information,INTERNAL,1*an682
nnn,85,K-Secondary = S12,,Additional AIs,,683
K-TableEnd = F9B0,,,,,,684
685
```
"K-Text = Sec. IDT - Net weight, kilograms or pounds or troy oz (Variable Measure█ Trade Item)",,,,,,686
```
K-TableID = F9S00,,,,,,687
K-RootOID = urn:oid:1.0.15961.9,,,,,,688
K-IDsize = 4,,,,,,689
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString690
```
310(***),0,310%x30-35,310%x30-35,"Net weight, kilograms (Variable Measure Trade█ Item)",NET WEIGHT (kg),6n691
```
```
320(***),1,320%x30-35,320%x30-35,"Net weight, pounds (Variable Measure Trade█ Item)",NET WEIGHT (lb),6n692
```
```
356(***),2,356%x30-35,356%x30-35,"Net weight, troy ounces (Variable Measure Trade█ Item)",NET WEIGHT (tr oz),6n693
```
K-TableEnd = F9S00,,,,,,694
695
```
K-Text = Sec. IDT - Length of first dimension (Variable Measure Trade Item),,,,,,696
```
K-TableID = F9S01,,,,,,697
K-RootOID = urn:oid:1.0.15961.9,,,,,,698
K-IDsize = 4,,,,,,699
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString700
```
311(***),0,311%x30-35,311%x30-35,"Length of first dimension, metres (Variable█ Measure Trade Item)",LENGTH (m),6n701
```
```
321(***),1,321%x30-35,321%x30-35,"Length or first dimension, inches (Variable█ Measure Trade Item)",LENGTH (i),6n702
```
```
322(***),2,322%x30-35,322%x30-35,"Length or first dimension, feet (Variable Measure█ Trade Item)",LENGTH (f),6n703
```
```
323(***),3,323%x30-35,323%x30-35,"Length or first dimension, yards (Variable█ Measure Trade Item)",LENGTH (y),6n704
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 392 of 448
K-TableEnd = F9S01,,,,,,705
706
```
"K-Text = Sec. IDT - Width, diameter, or second dimension (Variable Measure Trade█ Item)",,,,,,707
```
K-TableID = F9S02,,,,,,708
K-RootOID = urn:oid:1.0.15961.9,,,,,,709
K-IDsize = 4,,,,,,710
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString711
```
312(***),0,312%x30-35,312%x30-35,"Width, diameter, or second dimension, metres█ (Variable Measure Trade Item)",WIDTH712
```
```
(m),6n713
```
```
324(***),1,324%x30-35,324%x30-35,"Width, diameter, or second dimension, inches█ (Variable Measure Trade Item)",WIDTH714
```
```
(i),6n715
```
```
325(***),2,325%x30-35,325%x30-35,"Width, diameter, or second dimension, (Variable█ Measure Trade Item)",WIDTH (f),6n716
```
```
326(***),3,326%x30-35,326%x30-35,"Width, diameter, or second dimension, yards█ (Variable Measure Trade Item)",WIDTH717
```
```
(y),6n718
```
K-TableEnd = F9S02,,,,,,719
720
```
"K-Text = Sec. IDT - Depth, thickness, height, or third dimension (Variable Measure█ Trade Item)",,,,,,721
```
K-TableID = F9S03,,,,,,722
K-RootOID = urn:oid:1.0.15961.9,,,,,,723
K-IDsize = 4,,,,,,724
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString725
```
313(***),0,313%x30-35,313%x30-35,"Depth, thickness, height, or third dimension, █ metres (Variable Measure Trade726
```
```
Item)",HEIGHT (m),6n727
```
```
327(***),1,327%x30-35,327%x30-35,"Depth, thickness, height, or third dimension, █ inches (Variable Measure Trade728
```
```
Item)",HEIGHT (i),6n729
```
```
328(***),2,328%x30-35,328%x30-35,"Depth, thickness, height, or third dimension, █ feet (Variable Measure Trade730
```
```
Item)",HEIGHT (f),6n731
```
```
329(***),3,329%x30-35,329%x30-35,"Depth, thickness, height, or third dimension, █ yards (Variable Measure Trade732
```
```
Item)",HEIGHT (y),6n733
```
K-TableEnd = F9S03,,,,,,734
735
```
K-Text = Sec. IDT - Area (Variable Measure Trade Item),,,,,,736
```
K-TableID = F9S04,,,,,,737
K-RootOID = urn:oid:1.0.15961.9,,,,,,738
K-IDsize = 4,,,,,,739
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString740
```
314(***),0,314%x30-35,314%x30-35,"Area, square metres (Variable Measure Trade█ Item)",AREA (m^2),6n741
```
```
350(***),1,350%x30-35,350%x30-35,"Area, square inches (Variable Measure Trade█ Item)",AREA (i^2),6n742
```
```
351(***),2,351%x30-35,351%x30-35,"Area, square feet (Variable Measure Trade█ Item)",AREA (f^2),6n743
```
```
352(***),3,352%x30-35,352%x30-35,"Area, square yards (Variable Measure Trade█ Item)",AREA (y^2),6n744
```
K-TableEnd = F9S04,,,,,,745
746
```
K-Text = Sec. IDT - Net volume (Variable Measure Trade Item),,,,,,747
```
K-TableID = F9S05,,,,,,748
K-RootOID = urn:oid:1.0.15961.9,,,,,,749
K-IDsize = 8,,,,,,750
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString751
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 393 of 448
```
315(***),0,315%x30-35,315%x30-35,"Net volume, litres (Variable Measure Trade█ Item)",NET VOLUME (l),6n752
```
```
316(***),1,316%x30-35,316%x30-35,"Net volume, cubic metres (Variable Measure Trade█ Item)",NET VOLUME (m^3),6n753
```
```
357(***),2,357%x30-35,357%x30-35,"Net weight (or volume), ounces (Variable Measure█ Trade Item)",NET VOLUME (oz),6n754
```
```
360(***),3,360%x30-35,360%x30-35,"Net volume, quarts (Variable Measure Trade█ Item)",NET VOLUME (qt (US)),6n755
```
```
361(***),4,361%x30-35,361%x30-35,"Net volume, gallons U.S. (Variable Measure Trade█ Item)",NET VOLUME (gal (US)),6n756
```
```
364(***),5,364%x30-35,364%x30-35,"Net volume, cubic inches","VOLUME (i^3), log",6n757
```
```
365(***),6,365%x30-35,365%x30-35,"Net volume, cubic feet (Variable Measure Trade█ Item)","VOLUME (f^3), log",6n758
```
```
366(***),7,366%x30-35,366%x30-35,"Net volume, cubic yards (Variable Measure Trade█ Item)","VOLUME (y^3), log",6n759
```
K-TableEnd = F9S05,,,,,,760
761
K-Text = Sec. IDT - Logistic Volume,,,,,,762
K-TableID = F9S06,,,,,,763
K-RootOID = urn:oid:1.0.15961.9,,,,,,764
K-IDsize = 8,,,,,,765
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString766
```
335(***),0,335%x30-35,335%x30-35,"Logistic volume, litres","VOLUME (l), log",6n767
```
```
336(***),1,336%x30-35,336%x30-35,"Logistic volume, cubic meters","VOLUME (m^3), █ log",6n768
```
```
362(***),2,362%x30-35,362%x30-35,"Logistic volume, quarts","VOLUME (qt (US)), log",6n769
```
```
363(***),3,363%x30-35,363%x30-35,"Logistic volume, gallons","VOLUME (gal (US)), log",6n770
```
```
367(***),4,367%x30-35,367%x30-35,"Logistic volume, cubic inches","VOLUME (q), █ log",6n771
```
```
368(***),5,368%x30-35,368%x30-35,"Logistic volume, cubic feet","VOLUME (g), log",6n772
```
```
369(***),6,369%x30-35,369%x30-35,"Logistic volume, cubic yards","VOLUME (i^3), █ log",6n773
```
K-TableEnd = F9S06,,,,,,774
775
K-Text = Sec. IDT - Logistic Area,,,,,,776
K-TableID = F9S07,,,,,,777
K-RootOID = urn:oid:1.0.15961.9,,,,,,778
K-IDsize = 4,,,,,,779
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString780
```
334(***),0,334%x30-35,334%x30-35,"Area, square metres","AREA (m^2), log",6n781
```
```
353(***),1,353%x30-35,353%x30-35,"Area, square inches","AREA (i^2), log",6n782
```
```
354(***),2,354%x30-35,354%x30-35,"Area, square feet","AREA (f^2), log",6n783
```
```
355(***),3,355%x30-35,355%x30-35,"Area, square yards","AREA (y^2), log",6n784
```
K-TableEnd = F9S07,,,,,,785
786
K-Text = Sec. IDT - Coupon Codes,,,,,,787
K-TableID = F9S08,,,,,,788
K-RootOID = urn:oid:1.0.15961.9,,,,,,789
K-IDsize = 8,,,,,,790
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString791
8100,0,8100,8100,GS1-128 Coupon Extended Code - NSC + Offer Code ** DEPRECATED as of GS1GS15i2 **,-,6n792
8101,1,8101,8101,GS1-128 Coupon Extended Code - NSC + Offer Code + end of offer█ code ** DEPRECATED as of GS1GS15i2793
**,-,10n794
8102,2,8102,8102,GS1-128 Coupon Extended Code - NSC ** DEPRECATED as of GS1GS15i2 **,-,2n795
8110,3,8110,8110,Coupon Code Identification for Use in North America,,1*70an796
8111,22,8111,8111,Loyalty points of a coupon,POINTS,4n797
K-TableEnd = F9S08,,,,,,798
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 394 of 448
799
K-Text = Sec. IDT - Length or first dimension,,,,,,800
K-TableID = F9S09,,,,,,801
K-RootOID = urn:oid:1.0.15961.9,,,,,,802
K-IDsize = 4,,,,,,803
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString804
```
331(***),0,331%x30-35,331%x30-35,"Length or first dimension, metres","LENGTH (m), █ log",6n805
```
```
341(***),1,341%x30-35,341%x30-35,"Length or first dimension, inches","LENGTH (i), █ log",6n806
```
```
342(***),2,342%x30-35,342%x30-35,"Length or first dimension, feet","LENGTH (f), █ log",6n807
```
```
343(***),3,343%x30-35,343%x30-35,"Length or first dimension, yards","LENGTH (y), █ log",6n808
```
K-TableEnd = F9S09,,,,,,809
810
"K-Text = Sec. IDT - Width, diameter, or second dimension",,,,,,811
K-TableID = F9S10,,,,,,812
K-RootOID = urn:oid:1.0.15961.9,,,,,,813
K-IDsize = 4,,,,,,814
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString815
```
332(***),0,332%x30-35,332%x30-35,"Width, diameter, or second dimension, █ metres","WIDTH (m), log",6n816
```
```
344(***),1,344%x30-35,344%x30-35,"Width, diameter, or second dimension","WIDTH █ (i), log",6n817
```
```
345(***),2,345%x30-35,345%x30-35,"Width, diameter, or second dimension","WIDTH █ (f), log",6n818
```
```
346(***),3,346%x30-35,346%x30-35,"Width, diameter, or second dimension","WIDTH █ (y), log",6n819
```
K-TableEnd = F9S10,,,,,,820
821
"K-Text = Sec. IDT - Depth, thickness, height, or third dimension",,,,,,822
K-TableID = F9S11,,,,,,823
K-RootOID = urn:oid:1.0.15961.9,,,,,,824
K-IDsize = 4,,,,,,825
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString826
```
333(***),0,333%x30-35,333%x30-35,"Depth, thickness, height, or third dimension, █ metres","HEIGHT (m), log",6n827
```
```
347(***),1,347%x30-35,347%x30-35,"Depth, thickness, height, or third█ dimension","HEIGHT (i), log",6n828
```
```
348(***),2,348%x30-35,348%x30-35,"Depth, thickness, height, or third█ dimension","HEIGHT (f), log",6n829
```
```
349(***),3,349%x30-35,349%x30-35,"Depth, thickness, height, or third█ dimension","HEIGHT (y), log",6n830
```
K-TableEnd = F9S11,,,,,,831
832
K-Text = Sec. IDT - Additional AIs,,,,,,833
K-TableID = F9S12,,,,,834
K-RootOID = urn:oid:1.0.15961.9,,,,,,835
K-IDsize = 128,,,,,,836
AI or AIs,IDvalue,OIDs,IDstring,Name,Data Title,FormatString837
243,0,243,243,Packaging Component Number,PCN,1*20an838
255,1,255,255,Global Coupon Number,GCN,13n 0*12n839
427,2,427,427,Country Subdivision of Origin Code for a Trade Item,ORIGIN█ SUBDIVISION,1*3an840
```
710,3,710,710,National Healthcare Reimbursement Number - Germany (PZN),NHRN PZN,3n█ 1*27an841
```
```
711,4,711,711,National Healthcare Reimbursement Number - France (CIP),NHRN CIP,3n█ 1*27an842
```
```
712,5,712,712,National Healthcare Reimbursement Number - Spain (CN),NHRN CN,3n█ 1*27an843
```
```
713,6,713,713,National Healthcare Reimbursement Number - Brazil (DRN),NHRN DRN,3n█ 1*27an844
```
8010,7,8010,8010,Component / Part Identifier,CPID,1*30an845
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 395 of 448
8011,8,8011,8011,Component / Part Identifier Serial Number,CPID Serial,1*12n846
8017,9,8017,8017,Global Service Relation Number - Provider,GSRN - PROVIDER,18n847
8019,10,8019,8019,Service Relation Instance Number,SRIN,1*10n848
8200,11,8200,8200,Extended Packaging URL,PRODUCT URL,1*70an849
```
16,12,16,16,Sell by date (YYMMDD),SELL BY,6n850
```
394n,13,394%x30-39,394%x30-39,Percentage discount of a coupon,PCT OFF,4n851
7005,14,7005,7005,Catch area,CATCH AREA,1*12an852
7006,15,7006,7006,First freeze date,FIRST FREEZE DATE,6n853
7007,16,7007,7007,Harvest date,HARVEST DATE,6*12an854
7008,17,7008,7008,Species for fishery purposes,ACQUATIC SPECIES,1*3an855
7009,18,7009,7009,Fishing gear type,FISHING GEAR TYPE,1*10an856
7010,19,7010,7010,Production method,PROD METHOD,1*2an857
8012,20,8012,8012,Software version,VERSION,1*20an858
416,21,416,416,GLN of the production or servie location,PROD/SERV/LOC,13n859
7020,22,7020,7020,Refurbishment lot ID,REFURB LOT,1*20an860
7021,23,7021,7021,Functional status,FUNC STAT,1*20an861
7022,24,7022,7022,Revision status,REV STAT,1*20an862
```
7023,25,7023,7023,Global Individual Assset Identifier (GIAI) of an Assembly,GIAI-ASSEMBLY,1*30an863
```
235,26,235,235,"Third party controlled, serialised extension of GTIN",TPX,1*28n864
417,27,417,417,Global Location Number of Party,PGLN,13n865
```
714,28,714,714,National Healthcare Reimbursement Number - Portugal (AIM),NHRH █866
```
AIM,1*an20867
```
7040,29,7040,7040,Unique Identification Code with Extensions (per EU 2018/574),UIC,█868
```
1n 1*3an869
8013,30,8013,8013,Global Model Number,GMN,1*an30870
```
8026,31,8026,8026,Identification of pieces of a trade item (ITIP) contained in a logistics unit,ITIP CONTENT,18n871
```
8112,32,8112,8112,Paperless coupon code identification for use in North█872
America,,1*an70873
7240,33,7240,7240,Protocol ID,PROTOCOL,1*20an874
```
395(***),34,395%x30-35,395%x30-35,Amount Payable per unit of measure single█ monetary area (variable measure trade875
```
```
item),PRICE/UoM,6n876
```
4300,35,4300,4300,Ship-to / Deliver-to company name,SHIP TO COMP,1*35an877
4301,36,4301,4301,Ship-to / Deliver-to contact name,SHIP TO NAME,1*35an878
4302,37,4302,4302,Ship-to / Deliver-to address line 1,SHIP TO ADD1,1*70an879
4303,38,4303,4303,Ship-to / Deliver-to address line 2,SHIP TO ADD2,1*70an880
4304,39,4304,4304,Ship-to / Deliver-to suburb,SHIP TO SUB,1*70an881
4305,40,4305,4305,Ship-to / Deliver-to locality,SHIP TO LOC,1*70an882
4306,41,4306,4306,Ship-to / Deliver-to region,SHIP TO REG,1*70an883
4307,42,4307,4307,Ship-to / Deliver-to country code,SHIP TO COUNTRY,2an884
4308,43,4308,4308,Ship-to / Deliver-to telephone number,SHIP TO PHONE,1*30an885
4309,44,4309,4309,Ship-to / Deliver-to GEO location,SHIP TO GEO,20n886
4310,45,4310,4310,Return-to company name,RTN TO COMP,1*35an887
4311,46,4311,4311,Return-to contact name,RTN TO NAME,1*35an888
4312,47,4312,4312,Return-to address line 1,RTN TO ADD1,1*70an889
4313,48,4313,4313,Return-to address line 2,RTN TO ADD2,1*70an890
4314,49,4314,4314,Return-to suburb,RTN TO SUB,1*70an891
4315,50,4315,4315,Return-to locality,RTN TO LOC,1*70an892
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 396 of 448
4316,51,4316,4316,Return-to region,RTN TO REG,1*70an893
4317,52,4317,4317,Return-to country code,RTN TO COUNTRY,2an894
4318,53,4318,4318,Return-to postal code,RTN TO POST,1*20an895
4319,54,4319,4319,Return-to telephone number,RTN TO PHONE,1*30an896
4320,55,4320,4320,Service code,SRV,1*35an897
4321,56,4321,4321,Dangerous goods flag,DANGEROUS GOODS,1n898
4322,57,4322,4322,Authority to leave flag,AUTH LEAV,1n899
4323,58,4323,4323,Signature required flag,SIG REQUIRED,1n900
4324,59,4324,4324,Not before delivery date/time,NBEF DEL DT,10n901
4325,60,4325,4325,Not after delivery date/time,NAFT DEL DT,10n902
4326,61,4326,4326,Release date,REL DATE,6n903
```
715,62,715,715,National Healthcare Reimbursement Number - United States of America █ (NDC),NHRN NDC,1*an20904
```
723s,63,7230,7230,Certification reference,CERT # s,2an 1*28an905
723s,64,7231,7231,Certification reference,CERT # s,2an 1*28an906
723s,65,7232,7232,Certification reference,CERT # s,2an 1*28an907
723s,66,7233,7233,Certification reference,CERT # s,2an 1*28an908
723s,67,7234,7234,Certification reference,CERT # s,2an 1*28an909
723s,68,7235,7235,Certification reference,CERT # s,2an 1*28an910
723s,69,7236,7236,Certification reference,CERT # s,2an 1*28an911
723s,70,7237,7237,Certification reference,CERT # s,2an 1*28an912
723s,71,7238,7238,Certification reference,CERT # s,2an 1*28an913
723s,72,7239,7239,Certification reference,CERT # s,2an 1*28an914
7241,73,7241,7241,AIDC Media Type,AIDC MEDIA TYPE,2an915
```
7242,74,7242,7242,Version Control Number (VCN),VCN,1*25an916
```
```
8030,75,7239,8030,Digital Signature (DigSig),DIGSIG,1*90an917
```
7011,76,7011,7011,Test by date,TEST BY DATE,6n 0*4n918
4330,77,4330,4330,Maximum temperature in Fahrenheit,MAX TEMP F,6n 0*1an919
4331,78,4331,4331,Maximum temperature in Celsius,MAX TEMP C,6n 0*1an920
4332,79,4332,4332,Minimum temperature in Farenheit,MIN TEMP F,6n 0*1an921
4333,80,4333,4333,Minimum temperature in Celsius,MIN TEMP C,6n 0*1an922
7002,81,7002,7002,UNECE meat carcasses and cuts classification,MEAT CUT,1*30an923
7041,82,7041,7041,UN/CEFACT freight unit type,UFRGT UNIT TYPE,1*an4924
716,83,716,716, National Healthcare Reimbursement Number - Italy AIC,NHRN AIC,1*an20925
7250,84,7250,7250,Date of birth,DOB,8n926
7251,85,7251,7251,Date and time of birth,DOB TIME,12n927
7252,86,7252,7252,Biological sex,BIO SEX,1n928
7253,87,7253,7253,Family name of person,FAMILY NAME,1*an40929
7254,88,7254,7254,Given name of person,GIVEN NAME,1*an40930
7255,89,7255,7255,Name suffix of person,SUFFIX,1*an10931
7256,90,7256,7256,Full name of person,FULL NAME,1*an90932
7257,91,7257,7257,Address of person,PERSON ADDR,1*an70933
7258,92,7258,7258,Baby birth sequence indicator,BIRTH SEQUENCE,1*an1 1n 1*an1934
7259,93,7259,7259,Baby birth of family,BABY,1*an40935
K-TableEnd = F9S12,,,,,,936
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 397 of 448
G 6-Bit Alphanumeric Character Set937
The following table specifies the characters that are used in the Component / Part Reference in CPI EPCs and in the original part number938
and serial number in ADI EPCs. A subset of these characters are also used for the CAGE/DoDAAC code in ADI EPCs. The columns are as939
```
follows:940
```
■ Graphic symbol: The printed representation of the character as used in human-readable forms.941
■ Name: The common name for the character942
■ Binary Value: A Binary numeral that gives the 6-bit binary value for the character as used in EPC binary encodings. This binary value is always943
```
equal to the least significant six bits of the ISO/IEC 646 [ISO646] (ASCII) code for the character.944
```
■ URI Form: The representation of the character within Pure Identity EPC URI and EPC Tag URI forms. This is either a single character whose945
ASCII code’s least significant six bits is equal to the value in the "binary value" column, or an escape triplet consisting of a percent character946
followed by two characters giving the hexadecimal value for the character.947
Table I.3.1-1 Characters Permitted in 6-bit Alphanumeric Fields948
Graphic
symbol
Name Binary
value
URI Form Graphic
symbol
Name Binary
value
URI Form
# Pound/ Number
Sign
100011 %23 H Capital H 001000 H
- Hyphen/ Minus
Sign
101101 - I Capital I 001001 I
/ Forward Slash 101111 %2F J Capital J 001010 J
0 Zero Digit 110000 0 K Capital K 001011 K
1 One Digit 110001 1 L Capital L 001100 L
2 Two Digit 110010 2 M Capital M 001101 M
3 Three Digit 110011 3 N Capital N 001110 N
4 Four Digit 110100 4 O Capital O 001111 O
5 Five Digit 110101 5 P Capital P 010000 P
6 Six Digit 110110 6 Q Capital Q 010001 Q
7 Seven Digit 110111 7 R Capital R 010010 R
8 Eight Digit 111000 8 S Capital S 010011 S
9 Nine Digit 111001 9 T Capital T 010100 T
A Capital A 000001 A U Capital U 010101 U
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 398 of 448
Graphic
symbol
Name Binary
value
URI Form Graphic
symbol
Name Binary
value
URI Form
B Capital B 000010 B V Capital V 010110 V
C Capital C 000011 C W Capital W 010111 W
D Capital D 000100 D X Capital X 011000 X
E Capital E 000101 E Y Capital Y 011001 Y
F Capital F 000110 F Z Capital
Letter Z
011010 Z
G Capital G 000111 G
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 399 of 448
```
H (Intentionally Omitted)949
```
[This annex is omitted so that Annexes I through M, which specify Packed Objects, have the same annex letters as the corresponding950
annexes of ISO/IEC 15962, 2nd Edition.]951
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 400 of 448
I Packed Objects structure952
I.1 Overview953
The Packed Objects format provides for efficient encoding and access of user data. The Packed Objects format offers increased encoding954
efficiency compared to the No-Directory and Directory Access-Methods partly by utilising sophisticated compaction methods, partly by955
```
defining an inherent directory structure at the front of each Packed Object (before any of its data is encoded) that supports random access956
```
```
while reducing the fixed overhead of some prior methods, and partly by utilising data-system-specific information (such as the GS1957
```
```
definitions of fixed-length Application Identifiers).958
```
I.2 Overview of Packed Objects documentation959
The formal description of Packed Objects is presented in this Annex and Annexes J, K, L, and M, as follows:960
■ The overall structure of Packed Objects is described in Section I.3.961
■ The individual sections of a Packed Object are described in Sections I.4 through I.9.962
```
■ The structure and features of ID Tables (utilised by Packed Objects to represent various data system identifiers) are described in Annex J.963
```
■ The numerical bases and character sets used in Packed Objects are described in Annex K.964
■ An encoding algorithm and worked example are described in Annex L.965
■ The decoding algorithm for Packed Objects is described in Annex M.966
In addition, note that all descriptions of specific ID Tables for use with Packed Objects are registered separately, under the procedures of967
ISO/IEC 15961-2 as is the complete formal description of the machine-readable format for registered ID Tables.968
I.3 High-Level Packed Objects format design969
I.3.1 Overview970
The Packed Objects memory format consists of a sequence in memory of one or more "Packed Objects" data structures. Each Packed Object971
may contain either encoded data or directory information, but not both. The first Packed Object in memory is preceded by a DSFID. The972
DSFID indicates use of Packed Objects as the memory’s Access Method, and indicates the registered Data Format that is the default format973
```
for every Packed Object in that memory. Every Packed Object may be optionally preceded or followed by padding patterns (if needed for974
```
```
alignment on word or block boundaries). In addition, at most one Packed Object in memory may optionally be preceded by a pointer to a975
```
```
Directory Packed Object (this pointer may itself be optionally followed by padding). This series of Packed Objects is terminated by optional976
```
padding followed by one or more zero-valued octets aligned on byte boundaries. See Figure I.3.1-1, which shows this sequence when977
appearing in an RFID tag.978
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 401 of 448
```
Note: Because the data structures within an encoded Packed Object are bit-aligned rather than byte-aligned, this Annex uses979
```
the term ‘octet’ instead of ‘byte’ except in case where an eight-bit quantity must be aligned on a byte boundary.980
Figure I.3.1-1 Overall Memory structure when using Packed Objects981
DSFID Optional
Pointer*
And/Or
Padding
First Packed
Object
Optional
Pointer*
And/Or
Padding
Optional
Second Packed
Object …
Optional
Packed
Object
Optional
Pointer*
And/Or
Padding
Zero
```
Octet(s)
```
*Note: the Optional Pointer to a Directory Packed Object may appear at most only once in memory982
Every Packed Object represents a sequence of one or more data system Identifiers, each specified by reference to an entry within a Base ID983
```
Table from a registered data format. The entry is referenced by its relative position within the Base Table; this relative position or Base984
```
Table index is referred to throughout this specification as an "ID Value." There are two different Packed Objects methods available for985
representing a sequence of Identifiers by reference to their ID Values:986
```
■ An ID List Packed Object (IDLPO) encodes a series of ID Values as a list, whose length depends on the number of data items being represented;987
```
```
■ An ID Map Packed Object (IDMPO) instead encodes a fixed-length bit array, whose length depends on the total number of entries defined in the988
```
registered Base Table. Each bit in the array is ‘1’ if the corresponding table entry is represented by the Packed Object, and is ‘0’ otherwise.989
An ID List is the default Packed Objects format, because it uses fewer bits than an ID Map, if the list contains only a small percentage of the990
data system’s defined ID Values. However, if the Packed Object includes more than about one-quarter of the defined entries, then an ID991
```
Map requires fewer bits. For example, if a data system has sixteen entries, then each ID Value (table index) is a four bit quantity, and a list992
```
of four ID Values takes as many bits as would the complete ID Map. An ID Map’s fixed-length characteristic makes it especially suitable for993
```
use in a Directory Packed Object, which lists all of the Identifiers in all of the Packed Objects in memory (see Section I.9. The overall994
```
structure of a Packed Object is the same, whether an IDLPO or an IDMPO, as shown in Figure I 3-2 and as described in the next subsection.995
Figure I.3.1-2 Packed object structure996
Optional
Format
Flags
Object Info Section
```
(IDLPO or IDMPO)
```
Secondary
ID Section
```
(if needed)
```
Aux Format
Section
```
(if needed)
```
Data Section
```
(if needed)
```
Packed objects may be made "editable", by adding an optional Addendum subsection to the end of the Object Info section, which includes a997
pointer to an "Addendum Packed Object" where additions and/or deletions have been made. One or more such "chains" of editable "parent"998
and "child" Packed Objects may be present within the overall sequence of Packed Objects in memory, but no more than one chain of999
Directory Packed Objects may be present.1000
I.3.2 Descriptions of each section of a Packed Object’s structure1001
```
Each Packed Object consists of several bit-aligned sections (that is, no pad bits between sections are used), carried in a variable number of1002
```
octets. All required and optional Packed Objects formats are encompassed by the following ordered list of Packed Objects sections. Following1003
this list, each Packed Objects section is introduced, and later sections of this Annex describe each Packed Objects section in detail.1004
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 402 of 448
■ Format Flags: A Packed Object may optionally begin with the pattern ‘0000’ which is reserved to introduce one or more Format Flags, as1005
described in I.4.2. These flags may indicate use of the non-default ID Map format. If the Format Flags are not present, then the Packed Object1006
defaults to the ID List format.1007
```
□ Certain flag patterns indicate an inter-Object pattern (Directory Pointer or Padding)1008
```
```
□ Other flag patterns indicate the Packed Object’s type (Map or. List), and may indicated the presence of an optional Addendum1009
```
subsection for editing.1010
■ Object Info: All Packed Objects contain an Object Info Section which includes Object Length Information and ID Value Information:1011
```
□ Object Length Information includes an ObjectLength field (indicating the overall length of the Packed Object in octets) followed by1012
```
Pad Indicator bit, so that the number of significant bits in the Packed Object can be determined.1013
```
□ ID Value Information indicates which Identifiers are present and in what order, and (if an IDLPO) also includes a leading1014
```
NumberOfIDs field, indicating how many ID Values are encoded in the ID List.1015
The Object Info section is encoded in one of the following formats, as shown in Figure I.3.2-1 and Figure I.3.2-2.1016
```
■ ID List (IDLPO) Object Info format:1017
```
```
□ Object Length (EBV-6) plus Pad Indicator bit1018
```
```
□ A single ID List or an ID Lists Section (depending on Format Flags)1019
```
```
■ ID Map (IDMPO) Object Info format:1020
```
□ One or more ID Map sections1021
```
□ Object Length (EBV-6) plus Pad Indicator bit1022
```
For either of these Object Info formats, an Optional Addendum subsection may be present at the end of the Object Info section.1023
■ Secondary ID Bits: A Packed Object may include a Secondary ID section, if needed to encode additional bits that are defined for some classes1024
```
of IDs (these bits complete the definition of the ID).1025
```
■ Aux Format Bits: A Data Packed Object may include an Aux Format Section, which if present encodes one or more bits that are defined to1026
support data compression, but do not contribute to defining the ID.1027
■ Data Section: A Data Packed Object includes a Data Section, representing the compressed data associated with each of the identifiers listed1028
within the Packed Object. This section is omitted in a Directory Packed Object, and in a Packed Object that uses No-directory compaction1029
```
(see I.7.1). Depending on the declaration of data format in the relevant ID table, the Data section will contain either or both of two subsections:1030
```
□ Known-Length Numerics subsection: this subsection compacts and concatenates all of the non-empty data strings that are1031
known a priori to be numeric.1032
□ AlphaNumeric subsection: this subsection concatenates and compacts all of the non-empty data strings that are not a priori1033
known to be all-numeric.1034
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 403 of 448
Figure I.3.2-1 IDLPO Object Info Structure1035
Object Info, in a Default ID List PO Object Info, in a Non-default ID List PO
Object
Length
Number
Of IDs
ID
List
Optional
Addendum
or Object
Length
ID Lists Section
```
(one or more lists)
```
Optional
Addendum
Figure I.3.2-2 IDMPO Object Info Structure1036
Object Info, in an ID Map PO
ID Map Section
```
(one or more maps)
```
Object
Length
Optional
Addendum
I.4 Format Flags section1037
The default layout of memory, under the Packed Objects access method, consists of a leading DSFID, immediately followed by an ID List1038
```
Packed Object (at the next byte boundary), then optionally additional ID List Packed Objects (each beginning at the next byte boundary),1039
```
```
and terminated by a zero-valued octet at the next byte boundary (indicating that no additional Packed Objects are encoded). This section1040
```
defines the valid Format Flags patterns that may appear at the expected start of a Packed Object to override the default layout if desired1041
```
(for example, by changing the Packed Object’s format, or by inserting padding patterns to align the next Packed Object on a word or block1042
```
```
boundary). The set of defined patterns are shown below.1043
```
Table I.3.2-1 Format Flag1044
Bit Pattern Description Additional Info See Section
0000 0000 Termination Pattern No more Packed Objects follow I.4.1
LLLLLL xx First octet of an IDLPO For any LLLLLL > 3 I.5
```
0000 Format Flags starting pattern (if the full EBV-6 is non-zero) I.4.2
```
0000 10NA IDLPO with:
```
N = 1: non-default Info
```
```
A = 1: Addendum Present
```
If N = 1: allows multiple ID tables
```
If A = 1: Addendum ptr(s) at end of
```
Object Info section
I.4.3
0000 01xx Inter-PO pattern A Directory Pointer, or padding I.4.4
0000 0100 Signifies a padding octet No padding length indicator follows I.4.4
0000 0101 Signifies run-length padding An EBV-8 padding length follows I.4.4
0000 0110 RFU I.4.4
0000 0111 Directory pointer Followed by EBV-8 pattern I.4.4
0000 11xx ID Map Packed Object I.4.2
0000 0001
0000 0010
0000 0011
[Invalid] Invalid pattern
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 404 of 448
I.4.1 Data terminating flag pattern1045
A pattern of eight or more ‘0’ bits at the expected start of a Packed Object denotes that no more Packed Objects are present in the1046
remainder of memory.1047
```
NOTE: Six successive ‘0’ bits at the expect start of a Packed Object would (if interpreted as a Packed Object) indicate an ID List Packed1048
```
Object of length zero.1049
I.4.2 Format flag section starting bit patterns1050
A non-zero EBV-6 with a leading pattern of "0000" is used as a Format Flags section Indication Pattern. The additional bits following an1051
initial ‘0000’ format Flag Indicating Pattern are defined as follows:1052
```
■ A following two-bit pattern of ‘10’ (creating an initial pattern of ‘000010’) indicates an IDLPO with at least one non-default optional feature (see1053
```
```
I.4.3)1054
```
■ A following two-bit pattern of ‘11’ indicates an IDMPO, which is a Packed Object using an ID Map format instead of ID List-format The ID Map1055
```
section (see I.9) immediately follows this two-bit pattern.1056
```
```
■ A following two-bit pattern of ‘01’ signifies an External pattern (Padding pattern or Pointer) prior to the start of the next Packed Object (see I.4.4)1057
```
A leading EBV-6 Object Length of less than four is invalid as a Packed Objects length.1058
```
Note: The shortest possible Packed Object is an IDLPO, for a data system using four bits per ID Value, encoding a single ID1059
```
Value. This Packed Object has a total of 14 fixed bits. Therefore, a two-octet Packed Object would only contain two data bits, and is1060
invalid. A three-octet Packed Object would be able to encode a single data item up to three digits long. In order to preserve "3" as an1061
```
invalid length in this scenario, the Packed Objects encoder shall encode a leading Format Flags section (with all options set to zero, if1062
```
```
desired) in order to increase the object length to four.1063
```
I.4.3 IDLPO Format Flags1064
The appearance of ‘000010’ at the expected start of a Packed Object is followed by two additional bits, to form a complete IDLPO Format1065
Flags section of "000010NA", where:1066
■ If the first additional bit ‘N’ is ‘1’, then a non-default format is employed for the IDLPO Object Info section. Whereas the default IDLPO format1067
```
allows for only a single ID List (utilising the registration’s default Base ID Table), the optional non-default IDLPO Object Info format supports a1068
```
```
sequence of one or more ID Lists, and each such list begins with identifying information as to which registered table it represents (see I.5.1).1069
```
```
■ If the second additional bit ‘A’ is ‘1’, then an Addendum subsection is present at the end of the Object Info section (see I.5.6).1070
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 405 of 448
I.4.4 Patterns for use between Packed Objects1071
The appearance of ‘000001’ at the expected start of a Packed Object is used to indicate either padding or a directory pointer, as follows:1072
■ A following two-bit pattern of ‘11’ indicates that a Directory Packed Object Pointer follows the pattern. The pointer is one or more octets in length,1073
```
in EBV-8 format. This pointer may be Null (a value of zero), but if non-zero, indicates the number of octets from the start of the pointer to the1074
```
```
start of a Directory Packed Object (which if editable, shall be the first in its "chain"). For example, if the Format Flags byte for a Directory Pointer1075
```
is encoded at byte offset 1, the Pointer itself occupies bytes beginning at offset 2, and the Directory starts at byte offset 9, then the Dir Ptr1076
encodes the value "7" in EBV-8 format. A Directory Packed Object Pointer may appear before the first Packed Object in memory, or at any other1077
```
position where a Packed Object may begin, but may only appear once in a given data carrier memory, and (if non-null) must be at a lower1078
```
```
address than the Directory it points to. The first octet after this pointer may be padding (as defined immediately below), a new set of Format Flag1079
```
patterns, or the start of an ID List Packed Object.1080
■ A following two-bit pattern of ‘00’ indicates that the full eight-bit pattern of ‘00000100’ serves as a padding byte, so that the next Packed Object1081
may begin on a desired word or block boundary. This pattern may repeat as necessary to achieve the desired alignment.1082
■ A following two-bit pattern of ‘01’ as a run-length padding indicator, and shall be immediately followed by an EBV-8 indicating the number of1083
```
octets from the start of the EBV-8 itself to the start of the next Packed Object (for example, if the next Packed Object follows immediately, the1084
```
```
EBV-8 has a value of one). This mechanism eliminates the need to write many words of memory in order to pad out a large memory block.1085
```
■ A following two-bit pattern of ‘10’ is Reserved.1086
I.5 Object Info section1087
```
Each Packed Object’s Object Info section contains both Length Information (the size of the Packed Object, in bits and in octets), and ID1088
```
```
Values Information. A Packed Object encodes representations of one or more data system Identifiers and (if a Data Packed Object) also1089
```
```
encodes their associated data elements (AI strings, DI strings, etc). The ID Values information encodes a complete listing of all the1090
```
```
Identifiers (AIs, DIs, etc) encoded in the Packed Object, or (in a Directory Packed Object) all the Identifiers encoded anywhere in memory.1091
```
```
To conserve encoded and transmitted bits, data system Identifiers (each typically represented in data systems by either two, three, or four1092
```
```
ASCII characters) is represented within a Packed Object by an ID Value, representing an index denoting an entry in a registered Base Table1093
```
of ID Values. A single ID Value may represent a single Object Identifier, or may represent a commonly-used sequence of Object Identifiers.1094
In some cases, the ID Value represents a "class" of related Object Identifiers, or an Object Identifier sequence in which one or more Object1095
```
Identifiers are optionally encoded; in these cases, Secondary ID Bits (see I.6) are encoded in order to specify which selection or option was1096
```
```
chosen when the Packed Object was encoded. A "fully-qualified ID Value" (FQIDV) is an ID Value, plus a particular choice of associated1097
```
```
Secondary ID bits (if any are invoked by the ID Value’s table entry). Only one instance of a particular fully-qualified ID Value may appear in1098
```
a data carrier’s Data Packed Objects, but a particular ID Value may appear more than once, if each time it is "qualified" by different1099
```
Secondary ID Bits. If an ID Value does appear more than once, all occurrences shall be in a single Packed Object (or within a single "chain"1100
```
```
of a Packed Object plus its Addenda).1101
```
There are two methods defined for encoding ID Values: an ID List Packed Object uses a variable-length list of ID Value bit fields, whereas1102
an ID Map Packed Object uses a fixed-length bit array. Unless a Packed Object’s format is modified by an initial Format Flags pattern, the1103
```
Packed Object’s format defaults to that of an ID List Packed Object (IDLPO), containing a single ID List, whose ID Values correspond to the1104
```
default Base ID Table of the registered Data Format. Optional Format Flags can change the format of the ID Section to either an IDMPO1105
```
format, or to an IDLPO format encoding an ID Lists section (which supports multiple ID Tables, including non-default data systems).1106
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 406 of 448
```
Although the ordering of information within the Object Info section varies with the chosen format (see I.5.1), the Object Info section of1107
```
```
every Packed Object shall provide Length information as defined in I.5.2, and ID Values information (see I.5.3) as defined in I.5.4, or I.5.5.1108
```
```
The Object Info section (of either an IDLPO or an IDMPO) may conclude with an optional Addendum subsection (see I.5.6).1109
```
I.5.1 Object Info formats1110
IDLPO default Object Info format1111
The default IDLPO Object Info format is used for a Packed Object either without a leading Format Flags section, or with a Format Flags1112
section indicating an IDLPO with a possible Addendum and a default Object Info section. The default IDLPO Object Info section contains a1113
```
single ID List (optionally followed by an Addendum subsection if so indicated by the Format Flags). The format of the default IDLPO Object1114
```
Info section is shown in the table below.1115
Table I.5.1-1 Default IDLPO Object Info format1116
Field Name: Length Information NumberOfIDs ID Listing Addendum
subsection
```
Usage: The number of octets
```
in this Object, plus a
last-octet pad
indicator
number of ID
Values in this
```
Object (minus one)
```
A single list of ID
```
Values; value size
```
depends on registered
Data Format
```
Optional pointer(s)
```
to other Objects
containing Edit
information
```
Structure: Variable: see I.5.2 Variable:EBV-3 See I.5.4 See I.5.6
```
In a IDLPO’s Object Info section, the NumberOfIDs field is an EBV-3 Extensible Bit Vector, consisting of one or more repetitions of an1117
Extension Bit followed by 2 value bits. This EBV-3 encodes one less than the number of ID Values on the associated ID Listing. For example,1118
```
an EBV-3 of ‘101 000’ indicates (4 + 0 +1) = 5 IDs values. The Length Information is as described in I.5.2 for all Packed Objects. The next1119
```
```
fields are an ID Listing (see I.5.4) and an optional Addendum subsection (see I.5.6).1120
```
IDLPO non-default Object Info format1121
Leading Format Flags may modify the Object Info structure of an IDLPO, so that it may contain more than one ID Listing, in an ID Lists1122
```
section (which also allows non-default ID tables to be employed). The non-default IDLPO Object Info structure is shown in the table below.1123
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 407 of 448
Table I.5.1-2 Non-Default IDLPO Object Info format1124
Field
```
Name:
```
Length Info ID Lists Section, first List Optional
Additional ID
```
List(s)
```
Null App
Indicator
```
(single
```
```
zero bit)
```
Addendum
SubsectionApplication
Indicator
Number
of IDs
ID
Listing
```
Usage: The
```
number of
octets in
this Object,
plus a last-
octet pad
indicator
Indicates
the selected
ID Table
and the size
of each
entry
Number
Of ID
Values on
the list
```
(minus
```
```
one)
```
Listing
of ID
Values,
then
one F/R
Use bit
Zero or more
repeated
lists, each
for a
different ID
Table
Optional
```
pointer(s) to
```
other Objects
containing
Edit
information
```
Structure: see I.5.2 see I.5.3 See I.5.1 See
```
I.5.4
and
I.5.3
References
in previous
columns
See I.5.3 See I.5.6
IDMPO Object Info format1125
```
Leading Format Flags may define the Object Info structure to be an IDMPO, in which the Length Information (and optional Addendum1126
```
```
subsection) follow an ID Map section (see I.5.5). This arrangement ensures that the ID Map is in a fixed location for a given application, of1127
```
benefit when used as a Directory. The IDMPO Object Info structure is shown in the table below.1128
Table I.5.1-3 IDMPO Object Info format1129
Field Name: ID Map section Length Information Addendum
```
Usage: One or more ID Map structures,
```
each using a different ID Table
The number of octets in this
Object, plus a last-octet pad
indicator
Optional
```
pointer(s) to
```
other Objects
containing Edit
information
```
Structure: see I.5.3 See I.5.2 See I.5.6
```
I.5.2 Length Information1130
The format of the Length information, always present in the Object Info section of any Packed Object, is shown in the table below.1131
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 408 of 448
Table I.5.2-1 Packed Object Length information1132
Field Name: ObjectLength Pad Indicator
```
Usage: The number of 8-bit bytes in this Object This include s the 1st
```
byte of this Packed Object, including its IDLPO/IDMPO
format flags if present. It excludes patterns for use between
Packed Objects, as specified in I.4.4
If ‘1’: the Object’s last
byte contains at least 1
pad
```
Structure: Variable: EBV-6 Fixed: 1 bit
```
The first field, ObjectLength, is an EBV-6 Extensible Bit Vector, consisting of one or more repetitions of an Extension Bit and 5 value bits. An1133
```
EBV-6 of ‘000100’ (value of 4) indicates a four-byte Packed Object, An EBV-6 of ‘100001 000000’ (value of 32) indicates a 32-byte Object,1134
```
and so on.1135
The Pad Indicator bit immediately follows the end of the EBV-6 ObjectLength. This bit is set to ‘0’ if there are no padding bits in the last byte1136
of the Packed Object. If set to ‘1’, then bitwise padding begins with the least-significant or rightmost ‘1’ bit of the last byte, and the padding1137
consists of this rightmost ‘1’ bit, plus any ‘0’ bits to the right of that bit. This method effectively uses a single bit to indicate a three-bit1138
```
quantity (i.e., the number of trailing pad bits). When a receiving system wants to determine the total number of bits (rather than bytes) in1139
```
```
a Packed Object, it would examine the ObjectLength field of the Packed Object (to determine the number of bytes) and multiply the result1140
```
```
by eight, and (if the Pad Indicator bit is set) examine the last byte of the Packed Object and decrement the bit count by (1 plus the number1141
```
```
of ‘0’ bits following the rightmost ‘1’ bit of that final byte).1142
```
I.5.3 General description of ID values1143
```
A registered data format defines (at a minimum) a Primary Base ID Table (a detailed specification for registered ID tables may be found in1144
```
```
Annex J). This base table defines the data system Identifier(s) represented by each row of the table, any Secondary ID Bits or Aux Format1145
```
```
bits invoked by each table entry, and various implicit rules (taken from a predefined rule set) that decoding systems shall use when1146
```
interpreting data encoded according to each entry. When a data item is encoded in a Packed Object, its associated table entry is identified1147
by the entry’s relative position in the Base Table. This table position or index is the ID Value that is represented in Packed Objects.1148
```
A Base Table containing a given number of entries inherently specifies the number of bits needed to encode a table index (i.e., an ID Value)1149
```
```
in an ID List Packed Object (as the Log (base 2) of the number of entries). Since current and future data system ID Tables will vary in1150
```
unpredictable ways in terms of their numbers of table entries, there is a need to pre-define an ID Value Size mechanism that allows for1151
future extensibility to accommodate new tables, while minimising decoder complexity and minimising the need to upgrade decoding1152
```
software (other than the addition of new tables). Therefore, regardless of the exact number of Base Table entries defined, each Base Table1153
```
```
definition shall utilise one of the predefined sizes for ID Value encodings defined in Table I 5-5 (any unused entries shall be labelled as1154
```
```
reserved, as provided in Annex J). The ID Size Bit pattern is encoded in a Packed Object only when it uses a non-default Base ID Table.1155
```
```
Some entries in the table indicate a size that is not an integral power of two. When encoding (into an IDLPO) ID Values from tables that1156
```
utilise such sizes, each pair of ID Values is encoded by multiplying the earlier ID of the pair by the base specified in the fourth column of1157
Table I-5-5 and adding the later ID of the pair, and encoding the result in the number of bits specified in the fourth column. If there is a1158
trailing single ID Value for this ID Table, it is encoded in the number of bits specified in the third column of the table below.1159
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 409 of 448
Table I.5.3-1 Defined ID Value sizes1160
ID Size Bit
pattern
Maximum
number of Table
Entries
Number of Bits per single or
trailing ID Value, and how
encoded
Number of Bits per pair
of ID Values, and how
encoded
000 Up to 16 4, as 1 Base 16 value 8, as 2 Base 16 values
001 Up to 22 5, as 1 Base 22 value 9, as 2 Base 22 values
010 Up to 32 5, as 1 Base 32 value 10, as 2 Base 32 values
011 Up to 45 6, as 1 Base 45 value 11, as 2 Base 45 values
100 Up to 64 6, as 1 Base 64 value 12, as 2 Base 64 values
101 Up to 90 7, as 1 Base 90 value 13, as 2 Base 90 values
110 Up to 128 7, as 1 Base 128 value 14, as 2 Base 128
values
1110 Up to 256 8, as 1 Base 256 value 16, as 2 Base 256
values
111100 Up to 512 9, as 1 Base 512 value 18, as 2 Base 512
values
111101 Up to 1024 10, as 1 Base 1024 value 20, as 2 Base 1024
values
111110 Up to 2048 11, as 1 Base 2048 value 22, as 2 Base 2048
values
111111 Up to 4096 12, as 1 Base 4096 value 24, as 2 Base 4096
values
Application indicator subsection1161
An Application Indicator subsection can be utilised to indicate use of ID Values from a default or non-default ID Table. This subsection is1162
required in every IDMPO, but is only required in an IDLPO that uses the non-default format supporting multiple ID Lists.1163
An Application Indicator consists of the following components:1164
■ A single AppIndicatorPresent bit, which if ‘0’ means that no additional ID List or Map follows. Note that this bit is always omitted for the first List1165
or Map in an Object Info section. When this bit is present and ‘0’, then none of the following bit fields are encoded.1166
■ A single ExternalReg bit that, if ‘1’, indicates use of an ID Table from a registration other than the memory’s default. If ‘1’, this bit is immediately1167
followed by a 9-bit representation of a Data Format registered under ISO/IEC 15961.1168
```
■ An ID Size pattern which denotes a table size (and therefore an ID Map bit length, when used in an IDMPO), which shall be one of the patterns1169
```
defined by Table I-5. The table size indicated in this field must be less than or equal to the table size indicated in the selected ID table. The1170
purpose of this field is so that the decoder can parse past the ID List or ID Map, even if the ID Table is not available to the decoder.1171
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 410 of 448
■ A three-bit ID Subset pattern. The registered data format’s Primary Base ID Table, if used by the current Packed Object, shall always be indicated1172
```
by an encoded ID Subset pattern of ‘000’. However, up to seven Alternate Base Tables may also be defined in the registration (with varying ID1173
```
```
Sizes), and a choice from among these can be indicated by the encoded Subset pattern. This feature can be useful to define smaller sector-1174
```
specific or application-specific subsets of a full data system, thus substantially reducing the size of the encoded ID Map.1175
Full/Restricted Use bits1176
When contemplating the use of new ID Table registrations, or registrations for external data systems, application designers may utilise a1177
"restricted use" encoding option that adds some overhead to a Packed Object but in exchange results in a format that can be fully decoded1178
by receiving systems not in possession of the new or external ID table. With the exception of a IDLPO using the default Object Info format,1179
one Full/Restricted Use bit is encoded immediately after each ID table is represented in the ID Map section or ID Lists section of a Data or1180
Directory Packed Object. In a Directory Packed Object, this bit shall always be set to '0' and its value ignored. If an encoder wishes to utilise1181
the "restricted use" option in an IDLPO, it shall preface the IDLPO with a Format Flags section invoking the non-default Object Info format.1182
If a "Full/Restricted Use" bit is ‘0’ then the encoding of data strings from the corresponding registered ID Table makes full use of the ID1183
table’s IDstring and FormatString information. If the bit is ‘1’, then this signifies that some encoding overhead was added to the Secondary1184
```
ID section and (in the case of Packed-Object compaction) the Aux Format section, so that a decoder without access to the table can1185
```
nonetheless output OIDs and data from the Packed Object according to the scheme specified in J.4.1. Specifically, a Full/Restricted Use bit1186
set to ‘1’ indicates that:1187
■ for each encoded ID Value, the encoder added an EBV-3 indicator to the Secondary ID section, to indicate how many Secondary ID bits were1188
```
invoked by that ID Value. If the EBV-3 is nonzero, then the Secondary ID bits (as indicated by the table entry) immediately follow, followed in1189
```
turn by another EBV-3, until the entire list of ID Values has been represented.1190
■ the encoder did not take advantage of the information from the referenced table’s FormatString column. Instead, corresponding to each ID Value,1191
```
the encoder inserted an EBV-3 into the Aux Format section, indicating the number of discrete data string lengths invoked by the ID Value (which1192
```
```
could be more than one due to combinations and/or optional components), followed by the indicated number of string lengths, each length1193
```
encoded as though there were no FormatString in the ID table. All data items were encoded in the A/N subsection of the Data section.1194
I.5.4 ID Values representation in an ID Value-list Packed Object1195
```
Each ID Value is represented within an IDLPO on a list of bit fields; the number of bit fields on the list is determined from the NumberOfIDs1196
```
```
field (see Section I.5.6). Each ID Value bit field’s length is in the range of four to eleven bits, depending on the size of the Base Table index1197
```
it represents. In the optional non-default format for an IDLPO’s Object Info section, a single Packed Object may contain multiple ID List1198
subsections, each referencing a different ID Table. In this non-default format, each ID List subsection consists of an Application Indicator1199
```
subsection (which terminates the ID Lists, if it begins with a ‘0’ bit), followed by an EBV-3 NumberOfIDs, an ID List, and a Full/Restricted1200
```
Use flag.1201
I.5.5 ID Values representation in an ID Map Packed Object1202
Encoding an ID Map can be more efficient than encoding a list of ID Values, when representing a relatively large number of ID Values1203
```
(constituting more than about 10 percent of a large Base Table’s entries, or about 25 percent of a small Base Table’s entries). When1204
```
```
encoded in an ID Map, each ID Value is represented by its relative position within the map (for example, the first ID Map bit represents ID1205
```
```
Value "0", the third bit represents ID Value "2", and the last bit represents ID Value ‘n’ (corresponding to the last entry of a Base Table with1206
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 411 of 448
```
(n+1) entries). The value of each bit within an ID Map indicates whether the corresponding ID Value is present (if the bit is ‘1’) or absent (if1207
```
```
‘0’). An ID Map is always encoded as part of an ID Map Section structure (see I.9.1).1208
```
I.5.6 Optional Addendum subsection of the Object Info section1209
The Packed Object Addendum feature supports basic editing operations, specifically the ability to add, delete, or replace individual data1210
items in a previously-written Packed Object, without a need to rewrite the entire Packed Object. A Packed Object that does not contain an1211
Addendum subsection cannot be edited in this fashion, and must be completely rewritten if changes are required.1212
An Addendum subsection consists of a Reverse Links bit, followed by a Child bit, followed by either one or two EBV-6 links. Links from a1213
```
Data Packed Object shall only go to other Data Packed Objects as addenda; links from a Directory Packed Object shall only go to other1214
```
Directory Packed Objects as addenda. The standard Packed Object structure rules apply, with some restrictions that are described in I.5.6.1215
The Reverse Links bit shall be set identically in every Packed Object of the same "chain." The Reverse Links bit is defined as follows:1216
■ If the Reverse Links bit is ‘0’, then each child in this chain of Packed Objects is at a higher memory location then its parent. The link to a Child is1217
```
encoded as the number of octets (plus one) that are in between the last octet of the current Packed Object and the first octet of the Child. The1218
```
```
link to the parent is encoded as the number of octets (plus one) that are in between the first octet of the parent Packed Object and the first octet1219
```
of the current Packed Object.1220
■ If the Reverse Links bit is ‘1’, then each child in this chain of Packed Objects is at a lower memory location then its parent. The link to a Child is1221
```
encoded as the number of octets (plus one) that are in between the first octet of the current Packed Object and the first octet of the Child. The1222
```
```
link to the parent is encoded as the number of octets (plus one) that are in between the last octet of the current Packed Object and the first octet1223
```
of the parent.1224
The Child bit is defined as follows:1225
```
■ If the Child bit is a ‘0’, then this Packed Object is an editable "Parentless" Packed Object (i.e., the first of a chain), and in this case the Child bit is1226
```
immediately followed by a single EBV-6 link to the first "child" Packed Object that contains editing addenda for the parent.1227
■ If the Child bit is a ‘1’, then this Packed Object is an editable "child" of an edited "parent," and the bit is immediately followed by one EBV-6 link1228
to the "parent" and a second EBV-6 line to the next "child" Packed Object that contains editing addenda for the parent.1229
```
A link value of zero is a Null pointer (no child exists), and in a Packed Object whose Child bit is ‘0’, this indicates that the Packed Object is1230
```
editable, but has not yet been edited. A link to the Parent is provided, so that a Directory may indicate the presence and location of an ID1231
Value in an Addendum Packed Object, while still providing an interrogator with the ability to efficiently locate the other ID Values that are1232
logically associated with the original "parent" Packed Object. A link value of zero is invalid as a pointer towards a Parent.1233
In order to allow room for a sufficiently-large link, when the future location of the next "child" is unknown at the time the parent is encoded,1234
```
it is permissible to use the "redundant" form of the EBV-6 (for example using "100000 000000" to represent a link value of zero).1235
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 412 of 448
```
Addendum "EditingOP" list (only in ID List Packed Objects)1236
```
In an IDLPO only, each Addendum section of a "child" ID List Packed Object contains a set of "EditingOp" bits encoded immediately after its1237
last EBV-6 link. The number of such bits is determined from the number of entries on the Addendum Packed Object’s ID list. For each ID1238
Value on this list, the corresponding EditingOp bit or bits are defined as follows:1239
```
■ ‘1’ means that the corresponding Fully-Qualified ID Value (FQIDV) is Replaced. A Replace operation has the effect that the data originally1240
```
associated with the FQIDV matching the FQIDV in this Addendum Packed Object shall be ignored, and logically replaced by the Aux Format bits1241
```
and data encoded in this Addendum Packed Object)1242
```
■ ‘00’ means that the corresponding FQIDV is Deleted but not replaced. In this case, neither the Aux Format bits nor the data associated with this1243
ID Value are encoded in the Addendum Packed Object.1244
```
■ ‘01’ means that the corresponding FQIDV is Added (either this FQIDV was not previously encoded, or it was previously deleted without1245
```
```
replacement). In this case, the associated Aux Format Bits and data shall be encoded in the Addendum Packed Object.1246
```
```
Note: If an application requests several "edit" operations at once (including some Delete or Replace operations as well as1247
```
```
Adds) then implementations can achieve more efficient encoding if the Adds share the Addendum overhead, rather than being1248
```
implemented in a new Packed Object.1249
Packed Objects containing an addendum subsection1250
A Packed Object containing an Addendum subsection is otherwise identical in structure to other Packed Objects. However, the following1251
observations apply:1252
```
■ A "parentless" Packed Object (the first in a chain) may be either an ID List Packed Object or an ID Map Packed Object (and a parentless IDMPO1253
```
```
may be either a Data or Directory IDMPO). When a "parentless" PO is a directory, only directory IDMPOs may be used as addenda. A Directory1254
```
```
IDMPO’s Map bits shall be updated to correctly reflect the end state of the chain of additions and deletions to the memory bank; an Addendum to1255
```
```
the Directory is not utilised to perform this maintenance (a Directory Addendum may only add new structural components, as described later in1256
```
```
this section). In contrast, when the edited parentless object is an ID List Packed Object or ID Map Packed Object, its ID List or ID Map cannot be1257
```
```
updated to reflect the end state of the aggregate Object (parents plus children).1258
```
■ Although a "child" may be either an ID List or an ID Map Packed Object, only an IDLPO can indicate deletions or changes to the current set of1259
fully-qualified ID Values and associated data that is embodied in the chain.1260
```
□ When a child is an IDMPO, it shall only be utilised to add (not delete or modify) structural information, and shall not be used to1261
```
modify existing information. In a Directory chain, a child IDMPO may add new ID tables, or may add a new AuxMap section or1262
subsections, or may extend an existing PO Index Table or ObjectOffsets list. In a Data chain, an IDMPO shall not be used as an1263
Addendum, except to add new ID Tables.1264
```
□ When a child is an IDLPO, its ID list (followed by "EditingOp" bits) lists only those FQIDVs that have been deleted, added, or1265
```
replaced, relative to the cumulative ID list from the prior Objects linked to it.1266
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 413 of 448
I.6 Secondary ID Bits section1267
```
The Packed Objects design requirements include a requirement that all of the data system Identifiers (AI’s, DI’s, etc.) encoded in a Packed1268
```
Object’s can be fully recognised without expanding the compressed data, even though some ID Values provide only a partially-qualified1269
Identifier. As a result, if any of the ID Values invoke Secondary ID bits, the Object Info section shall be followed by a Secondary ID Bits1270
section. Examples include a four-bit field to identify the third digit of a group of related Logistics AIs.1271
Secondary ID bits can be invoked for several reasons, as needed in order to fully specify Identifiers. For example, a single ID Table entry’s1272
```
ID Value may specify a choice between two similar identifiers (requiring one encoded bit to select one of the two IDs at the time of1273
```
```
encoding), or may specify a combination of required and optional identifiers (requiring one encoded bit to enable or disable each option).1274
```
The available mechanisms are described in Annex J. All resulting Secondary ID bit fields are concatenated in this Secondary ID Bits section,1275
in the same order as the ID Values that invoked them were listed within the Packed Object. Note that the Secondary ID Bits section is1276
identically defined, whether the Packed Object is an IDLPO or an IDMPO, but is not present in a Directory IDMPO.1277
I.7 Aux Format section1278
The Aux Format section of a Data Packed Object encodes auxiliary information for the decoding process. A Directory Packed Object does not1279
contain an Aux Format section. In a Data Packed Object, the Aux Format section begins with "Compact-Parameter" bits as defined in the1280
table below.1281
Table I.5.6-1 Compact-Parameter bit patterns1282
Bit Pattern Compaction method used in this Packed Object Reference
‘1’ "Packed-Object" compaction See I.7.2
‘000’ "Application-Defined", as defined for the No-Directory access method See I.7.1
‘001’ "Compact", as defined for the No-Directory access method See I.7.1
‘010’ "UTF-8", as defined for the No-Directory access method See I.7.1
```
‘011bbbb’ (‘bbbb’ shall be in the range of 4..14): reserved for future definition See I.7.1
```
```
If the Compact-Parameter bit pattern is ‘1’, then the remainder of the Aux Format section is encoded as described in I.7.2; otherwise, the1283
```
remainder of the Aux Format section is encoded. See I.7.1 as described in I.7.1.1284
I.7.1 Support for No-Directory compaction methods1285
If any of the No-Directory compaction methods were selected by the Compact-Parameter bits, then the Compact-Parameter bits are1286
followed by an byte-alignment padding pattern consisting of zero or more ‘0’ bits followed by a single ‘1’ bit, so that the next bit after the ‘1’1287
is aligned as the most-significant bit of the next byte.1288
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 414 of 448
This next byte is defined as the first octet of a "No-Directory Data section", which is used in place of the Data section described in I.8. The1289
data strings of this Packed Object are encoded in the order indicated by the Object Info section of the Packed Object, compacted exactly as1290
```
described in Annex D of [ISO15962] (Encoding rules for No-Directory Access-Method), with the following two exceptions:1291
```
■ The Object-Identifier is not encoded in the "No-Directory Data section", because it has already been encoded into the Object Info and Secondary1292
ID sections.1293
■ The Precursor is modified in that only the three Compaction Type Code bits are significant, and the other bits in the Precursor are set to ‘0’.1294
Therefore, each of the data strings invoked by the ID Table entry are separately encoded in a modified data set structure as:1295
<modified precursor> <length of compacted object> <compacted object octets>1296
The <compacted object octets> are determined and encoded as described in D.1.1 and D.1.2 of [ISO15962] and the <length of compacted1297
object> is determined and encoded as described in D.2 of [ISO15962].1298
```
Following the last data set, a terminating precursor value of zero shall not be encoded (the decoding system recognises the end of the data1299
```
```
using the encoded ObjectLength of the Packed Object).1300
```
I.7.2 Support for the packed-object compaction method1301
If the Packed-Object compaction method was selected by the Compact-Parameter bits, then the Compact-Parameter bits are followed by1302
zero or more Aux Format bits, as may be invoked by the ID Table entries used in this Packed Object. The Aux Format bits are then1303
immediately followed by a Data section that uses the Packed-Object compaction method described in I.8.1304
An ID Table entry that was designed for use with the Packed-Object compaction method can call for various types of auxiliary information1305
```
beyond the complete indication of the ID itself (such as bit fields to indicate a variable data length, to aid the data compaction process). All1306
```
such bit fields are concatenated in this portion, in the order called for by the ID List or Map. Note that the Aux Format section is identically1307
defined, whether the Packed Object is an IDLPO or an IDMPO.1308
```
An ID Table entry invokes Aux Format length bits for all entries that are not specified as fixed-length in the table (however, these length1309
```
```
bits are not actually encoded if they correspond to the last data item encoded in the A/N subsection of a Packed Object). This information1310
```
allows the decoding system to parse the decoded data into strings of the appropriate lengths. An encoded Aux Format length entry utilises a1311
variable number of bits, determined from the specified range between the shortest and longest data strings allowed for the data item, as1312
```
follows:1313
```
```
■ If a maximum length is specified, and the specified range (defined as the maximum length minus the minimum length) is less than eight, or1314
```
greater than 44, then lengths in this range are encoded in the fewest number of bits that can express lengths within that range, and an encoded1315
value of zero represents the minimum length specified in the format string. For example, if the range is specified as from three to six characters,1316
then lengths are encoded using two bits, and ‘00’ represents a length of three.1317
```
■ Otherwise (including the case of an unspecified maximum length), the value (actual length – specified minimum) is encoded in a variable number1318
```
of bits, as follows:1319
```
■ Values from 0 to 14 (representing lengths from 1 to 15, if the specified minimum length is one character, for example) are encoded in four bits1320
```
```
■ Values from 15 to 29 are encoded in eight bits (a prefix of ‘1111’ followed by four bits representing values from 15 (‘0000’) to 29 (‘1110’)1321
```
```
■ Values from 30 to 44 are encoded in twelve bits (a prefix of ‘1111 1111’ followed by four bits representing values from 30 (‘0000’) to 44 (‘1110’)1322
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 415 of 448
```
■ Values greater than 44 are encoded as a twelve-bit prefix of all ‘1’s, followed by an EBV-6 indication of (value – 44).1323
```
```
Notes:1324
```
```
■ if a range is specified with identical upper and lower bounds (i.e., a range of zero), this is treated as a fixed length, not a variable length, and no1325
```
Aux Format bits are invoked.1326
■ If a range is unspecified, or has unspecified upper or lower bounds, then this is treated as a default lower bound of one, and/or an unlimited1327
upper bound.1328
I.8 Data section1329
A Data section is always present in a Packed Object, except in the case of a Directory Packed Object or Directory Addendum Packed Object1330
```
(which encode no data elements), the case of a Data Addendum Packed Object containing only Delete operations, and the case of a Packed1331
```
```
Object that uses No-directory compaction (see I.7.1). When a Data section is present, it follows the Object Info section (and the Secondary1332
```
```
ID and Aux Format sections, if present). Depending on the characteristics of the encoded IDs and data strings, the Data section may include1333
```
one or both of two subsections in the following order: a Known-Length Numerics subsection, and an AlphaNumerics subsection. The1334
following paragraphs provide detailed descriptions of each of these Data Section subsections. If all of the subsections of the Data section are1335
utilised in a Packed Object, then the layout of the Data section is as shown in the table below.1336
Table I.7.2-1 Maximum Structure of a Packed Objects Data section1337
Known-Length Numeric
subsection
AlphaNumeric subsection
A/N Header Bits Binary Data Segments
1 st
KLN
Binar
y
2 nd
KLN
Binar
y
… Last
KLN
Binar
y
Non-
Num
Base
```
Bit(s
```
```
)
```
Prefix
Bit,
Prefix
```
Run(s)
```
Suffix
Bit,
Suffix
```
Run(s)
```
Char
Map
Ext’d.
Num
Binary
Ext’d
Non-
Num
Binar
y
Base
10
Binar
y
Non-Num
Binary
I.8.1 Known-length-Numerics subsection of the data section1338
```
For always-numeric data strings, the ID table may indicate a fixed number of digits (this fixed-length information is not encoded in the1339
```
```
Packed Object) and/or a variable number of digits (in which case the string’s length was encoded in the Aux Format section, as described1340
```
```
above). When a single data item is specified in the FormatString column (see J.2.3) as containing a fixed-length numeric string followed by1341
```
a variable-length string, the numeric string is encoded in the Known-length-numerics subsection and the alphanumeric string in the1342
Alphanumeric subsection.1343
```
The summation of fixed-length information (derived directly from the ID table) plus variable-length information (derived from encoded bits1344
```
```
as just described) results in a "known-length entry" for each of the always-numeric strings encoded in the current Packed Object. Each all-1345
```
```
numeric data string in a Packed Object (if described as all-numeric in the ID Table) is encoded by converting the digit string into a single1346
```
```
Binary number (up to 160 bits, representing a binary value between 0 and (10 48 -1)). Figure K-1 in Annex K shows the number of bits1347
```
required to represent a given number of digits. If an all-numeric string contains more than 48 digits, then the first 48 are encoded as one1348
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 416 of 448
160-bit group, followed by the next group of up to 48 digits, and so on. Finally, the Binary values for each all-numeric data string in the1349
Object are themselves concatenated to form the Known-length-Numerics subsection.1350
I.8.2 Alphanumeric subsection of the data section1351
```
The Alphanumeric (A/N) subsection, if present, encodes all of the Packed Object’s data from any data strings that were not already encoded1352
```
in the Known-length Numerics subsection. If there are no alphanumeric characters to encode, the entire A/N subsection is omitted. The1353
Alphanumeric subsection can encode any mix of digits and non-digit ASCII characters, or eight-bit data. The digit characters within this data1354
are encoded separately, at an average efficiency of 4.322 bits per digit or better, depending on the character sequence. The non-digit1355
```
characters are independently encoded at an average efficiency that varies between 5.91 bits per character or better (all uppercase letters),1356
```
```
to a worst-case limit of 9 bits per character (if the character mix requires Base 256 encoding of non-numeric characters).1357
```
```
An Alphanumeric subsection consists of a series of A/N Header bits (see I.8.2.1), followed by from one to four Binary segments (each1358
```
```
segment representing data encoded in a single numerical Base, such as Base 10 or Base 30, see I.8.2.4), padded if necessary to complete1359
```
```
the final byte (see I 8.2.5).1360
```
A/N Header Bits1361
The A/N Header Bits are defined as follows:1362
■ One or two Non-Numeric Base bits, as follows:1363
```
□ ‘0’ indicates that Base 30 was chosen for the non-numeric Base;1364
```
```
□ ‘10’ indicates that Base 74 was chosen for the non-numeric Base;1365
```
□ ‘11’ indicates that Base 256 was chosen for the non-numeric Base1366
```
■ Either a single ‘0’ bit (indicating that no Character Map Prefix is encoded), or a ‘1’ bit followed by one or more "Runs" of six Prefix bits as defined1367
```
in I.8.2.3.1368
```
■ Either a single ‘0’ bit (indicating that no Character Map Suffix is encoded), or a ‘1’ bit followed by one or more "Runs" of six Suffix bits as defined1369
```
in I.8.2.3.1370
```
■ A variable-length "Character Map" bit pattern (see I.8.2.2), representing the base of each of the data characters, if any, that were not accounted1371
```
for by a Prefix or Suffix.1372
Dual-base Character-map encoding1373
```
Compaction of the ordered list of alphanumeric data strings (excluding those data strings already encoded in the Known-Length Numerics1374
```
```
subsection) is achieved by first concatenating the data characters into a single data string (the individual string lengths have already been1375
```
```
recorded in the Aux Format section). Each of the data characters is classified as either Base 10 (for numeric digits), Base 30 non-numerics1376
```
```
(primarily uppercase A-Z), Base 74 non-numerics (which includes both uppercase and lowercase alphas, and other ASCII characters), or1377
```
Base 256 characters. These character sets are fully defined in Annex K. All characters from the Base 74 set are also accessible from Base 301378
```
via the use of an extra "shift" value (as are most of the lower 128 characters in the Base 256 set). Depending on the relative percentage of1379
```
"native" Base 30 values vs. other values in the data string, one of those bases is selected as the more efficient choice for a non-numeric1380
base.1381
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 417 of 448
Next, the precise sequence of numeric and non-numeric characters is recorded and encoded, using a variable-length bit pattern, called a1382
```
"character map," where each ‘0’ represents a Base 10 value (encoding a digit) and each ‘1’ represents a value for a non-numeric character1383
```
```
(in the selected base). Note that, (for example) if Base 30 encoding was selected, each data character (other than uppercase letters and the1384
```
```
space character) needs to be represented by a pair of base-30 values, and thus each such data character is represented by a pair of ‘1’ bits1385
```
in the character map.1386
Prefix and Suffix Run-Length encoding1387
For improved efficiency in cases where the concatenated sequence includes runs of six or more values from the same base, provision is1388
```
made for optional run-length representations of one or more Prefix or Suffix "Runs" (single-base character sequences), which can replace1389
```
```
the first and/or last portions of the character map. The encoder shall not create a Run that separates a Shift value from its next (shifted)1390
```
value, and thus a Run always represents an integral number of source characters.1391
An optional Prefix Representation, if present, consists of one or more occurrences of a Prefix Run. Each Prefix Run consists of one Run1392
Position bit, followed by two Basis Bits, then followed by three Run Length bits, defined as follows:1393
```
■ The Run Position bit, if ‘0’, indicates that at least one more Prefix Run is encoded following this one (representing another set of source characters1394
```
```
to the right of the current set). The Run Position bit, if ‘1’, indicates that the current Prefix Run is the last (rightmost) Prefix Run of the A/N1395
```
subsection.1396
■ The first basis bit indicates a choice of numeric vs. non-numeric base, and the second basis bit, if ‘1’, indicates that the chosen base is extended1397
```
to include characters from the "opposite" base. Thus, ‘00’ indicates a run-length-encoded sequence of base 10 values; ‘01’ indicates a sequence1398
```
```
that is primarily (but not entirely) digits, encoded in Base 13; ‘10’ indicates a sequence a sequence of values from the non-numeric base that was1399
```
selected earlier in the A/N header, and ‘11’ indicates a sequence of values primarily from that non-numeric base, but extended to include digit1400
characters as well. Note an exception: if the non-numeric base that was selected in the A/N header is Base 256, then the "extended" version is1401
defined to be Base 40.1402
■ The 3-bit Run Length value assumes a minimum useable run of six same-base characters, and the length value is further divided by 2. Thus, the1403
possible 3-bit Run Length values of 0, 1, 2, … 7 indicate a Run of 6, 8, 10, … 20 characters from the same base. Note that a trailing "odd"1404
character value at the end of a same-base sequence must be represented by adding a bit to the Character Map.1405
An optional Suffix Representation, if present, is a series of one or more Suffix Runs, each identical in format to the Prefix Run just1406
```
described. Consistent with that description, note that the Run Position bit, if ‘1’, indicates that the current Suffix Run is the last (rightmost)1407
```
Suffix Run of the A/N subsection, and thus any preceding Suffix Runs represented source characters to the left of this final Suffix Run.1408
Encoding into Binary Segments1409
Immediately after the last bit of the Character Map, up to four binary numbers are encoded, each representing all of the characters that1410
```
were encoded in a single base system. First, a base-13 bit sequence is encoded (if one or more Prefix or Suffix Runs called for base-131411
```
```
encoding). If present, this bit sequence directly represents the binary number resulting from encoding the combined sequence of all Prefix1412
```
```
and Suffix characters (in that order) classified as Base 13 (ignoring any intervening characters not thus classified) as a single value, or in1413
```
other words, applying a base 13 to Binary conversion. The number of bits to encode in this sequence is directly determined from the1414
number of base-13 values being represented, as called for by the sum of the Prefix and Suffix Run lengths for base 13 sequences. The1415
number of bits, for a given number of Base 13 values, is determined from the Figure in Annex K. Next, an Extended-NonNumeric Base1416
```
segment (either Base-40 or Base 84) is similarly encoded (if any Prefix or Suffix Runs called for Extended-NonNumeric encoding).1417
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 418 of 448
Next, a Base-10 Binary segment is encoded that directly represents the binary number resulting from encoding the sequence of the digits in1418
```
the Prefix and/or character map and/or Suffix (ignoring any intervening non-digit characters) as a single value, or in other words, applying1419
```
a base 10 to Binary conversion. The number of bits to encode in this sequence is directly determined from the number of digits being1420
represented, as shown in Annex K.1421
```
Immediately after the last bit of the Base-10 bit sequence (if any), a non-numeric (Base 30, Base 74, or Base 256) bit sequence is encoded1422
```
```
(if the character map indicates at least one non-numeric character). This bit sequence represents the binary number resulting from a base-1423
```
```
30 to Binary conversion (or a Base-74 to Binary conversion, or a direct transfer of Base-256 values) of the sequence of non-digit characters1424
```
```
in the data (ignoring any intervening digits). Again, the number of encoded bits is directly determined from the number of non-numeric1425
```
values being represented, as shown in Annex K. Note that if Base 256 was selected as the non-Numeric base, then the encoder is free to1426
```
classify and encode each digit either as Base 10 or as Base 256 (Base 10 will be more efficient, unless outweighed by the ability to take1427
```
```
advantage of a long Prefix or Suffix).1428
```
```
Note that an Alphanumeric subsection ends with several variable-length bit fields (the character map, and one or more Binary sections1429
```
```
(representing the numeric and non-numeric Binary values). Note further that none of the lengths of these three variable-length bit fields are1430
```
```
explicitly encoded (although one or two Extended-Base Binary segments may also be present, these have known lengths, determined from1431
```
```
Prefix and/or Suffix runs). In order to determine the boundaries between these three variable-length fields, the decoder needs to implement1432
```
a procedure, using knowledge of the remaining number of daIa bits, in order to correctly parse the Alphanumeric subsection. An example of1433
such a procedure is described in Annex M.1434
Padding the last Byte1435
```
The last (least-significant) bit of the final Binary segment is also the last significant bit of the Packed Object. If there are any remaining bit1436
```
positions in the last byte to be filled with pad bits, then the most significant pad bit shall be set to ‘1’, and any remaining less-significant pad1437
bits shall be set to ‘0’. The decoder can determine the total number of non-pad bits in a Packed Object by examining the Length Section of1438
```
the Packed Object (and if the Pad Indicator bit of that section is ‘1’, by also examining the last byte of the Packed Object).1439
```
I.9 ID Map and Directory encoding options1440
An ID Map can be more efficient than a list of ID Values, when encoding a relatively large number of ID Values. Additionally, an ID Map1441
```
representation is advantageous for use in a Directory Packed Object. The ID Map itself (the first major subsection of every ID Map section)1442
```
is structured identically whether in a Data or Directory IDMPO, but a Directory IDMPO’s ID Map section contains additional optional1443
subsections. The structure of an ID Map section, containing one or more ID Maps, is described in the section below, explained in terms of its1444
```
usage in a Data IDMPO; subsequent sections explain the added structural elements in a Directory IDMPO.1445
```
I.9.1 ID Map Section structure1446
An IDMPO represents ID Values using a structure called an ID Map section, containing one or more ID Maps. Each ID Value encoded in a1447
Data IDMPO is represented as a ‘1’ bit within an ID Map bit field, whose fixed length is equal to the number of entries in the corresponding1448
Base Table. Conversely, each ‘0’ in the ID Map Field indicates the absence of the corresponding ID Value. Since the total number of ‘1’ bits1449
within the ID Map Field equals the number of ID Values being represented, no explicit NumberOfIDs field is encoded. In order to implement1450
the range of functionality made possible by this representation, the ID Map Section contains elements other than the ID Map itself. If1451
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 419 of 448
```
present, the optional ID Map Section immediately follows the leading pattern indicating an IDMPO (as was described in I.4.2), and contains1452
```
the following elements in the order listed below:1453
```
■ An Application Indicator subsection (see I.5.3)1454
```
```
■ an ID Map bit field (whose length is determined from the ID Size in the Application Indicator)1455
```
```
■ a Full/Restricted Use bit (see I.5.3)1456
```
```
■ (the above sequence forms an ID Map, which may optionally repeat multiple times)1457
```
■ a Data/Directory indicator bit,1458
```
■ an optional AuxMap section (never present in a Data IDMPO), and1459
```
```
■ Closing Flag(s), consisting of an "Addendum Flag" bit. If ‘1’, then an Addendum subsection is present at the end of the Object Info section (after1460
```
```
the Object Length Information).1461
```
```
These elements, shown in the table below as a maximum structure (every element is present), are described in each of the next1462
```
subsections.1463
Table I.9.1-1 ID Map section1464
First ID Map Optional additional ID
```
Map(s)
```
Null App
Indicator
```
(single zero
```
```
bit)
```
Data/
Directory
Indicator Bit
```
(If directory)
```
Optional
AuxMap
Section
Closing Flag
```
Bit(s)
```
App
Indicator
ID Map
Bit
Field
```
(ends
```
with
```
F/R bit)
```
App
Indicator
ID Map
Field
```
(ends with
```
```
F/R bit)
```
See I.5.3 See
I.9.1
and
I.5.3
As
previous
As
previous
See I.5.3 See I.9.2 Addendum
Flag Bit
When an ID Map section is encoded, it is always followed by an Object Length and Pad Indicator, and optionally followed by an Addendum1465
```
subsection (all as have been previously defined), and then may be followed by any of the other sections defined for Packed Objects, except1466
```
that a Directory IDMPO shall not include a Data section.1467
ID Map and ID Map bit field1468
An ID Map usually consists of an Application Indicator followed by an ID Map bit field, ending with a Full/Restricted Use bit. An ID Map bit1469
```
field consists of a single "MapPresent" flag bit, then (if MapPresent is ‘1’) a number of bits equal to the length determined from the ID Size1470
```
```
pattern within the Application Indicator, plus one (the Full/Restricted Use bit). The ID Map bit field indicates the presence/absence of1471
```
encoded data items corresponding to entries in a specific registered Primary or Alternate Base Table. The choice of base table is indicated by1472
the encoded combination of DSFID and Application Indicator pattern that precedes the ID Map bit field. The MSB of the ID Map bit field1473
corresponds to ID Value 0 in the base table, the next bit corresponds to ID Value 1, and so on.1474
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 420 of 448
In a Data Packed Object’s ID Map bit field, each ‘1’ bit indicates that this Packed Object contains an encoded occurrence of the data item1475
corresponding to an entry in the registered Base Table associated with this ID Map. Note that the valid encoded entry may be found either1476
```
in the first ("parentless") Packed Object of the chain (the one containing the ID Map) or in an Addendum IDLPO of that chain. Note further1477
```
```
that one or more data entries may be encoded in an IDMPO, but marked "invalid" (by a Delete entry in an Addendum IDLPO).1478
```
An ID Map shall not correspond to a Secondary ID Table instead of a Base ID Table. Note that data items encoded in a "parentless" Data1479
IDMPO shall appear in the same relative order in which they are listed in the associated Base Table. However, additional "out of order" data1480
items may be added to an existing data IDMPO by appending an Addendum IDLPO to the Object.1481
```
An ID Map cannot indicate a specific number of instances (greater than one) of the same ID Value, and this would seemingly imply that only1482
```
one data instance using a given ID Value can be encoded in a Data IDMPO. However, the ID Map method needs to support the case where1483
```
more two or more encoded data items are from the same identifier "class" (and thus share the same ID Value). The following mechanisms1484
```
address this need:1485
■ Another data item of the same class can be encoded in an Addendum IDLPO of the IDMPO. Multiple occurrences of the same ID Value can appear1486
on an ID List, each associated with different encoded values of the Secondary ID bits.1487
```
■ A series of two or more encoded instances of the same "class" can be efficiently indicated by a single instance of an ID Value (or equivalently by a1488
```
```
single ID Map bit), if the corresponding Base Table entry defines a "Repeat" Bit (see J.2.2).1489
```
```
An ID Map section may contain multiple ID Maps; a null Application Indicator section (with its AppIndicatorPresent bit set to ‘0’) terminates1490
```
the list of ID Maps.1491
Data/Directory and AuxMap indicator bits1492
A Data/Directory indicator bit is always encoded immediately following the last ID Map. By definition, a Data IDMPO has its Data/Directory1493
bit set to ‘0’, and a Directory IDMPO has its Data/Directory bit set to ‘1’. If the Data/Directory bit is set to ‘1’, it is immediately followed by1494
an AuxMap indicator bit which, if ‘1’, indicates that an optional AuxMap section immediately follows.1495
```
Closing Flags bit(s)1496
```
The ID Map section ends with a single Closing Flag:1497
■ The final bit of the Closing Flags is an Addendum Flag Bit which, if ‘1’, indicates that there is an optional Addendum subsection encoded at the1498
end of the Object Info section of the Packed Object. If present, the Addendum subsection is as described in Section I.5.6.1499
I.9.2 Directory Packed Objects1500
A "Directory Packed Object" is an IDMPO whose Directory bit is set to ‘1’. Its only inherent difference from a Data IDMPO is that it does not1501
contain any encoded data items. However, additional mechanisms and usage considerations apply only to a Directory Packed Object, and1502
these are described in the following subsections.1503
ID Maps in a Directory IDMPO1504
Although the structure of an ID Map is identical whether in a Data or Directory IDMPO, the semantics of the structure are somewhat1505
different. In a Directory Packed Object’s ID Map bit field, each ‘1’ bit indicates that a Data Packed Object in the same data carrier memory1506
bank contains a valid data item associated with the corresponding entry in the specified Base Table for this ID Map. Optionally, a Directory1507
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 421 of 448
```
Packed Object may further indicate which Packed Object contains each data item (see the description of the optional AuxMap section1508
```
```
below).1509
```
Note that, in contrast to a Data IDMPO, there is no required correlation between the order of bits in a Directory’s ID Map and the order in1510
which these data items are subsequently encoded in memory within a sequence of Data Packed Objects.1511
```
Optional AuxMap Section (Directory IDMPOs only)1512
```
An AuxMap Section optionally allows a Directory IDMPO’s ID Map to indicate not only presence/absence of all the data items in this memory1513
bank of the tag, but also which Packed Object encodes each data item. If the AuxMap indicator bit is ‘1’, then an AuxMap section shall be1514
encoded immediately after this bit. If encoded, the AuxMap section shall contain one PO Index Field for each of the ID Maps that precede1515
this section. After the last PO Index Field, the AuxMap Section may optionally encode an ObjectOffsets list, where each ObjectOffset1516
generally indicates the number of bytes from the start of the previous Packed Object to the start of the next Packed Object. This AuxMap1517
```
structure is shown (for an example IDMPO with two ID Maps) in the table below.1518
```
Table I.9.2-1 Optional AuxMap section structure1519
PO Index Field
for first ID Map
PO Index Field
for second ID Map
Object
Offsets
Present
bit
Optional ObjectOffsets subsection
POindex
Length
POindex
Table
POindex
Length
POindex
Table
Object
Offsets
Multiplier
Object1
offset
```
(EBV6)
```
Object2
offset
```
(EBV6)
```
… ObjectN
offset
```
(EBV6)
```
Each PO Index Field has the following structure and semantics:1520
■ A three-bit POindexLength field, indicating the number of index bits encoded for each entry in the PO Index Table that immediately follows this1521
```
field (unless the POindex length is ‘000’, which means that no PO Index Table follows).1522
```
```
■ A PO Index Table, consisting of an array of bits, one bit (or group of bits, depending on the POIndexLength) for every bit in the corresponding ID1523
```
```
Map of this directory Packed Object. A PO Index Table entry (i.e., a "PO Index") indicates (by relative order) which Packed Object contains the1524
```
data item indicated by the corresponding ‘1’ bit in the ID Map. If an ID Map bit is '0', the corresponding PO Index Table entry is present but its1525
contents are ignored.1526
■ Every Packed Object is assigned an index value in sequence, without regard as to whether it is a "parentless" Packed Object or a "child" of1527
another Packed Object, or whether it is a Data or Directory Packed Object.1528
```
■ If the PO Index is within the first PO Index Table (for the associated ID Map) of the Directory "chain", then:1529
```
□ a PO Index of zero refers to the first Packed Object in memory,1530
□ a value of one refers to the next Packed Object in memory, and so on1531
```
□ a value of m, where m is the largest value that can be encoded in the PO Index (given the number of bits per index that was set in1532
```
```
the POindexLength), indicates a Packed Object whose relative index (position in memory) is m or higher. This definition allows1533
```
Packed Objects higher than m to be indexed in an Addendum Directory Packed Object, as described immediately below. If no1534
Addendum exists, then the precise position is either m or some indeterminate position greater than m.1535
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 422 of 448
```
■ If the PO Index is not within the first PO Index Table of the directory chain for the associated ID Map (i.e., it is in an Addendum IDMPO), then:1536
```
□ a PO Index of zero indicates that a prior PO Index Table of the chain provided the index information,1537
```
□ a PO Index of n (n > 0) refers to the nth Packed Object above the highest index value available in the immediate parent directory1538
```
```
PO; e.g., if the maximum index value in the immediate parent directory PO refers to PO number "3 or greater," then a PO index of 11539
```
in this addendum refers to PO number 4.1540
```
□ A PO Index of m (as defined above) similarly indicates a Packed Object whose position is the mth position, or higher, than the limit1541
```
of the previous table in the chain.1542
■ If the valid instance of an ID Value is in an Addendum Packed Object, an implementation may choose to set a PO Index to point directly to that1543
Addendum, or may instead continue to point to the Packed Object in the chain that originally contained the ID Value.1544
```
NOTE: The first approach sometimes leads to faster searching; the second sometimes leads to faster directory updates.1545
```
```
After the last PO Index Field, the AuxMap section ends with (at minimum) a single "ObjectOffsets Present" bit. A‘0’ value of this bit indicates1546
```
that no ObjectOffsets subsection is encoded. If instead this bit is a ‘1’, it is immediately followed by an ObjectOffsets subsection, which1547
```
holds a list of EBV-6 "offsets" (the number of octets between the start of a Packed Object and the start of the next Packed Object). If1548
```
present, the ObjectOffsets subsection consists of an ObjectOffsetsMultiplier followed by an Object Offsets list, defined as follows:1549
■ An EBV-6 ObjectOffsetsMultiplier, whose value, when multiplied by 6, sets the total number of bits reserved for the entire ObjectOffsets list. The1550
value of this multiplier should be selected to ideally result in sufficient storage to hold the offsets for the maximum number of Packed Objects1551
```
that can be indexed by this Directory Packed Object’s PO Index Table (given the value in the POIndexLength field, and given some estimated1552
```
```
average size for those Packed Objects).1553
```
■ a fixed-sized field containing a list of EBV-6 ObjectOffsets. The size of this field is exactly the number of bits as calculated from the1554
ObjectOffsetsMultiplier. The first ObjectOffset represents the start of the second Packed Object in memory, relative to the first octet of memory1555
```
(there would be little benefit in reserving extra space to store the offset of the first Packed Object). Each succeeding ObjectOffset indicates the1556
```
```
start of the next Packed Object (relative to the previous ObjectOffset on the list), and the final ObjectOffset on the list points to the all-zero1557
```
```
termination pattern where the next Packed Object may be written. An invalid offset of zero (EBV-6 pattern "000000") shall be used to terminate1558
```
the ObjectOffset list. If the reserved storage space is fully occupied, it need not include this terminating pattern.1559
■ In applications where the average Packed Object Length is difficult to predict, the reserved ObjectOffset storage space may sometimes prove to1560
be insufficient. In this case, an Addendum Packed Object can be appended to the Directory Packed Object. This Addendum Directory Packed1561
Object may contain null subsections for all but its ObjectOffsets subsection. Alternately, if it is anticipated that the capacity of the PO Index Table1562
will also eventually be exceeded, then the Addendum Packed Object may also contain one or more non-null PO Index fields. Note that in a given1563
instance of an AuxMap section, either a PO Index Table or an ObjectOffsets subsection may be the first to exceed its capacity. Therefore, the first1564
position referenced by an ObjectOffsets list in an Addendum Packed Object need not coincide with the first position referenced by the PO Index1565
Table of that same Addendum. Specifically, in an Addendum Packed Object, the first ObjectOffset listed is an offset referenced to the last1566
ObjectOffset on the list of the "parent" Directory Packed Object.1567
Usage as a Presence/Absence Directory1568
In many applications, an Interrogator may choose to read the entire contents of any data carrier containing one or more "target" data items1569
of interest. In such applications, the positional information of those data items within the memory is not needed during the initial reading1570
```
operations; only a presence/absence indication is needed at this processing stage. An ID Map can form a particularly efficient1571
```
Presence/Absence directory for denoting the contents of a data carrier in such applications. A full directory structure encodes the offset or1572
```
address (memory location) of every data element within the data carrier, which requires the writing of a large number of bits (typically 321573
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 423 of 448
```
bits or more per data item). Inevitably, such an approach also requires reading a large number of bits over the air, just to determine1574
```
whether an identifier of interest is present on a particular tag. In contrast, when only presence/absence information is needed, using an ID1575
Map conveys the same information using only one bit per data item defined in the data system. The entire ID Map can be typically1576
represented in 128 bits or less, and stays the same size as more data items are written to the tag.1577
A "Presence/Absence Directory" Packed Object is defined as a Directory IDMPO that does not contain a PO Index, and therefore provides no1578
encoded information as to where individual data items reside within the data carrier. A Presence/Absence Directory can be converted to an1579
```
"Indexed Directory" Packed Object (see I.9.2.4) by adding a PO Index in an Addendum Packed Object, as a "child" of the Presence/Absence1580
```
Packed Object.1581
Usage as an Indexed Directory1582
In many applications involving large memories, an Interrogator may choose to read a Directory section covering the entire memory’s1583
contents, and then issue subsequent Reads to fetch the "target" data items of interest. In such applications, the positional information of1584
those data items within the memory is important, but if many data items are added to a large memory over time, the directory itself can1585
grow to an undesirable size.1586
An ID Map, used in conjunction with an AuxMap containing a PO Index, can form a particularly-efficient "Indexed Directory" for denoting the1587
contents of an RFID tag, and their approximate locations as well. Unlike a full tag directory structure, which encodes the offset or address1588
```
(memory location) of every data element within the data carrier, an Indexed Directory encodes a small relative position or index indicating1589
```
which Packed Object contains each data element. An application designer may choose to also encode the locations of each Packed Object in1590
an optional ObjectOffsets subsection as described above, so that a decoding system, upon reading the Indexed Directory alone, can1591
calculate the start addresses of all Packed Objects in memory.1592
The utility of an ID Map used in this way is enhanced by the rule of most data systems that a given identifier may only appear once within a1593
single data carrier. This rule, when an Indexed Directory is utilised with Packed Object encoding of the data in subsequent objects, can1594
```
provide nearly-complete random access to reading data using relatively few directory bits. As an example, an ID Map directory (one bit per1595
```
```
defined ID) can be associated with an additional AuxMap "PO Index" array (using, for example, three bits per defined ID). Using this1596
```
arrangement, an interrogator would read the Directory Packed Object, and examine its ID Map to determine if the desired data item were1597
present on the tag. If so, it would examine the 3 "PO Index" bits corresponding to that data item, to determine which of the first 8 Packed1598
Objects on the tag contain the desired data item. If an optional ObjectOffsets subsection was encoded, then the Interrogator can calculate1599
```
the starting address of the desired Packed Object directly; otherwise, the interrogator may perform successive read operations in order to1600
```
fetch the desired Packed Object.1601
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 424 of 448
J Packed Objects ID tables1602
J.1 Packed Objects data format registration file structure1603
A Packed Objects registered Data Format file consists of a series of "Keyword lines" and one or more ID Tables. Blank lines may occur1604
anywhere within a Data Format File, and are ignored. Also, any line may end with extra blank columns, which are also ignored.1605
```
■ A Keyword line consists of a Keyword (which always starts with "K-") followed by an equals sign and a character string, which assigns a value to1606
```
that Keyword. Zero or more space characters may be present on either side of the equals sign. Some Keyword lines shall appear only once, at1607
the top of the registration file, and others may appear multiple times, once for each ID Table in the file.1608
```
■ An ID Table lists a series of ID Values (as defined in I.5.3). Each row of an ID Table contains a single ID Value (in a required "IDvalue" column),1609
```
```
and additional columns may associate Object IDs (OIDs), ID strings, Format strings, and other information with that ID Value. A registration file1610
```
always includes a single "Primary" Base ID Table, zero or more "Alternate" Base ID Tables, and may also include one or more Secondary ID1611
```
Tables (that are referenced by one or more Base ID Table entries).1612
```
To illustrate the file format, a hypothetical data system registration is shown in Figure J-1. In this hypothetical data system, each ID Value1613
is associated with one or more OIDs and corresponding ID strings. The following subsections explain the syntax shown in the Figure.1614
Figure I.9.2-1 Hypothetical Data Format registration file1615
K-Text = Hypothetical Data
Format 100
K-Version =
1.0
K-TableID = F100B0
K-RootOID =
```
urn:oid:1.0.12345.100
```
K-IDsize
= 16
IDvalue OIDs IDstring Explanation FormatString
0 99 1Z Legacy ID "1Z"
corresponds to OID
99, is assigned
IDval 0
14n
1 9%x30-33 7%x42-45 An OID in the range
90..93,
Corresponding to
ID 7B..7E
1*8an
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 425 of 448
```
2 (10)(20)(25)(3
```
```
7)
```
```
(A)(B)(C)(D) a commonly-used
```
set of IDs
```
(1n)(2n)(3n)(4n)
```
3 26/27 1A/2B Either 1A or 2B is
encoded, but not
both
10n / 20n
```
4 (30) [31] (2A) [3B] 2A is always
```
encoded, optionally
followed by 3B
```
(11n) [1*20n]
```
```
5 (40/41/42) (53)
```
[55]
```
(4A/4B/4C) (5D)
```
[5E]
One of A/B/C is
encoded, then D,
and optionally E
```
(1n/2n/3n) (4n) [5n]
```
```
6 (60/61/(64)[66
```
```
])
```
```
(6A /6B / (6C)
```
```
[6D])
```
Selections, one of
which includes an
Option
```
(1n / 2n / (3n][4n])
```
K-TableEnd = F100B0
J.1.1 File Header section1616
```
Keyword lines in the File Header (the first portion of every registration file) may occur in any order, and are as follows:1617
```
```
■ (Mandatory) K-Version = nn.nn, which the registering body assigns, to ensure that any future revisions to their registration are clearly1618
```
labelled.1619
```
■ (Optional) K-Interpretation = string, where the "string" argument shall be one of the following: "ISO-646", "UTF-8", "ECI-nnnnnn" (where1620
```
```
nnnnnn is a registered six-digit ECI number), ISO-8859-nn, or "UNSPECIFIED". The Default interpretation is "UNSPECIFIED". This keyword line1621
```
allows non-default interpretations to be placed on the octets of data strings that are decoded from Packed Objects.1622
```
■ (Optional) K-ISO15434=nn, where "nn" represents a Format Indicator (a two-digit numeric identifier) as defined in ISO/IEC 15434. This1623
```
keyword line allows receiving systems to optionally represent a decoded Packed Object as a fully-compliant ISO/IEC 15434 message. There is no1624
default value for this keyword line.1625
```
■ (Optional) K-AppPunc = nn, where nn represents (in decimal) the octet value of an ASCII character that is commonly used for punctuation in1626
```
this application. If this keyword line is not present, the default Application Punctuation character is the hyphen.1627
In addition, h may be included using the optional Keyword assignment line "K-text = string", and may appear zero or more times within a1628
File Header or Table Header, but not in an ID Table body.1629
J.1.2 Table Header section1630
```
One or more Table Header sections (each introducing an ID Table) follow the File Header section. Each Table Header begins with a K-1631
```
```
TableID keyword line, followed by a series of additional required and optional Keyword lines (which may occur in any order), as follows:1632
```
```
■ (Mandatory) K-TableID = FnnXnn, where Fnn represents the ISO-assigned Data Format number (where 'nn' represents one or more decimal1633
```
```
digits), and Xnn (where 'X' is either 'B' or 'S') is a registrant-assigned Table ID for each ID Table in the file. The first ID Table shall always be the1634
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 426 of 448
Primary Base ID Table of the registration, with a Table ID of "B0". As many as seven additional "Alternate" Base ID Tables may be included, with1635
higher sequential "Bnn" Table IDs. Secondary ID Tables may be included, with sequential Table IDs of the form "Snn".1636
```
■ (Mandatory) K-IDsize = nn. For a base ID table, the value nn shall be one of the values from the "Maximum number of Table Entries" column1637
```
```
of Table I 5-5. For a secondary ID table, the value nn shall be a power of two (even if not present in Table I 5-5.1638
```
```
■ (Optional) K-RootOID = urn:oid:i.j.k.ff where:1639
```
```
□ I, j, and k are the leading arcs of the OID (as many arcs as required) and1640
```
```
□ ff is the last arc of the Root OID (typically, the registered Data Format number)1641
```
If the K-RootOID keyword is not present, then the default Root OID is:1642
□ urn:oid:1.0.15961.ff, where "ff" is the registered Data Format number1643
```
■ Other optional Keyword lines: in order to override the file-level defaults (to set different values for a particular table), a Table Header may1644
```
invoke one or more of the Optional Keyword lines listed in for the File Header section.1645
The end of the Table Header section is the first non-blank line that does not begin with a Keyword. This first non-blank line shall list the1646
```
titles for every column in the ID Table that immediately follows this line; column titles are case-sensitive.1647
```
```
An Alternate Base ID Table, if present, is identical in format to the Primary Base ID Table (but usually represents a smaller choice of1648
```
```
identifiers, targeted for a specific application).1649
```
A Secondary ID Table can be invoked by a keyword in a Base Table’s OIDs column. A Secondary ID Table is equivalent to a single Selection1650
```
list (see J.3) for a single ID Value of a Base ID Table (except that a Secondary table uses K-Idsize to explicitly define the number of1651
```
```
Secondary ID bits per ID); the IDvalue column of a Secondary table lists the value of the corresponding Secondary ID bits pattern for each1652
```
row in the Secondary Table. An OIDs entry in a Secondary ID Table shall not itself contain a Selection list nor invoke another Secondary ID1653
Table.1654
J.1.3 ID Table section1655
Each ID table consists of a series of one or more rows, each row including a mandatory "IDvalue" column, several defined Optional columns1656
```
(such as "OIDs", "IDstring", and "FormatString"), and any number of Informative columns (such as the "Explanation" column in the1657
```
```
hypothetical example shown above).1658
```
Each ID Table ends with a required Keyword line of the form:1659
■ K-TableEnd = FnnXnn, where FnnXnn shall match the preceding K-TableID keyword line that introduced the table.1660
The syntax and requirements of all Mandatory and Optional columns shall be as described J.2.1661
J.2 Mandatory and optional ID table columns1662
Each ID Table in a Packed Objects registration shall include an IDvalue column, and may include other columns that are defined in this1663
```
specification as Optional, and/or Informative columns (whose column heading is not defined in this specification).1664
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 427 of 448
```
J.2.1 IDvalue column (Mandatory)1665
```
Each ID Table in a Packed Objects registration shall include an IDvalue column. The ID Values on successive rows shall increase1666
monotonically. However, the table may terminate before reaching the full number of rows indicated by the Keyword line containing K-1667
```
IDsize. In this case, a receiving system will assume that all remaining ID Values are reserved for future assignment (as if the OIDs column1668
```
```
contained the keyword "K-RFA"). If a registered Base ID Table does not include the optional OIDs column described below, then the IDvalue1669
```
shall be used as the last arc of the OID.1670
```
J.2.2 OIDs and IDstring columns (Optional)1671
```
```
A Packed Objects registration always assigns a final OID arc to each identifier (either a number assigned in the "OIDs" column as will be1672
```
```
described below, or if that column is absent, the IDvalue is assigned as the default final arc). The OIDs column is required rather than1673
```
```
optional, if a single IDvalue is intended to represent either a combination of OIDs or a choice between OIDs (one or more Secondary ID bits1674
```
```
are invoked by any entry that presents a choice of OIDs).1675
```
A Packed Objects registration may include an IDString column, which if present assigns an ASCII-string name for each OID. If no name is1676
```
provided, systems must refer to the identifier by its OID (see J.3). However, many registrations will be based on data systems that do have1677
```
an ASCII representation for each defined Identifier, and receiving systems may optionally output a representation based on those strings. If1678
so, the ID Table may contain a column indicating the IDstring that corresponds to each OID. An empty IDstring cell means that there is no1679
corresponding ASCII string associated with the OID. A non-empty IDstring shall provide a name for every OID invoked by the OIDs column1680
```
of that row (or a single name, if no OIDs column is present). Therefore, the sequence of combination and selection operations in an IDstring1681
```
shall exactly match those in the row’s OIDs column.1682
```
A non-empty OIDs cell may contain either a keyword, an ASCII string representing (in decimal) a single OID value, or a compound string1683
```
```
(in ABNF notation) that a defines a choice and/or a combination of OIDs. The detailed syntax for compound OID strings in this column1684
```
```
(which also applies to the IDstring column) is as defined in section J.3. Instead of containing a simple or compound OID representation, an1685
```
OIDs entry may contain one of the following Keywords:1686
■ K-Verbatim = OIDddBnn, where "dd" represents the chosen penultimate arc of the OID, and "Bnn" indicates one of the Base 10, Base 40, or1687
Base 74 encoding tables. This entry invokes a number of Secondary ID bits that serve two purposes:1688
□ They encode an ASCII identifier "name" that might not have existed at the time the table was registered. The name is encoded in1689
the Secondary ID bits section as a series of Base-n values representing the ASCII characters of the name, preceded by a four-bit1690
```
field indicating the number of Base-n values that follow (zero is permissible, in order to support RFA entries as described below).1691
```
□ The cumulative value of these Secondary ID bits, considered as a single unsigned binary integer and converted to decimal, is the1692
final "arc" of the OID for this "verbatim-encoded’ identifier.1693
■ K-Secondary = Snn, where "Snn" represents the Table ID of a Secondary ID Table in the same registration file. This is equivalent to a Base ID1694
```
Table row OID entry that contains a single Selection list (with no other components at the top level), but instead of listing these components in1695
```
the Base ID Table, each component is listed as a separate row in the Secondary ID Table, where each may be assigned a unique OID, ID string,1696
and FormatString.1697
■ K-Proprietary=OIDddPnn, where nn represents a fixed number of Secondary ID bits that encode an optional Enterprise Identifier indicating1698
```
who wrote the proprietary data (an entry of K-Proprietary=OIDddP0 indicates an "anonymous" proprietary data item).1699
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 428 of 448
```
■ K-RFA = OIDddBnn, where "Bnn" is as defined above for Verbatim encoding, except that "B0" is a valid assignment (meaning that no1700
```
```
Secondary ID bits are invoked). This keyword represents a Reserved for Future Assignment entry, with an option for Verbatim encoding of the1701
```
Identifier "name" once a name is assigned by the entity who registered this Data Format. Encoders may use this entry, with a four-bit "verbatim"1702
length of zero, until an Identifier "name" is assigned. A specific FormatString may be assigned to K-RFA entries, or the default a/n encoding may1703
be utilised.1704
```
Finally, any OIDs entry may end with a single "R" character (preceded by one or more space characters), to indicate that a "Repeat" bit1705
```
shall be encoded as the last Secondary ID bit invoked by the entry. If ‘1’, this bit indicates that another instance of this class of identifier is1706
```
also encoded (that is, this bit acts as if a repeat of the ID Value were encoded on an ID list). If ‘1’, then this bit is followed by another series1707
```
of Secondary ID bits, to represent the particulars of this additional instance of the ID Value.1708
An IDstring column shall not contain any of the above-listed Keyword entries, and an IDstring entry shall be empty when the corresponding1709
OIDs entry contains a Keyword.1710
```
J.2.3 FormatString column (Optional)1711
```
An ID Table may optionally define the data characteristics of the data associated with a particular identifier, in order to facilitate data1712
```
compaction. If present, the FormatString entry specifies whether a data item is all-numeric or alphanumeric (i.e., may contain characters1713
```
```
other than the decimal digits), and specifies either a fixed length or a variable length. If no FormatString entry is present, then the default1714
```
data characteristic is alphanumeric. If no FormatString entry is present, or if the entry does not specify a length, then any length >=1 is1715
permitted. Unless a single fixed length is specified, the length of each encoded data item is encoded in the Aux Format section of the Packed1716
Object, as specified in I.7.1717
If a given IDstring entry defines more than a single identifier, then the corresponding FormatString column shall show a format string for1718
```
each such identifier, using the same sequence of punctuation characters (disregarding concatenation) as was used in the corresponding1719
```
IDstring.1720
The format string for a single identifier shall be one of the following:1721
```
■ A length qualifier followed by "n" (for always-numeric data);1722
```
```
■ A length qualifier followed by "an" (for data that may contain non-digits); or1723
```
■ A fixed-length qualifier, followed by "n", followed by one or more space characters, followed by a variable-length qualifier, followed by "an".1724
```
A length qualifier shall be either null (that is, no qualifier present, indicating that any length >= 1 is legal), a single decimal number1725
```
```
(indicating a fixed length) or a length range of the form "i*j", where "I" represents the minimum allowed length of the data item, "j"1726
```
represents the maximum allowed length, and i <= j. In the latter case, if "j" is omitted, it means the maximum length is unlimited.1727
```
Data corresponding to an "n" in the FormatString are encoded in the KLN subsection; data corresponding to an "an" in the FormatString are1728
```
encoded in the A/N subsection.1729
When a given instance of the data item is encoded in a Packed Object, its length is encoded in the Aux Format section as specified in I.7.2.1730
The minimum value of the range is not itself encoded, but is specified in the ID Table’s FormatString column.1731
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 429 of 448
```
Example:1732
```
A FormatString entry of "3*6n" indicates an all-numeric data item whose length is always between three and six digits inclusive. A given1733
length is encoded in two bits, where ‘00’ would indicate a string of digits whose length is "3", and ‘11’ would indicate a string length of six1734
digits.1735
```
J.2.4 Interp column (Optional)1736
```
Some registrations may wish to specify information needed for output representations of the Packed Object’s contents, other than the1737
default OID representation of the arcs of each encoded identifier. If this information is invariant for a particular table, the registration file1738
may include keyword lines as previously defined. If the interpretation varies from row to row within a table, then an Interp column may be1739
```
added to the ID Table. This column entry, if present, may contain one or more of the following keyword assignments (separated by1740
```
```
semicolons), as were previously defined (see J.1.1 and J.1.2):1741
```
■ K-RootOID = urn:oid:i.j.k.l…1742
■ K-Interpretation = string1743
■ K-ISO15434=nn1744
```
If used, these override (for a particular Identifier) the default file-level values and/or those specified in the Table Header section.1745
```
J.3 Syntax of OIDs, IDstring, and FormatString Columns1746
In a given ID Table entry, the OIDs, IDString, and FormatString column may indicate one or more mechanisms described in this section.1747
J.3.1 specifies the semantics of the mechanisms, and J.3.2 specifies the formal grammar for the ID Table columns.1748
J.3.1 Semantics for OIDs, IDString, and FormatString Columns1749
```
In the descriptions below, the word "Identifier" means either an OID final arc (in the context of the OIDs column) or an IDString name (in1750
```
```
the context of the IDstring column). If both columns are present, only the OIDs column actually invokes Secondary ID bits.1751
```
■ A Single component resolving to a single Identifier, in which case no additional Secondary ID bits are invoked.1752
```
■ (For OIDs and IDString columns only) A single component resolving to one of a series of closely-related Identifiers, where the Identifier’s string1753
```
representation varies only at one or more character positions. This is indicated using the Concatenation operator ‘%’ to introduce a range of1754
ASCII characters at a specified position. For example, an OID whose final arc is defined as "391n", where the fourth digit ‘n’ can be any digit from1755
```
‘0’ to ‘6’ (ASCII characters 30 hex to 36hex inclusive) is represented by the component 391%x30-39 (note that no spaces are allowed). A1756
```
Concatenation invokes the minimum number of Secondary ID digits needed to indicate the specified range. When both an OIDs column and an1757
```
IDstring column are populated for a given row, both shall contain the same number of concatations, with the same ranges (so that the numbers1758
```
```
and values of Secondary ID bits invoked are consistent). However, the minimum value listed for the two ranges can differ, so that (for example)1759
```
the OID’s digit can range from 0 to 3, while the corresponding IDstring character can range from "B" to "E" if so desired. Note that the use of1760
Concatenation inherently constrains the relationship between OID and IDString, and so Concatenation may not be useable under all1761
```
circumstances (the Selection operation described below usually provides an alternative).1762
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 430 of 448
■ A Combination of two or more identifier components in an ordered sequence, indicated by surrounding each component of the sequence with1763
```
parentheses. For example, an IDstring entry (A)(%x30-37B)(2C) indicates that the associated ID Value represents a sequence of the following1764
```
three identifiers:1765
■ Identifier "A", then1766
```
■ An identifier within the range "0B" to "7B" (invoking three Secondary ID bits to represent the choice of leading character), then1767
```
■ Identifier "2C1768
```
Note that a Combination does not itself invoke any Secondary ID bits (unless one or more of its components do).1769
```
■ An Optional component is indicated by surrounding the component in brackets, which may viewed as a "conditional combination." For example1770
```
the entry (A) [B][C][D] indicates that the ID Value represents identifier A, optionally followed by B, C, and/or D. A list of Options invokes one1771
```
Secondary ID bit for each component in brackets, wherein a ‘1’ indicates that the optional component was encoded.1772
■ A Selection between several mutually-exclusive components is indicated by separating the components by forward slash characters. For example,1773
```
the IDstring entry (A/B/C/(D)(E)) indicates that the fully-qualified ID Value represents a single choice from a list of four choices (the fourth of1774
```
```
which is a Combination). A Selection invokes the minimum number of Secondary ID bits needed to indicate a choice from a list of the specified1775
```
number of components.1776
In general, a "compound" OIDs or IDstring entry may contain any or all of the above operations. However, to ensure that a single left-to-1777
```
right parsing of an OIDs entry results in a deterministic set of Secondary ID bits (which are encoded in the same left-to-right order in which1778
```
```
they are invoked by the OIDs entry), the following restrictions are applied:1779
```
```
■ A given Identifier may only appear once in an OIDs entry. For example, the entry (A)(B/A) is invalid1780
```
■ A OIDs entry may contain at most a single Selection list1781
```
■ There is no restriction on the number of Combinations (because they invoke no Secondary ID bits)1782
```
■ There is no restriction on the total number of Concatenations in an OIDs entry, but no single Component may contain more than two Concatenation1783
operators.1784
■ An Optional component may be a component of a Selection list, but an Optional component may not be a compound component, and therefore1785
shall not include a Selection list nor a Combination nor Concatenation.1786
```
■ A OIDs or IDstring entry may not include the characters ‘(’ , ‘)’, ‘[’ , ‘]’, ‘%’, ‘-’ , or ‘/’, unless used as an Operator as described above. If one of1787
```
these characters is part of a defined data system Identifier "name", then it shall be represented as a single literal Concatenated character.1788
J.3.2 Formal Grammar for OIDs, IDString, and FormatString Columns1789
In each ID Table entry, the contents of the OIDs, IDString, and FormatString columns shall conform to the following grammar for Expr,1790
```
unless the column is empty or (in the case of the OIDs column) it contains a keyword as specified in J.2.2. All three columns share the same1791
```
grammar, except that the syntax for COMPONENT is different for each column as specified below. In a given ID Table Entry, the contents of1792
```
the OIDs, IDString, and FormatString column (except if empty) shall have identical parse trees according to this grammar, except that the1793
```
```
COMPONENTs may be different. Space characters are permitted (and ignored) anywhere in an Expr, except that in the interior of a1794
```
COMPONENT spaces are only permitted where explicitly specified below.1795
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 431 of 448
```
Expr = SelectionExpr / "(" SelectionExpr ")" / SelectionSubexpr1796
```
1797
```
SelectionExpr = SelectionSubexpr 1*( "/" SelectionSubexpr )1798
```
1799
```
SelectionSubexpr = COMPONENT / ComboExpr1800
```
1801
```
ComboExpr = 1*ComboSubexpr1802
```
1803
```
ComboSubexpr = "(" COMPONENT ")" / "[" COMPONENT "]"1804
```
1805
For the OIDs column, COMPONENT shall conform to the following grammar:1806
```
COMPONENT_OIDs = 1*(COMPONENT_OIDs_Char / Concat)1807
```
1808
```
COMPONENT_OIDs_Char = 1*(%x30-39) ; 0-91809
```
1810
For the IDString column, COMPONENT shall conform to the following grammar:1811
```
COMPONENT_IDString = UnquotedIDString / QuotedIDString1812
```
1813
```
UnquotedIDString = 1*(UnQuotedIDStringChar / Concat)1814
```
1815
```
UnquotedIDStringChar = %x30-39 / %x41-5A / %x61-7A / "_" ; 0-9 A-Z a-z _1816
```
1817
```
QuotedIDString = QUOTE 1*QuotedIDStringConstituent QUOTE1818
```
1819
```
QuotedIDStringConstituent = " " / "!" / "#".."~" / (QUOTE QUOTE)1820
```
```
QUOTE = %x22 ; ASCII double quote1821
```
```
QUOTE refers to ASCII character 34 (decimal), the double quote character.1822
```
When the QuotedIDString form for COMPONENT_IDString is used, the beginning and ending QUOTE characters shall not be considered1823
```
part of the IDString. Between the beginning and ending QUOTE, all ASCII characters in the range 32 (decimal) through 126 (decimal),1824
```
inclusive, are allowed, except that two QUOTE characters in a row shall denote a single double-quote character to be included in the1825
IDString.1826
In the QuotedIDString form, a % character does not denote the concatenation operator, but instead is just a percent character included1827
literally in the IDString. To use the concatenation operator, the UnquotedIDString form must be used. In that case, a degenerate1828
```
concatenation operator (where the start character equals the end character) may be used to include a character into the IDString that is not1829
```
one of the characters listed for UnquotedIDStringChar.1830
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 432 of 448
For the FormatString column, COMPONENT shall conform to the following grammar:1831
```
COMPONENT_FormatString = 0*1Range ("an" / "n")1832
```
/ FixedRange "n" 1*" " VarRange "an"1833
1834
```
Range = FixedRange / VarRange1835
```
1836
```
FixedRange = Number1837
```
1838
```
VarRange = Number "*" 0*1(Number)1839
```
1840
```
Number = 1*(%x30-39) ; 0-91841
```
The syntax for COMPONENT for the OIDs and IDString columns make reference to Concat, whose syntax is specified as follows:1842
```
Concat = "%" "x" HexChar "-" HexChar1843
```
```
HexChar = (%x30-39 / %x41-46) ; 0-9 A-F1844
```
The hex value following the hyphen shall be greater than or equal to the hex value preceding the hyphen. In the OIDs column, each hex1845
value shall be in the range 30hex to 39 hex, inclusive. In the IDString column, each hex value shall be in the range 20 hex to 7E hex, inclusive.1846
J.4 OID input/output representation1847
The default method for representing the contents of a Packed Object to a receiving system is as a series of name/value pairs, where the1848
name is an OID, and the value is the decoded data string associated with that OID. Unless otherwise specified by a K-RootOID keyword1849
```
line, the default root OID is urn:oid:1.0.15961.ff, where ff is the Data Format encoded in the DSFID. The final arc of the OID is (by1850
```
```
default) the IDvalue, but this is typically overridden by an entry in the OIDs column. Note that an encoded Application Indicator (see I.5.3)1851
```
may change ff from the value indicated by the DSFID.1852
If supported by information in the ID Table’s IDstring column, a receiving system may translate the OID output into various alternative1853
formats, based on the IDString representation of the OIDs. One such format, as described in ISO/IEC 15434, requires as additional1854
```
information a two-digit Format identifier; a table registration may provide this information using the K-ISO15434 keyword as described1855
```
above.1856
The combination of the K-RootOID keyword and the OIDs column provides the registering entity an ability to assign OIDs to data system1857
identifiers without regard to how they are actually encoded, and therefore the same OID assignment can apply regardless of the access1858
method.1859
J.4.1 "ID Value OID" output representation1860
```
If the receiving system does not have access to the relevant ID Table (possibly because it is newly-registered), the Packed Objects decoder1861
```
```
will not have sufficient information to convert the IDvalue (plus Secondary ID bits) to the intended OID. In order to ease the introduction of1862
```
```
new or external tables, encoders have an option to follow "restricted use" rules (see I.5.3.1863
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 433 of 448
When a receiving system has decoded a Packed Object encoded following "restricted use" rules, but does not have access to the indicated1864
ID Table, it shall construct an "ID Value OID" in the following format:1865
```
urn:oid:1.0.15961.300.ff.bb.idval.secbits1866
```
where 1.0.15961.300 is a Root OID with a reserved Data Format of "300" that is never encoded in a DSFID, but is used to distinguish an1867
```
"ID Value OID" from a true OID (as would have been used if the ID Table were available). The reserved value of 300 is followed by the1868
```
```
encoded table’s Data Format (ff) (which may be different from the DSFID’s default), the table ID (bb) (always ‘0’, unless otherwise1869
```
```
indicated via an encoded Application Indicator), the encoded ID value, and the decimal representation of the invoked Secondary ID bits.1870
```
This process creates a unique OID for each unique fully-qualified ID Value. For example, using the hypothetical ID Table shown in Annex L1871
```
(but assuming, for illustration purposes, that the table’s specified Root OID is urn:oid:1.0.12345.9, then an "AMOUNT" ID with a fourth1872
```
digit of ‘2’ has a true OID of:1873
```
urn:oid:1.0.12345.9.39121874
```
and an "ID Value OID" of1875
```
urn:oid:1.0.15961.300.9.0.51.21876
```
When a single ID Value represents multiple component identifiers via combinations or optional components, their multiple OIDs and data1877
```
strings shall be represented separately, each using the same "ID Value OID" (up through and including the Secondary ID bits arc), but1878
```
```
adding as a final arc the component number (starting with "1" for the first component decoded under that IDvalue).1879
```
If the decoding system encounters a Packed Object that references an ID Table that is unavailable to the decoder, but the encoder chose1880
not to set the "Restricted Use" bit in the Application Indicator, then the decoder shall either discard the Packed Object, or relay the entire1881
Packed Object to the receiving system as a single undecoded binary entity, a sequence of octets of the length specified in the ObjectLength1882
field of the Packed Object. The OID for an undecoded Packed Object shall be urn:oid:1.0.15961.301.ff.n, where "301" is a Data Format1883
reserved to indicate an undecoded Packed Object, "ff" shall be the Data Format encoded in the DSFID at the start of memory, and an1884
optional final arc ‘n’ may be incremented sequentially to distinguish between multiple undecoded Packed Objects in the same data carrier1885
memory.1886
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 434 of 448
K Packed Objects encoding tables1887
Packed Objects primarily utilise two encoding bases:1888
■ Base 10, which encodes each of the digits ‘0’ through ‘9’ in one Base 10 value1889
■ Base 30, which encodes the capital letters and selectable punctuation in one Base-30 value, and encodes punctuation and control characters from1890
```
the remainder of the ASCII character set in two base-30 values (using a Shift mechanism)1891
```
For situations where a high percentage of the input data’s non-numeric characters would require pairs of base-30 values, two alternative1892
bases, Base 74 and Base 256, are also defined:1893
```
■ The values in the Base 74 set correspond to the invariant subset of ISO/IEC 646 [ISO646] (which includes the GS1 character set), but with the1894
```
```
digits eliminated, and with the addition of GS and <space> (GS is supported for uses other than as a data delimiter).1895
```
■ The values in the Base 256 set may convey octets with no graphical-character interpretation, or "extended ASCII values" as defined in ISO/IEC1896
```
8859-6 [ISO8859-6], or UTF-8 (the interpretation may be set in the registered ID Table for an application). The characters ‘0’ through ‘9’ (ASCII1897
```
```
values 48 through 57) are supported, and an encoder may therefore encode the digits either by using a prefix or suffix (in Base 256) or by using1898
```
```
a character map (in Base 10). Note that in GS1 data, FNC1 is represented by ASCII <GS> (octet value 29 dec).1899
```
Finally, there are situations where compaction efficiency can be enhanced by run-length encoding of base indicators, rather than by1900
character map bits, when a long run of characters can be classified into a single base. To facilitate that classification, additional "extension"1901
bases are added, only for use in Prefix and Suffix Runs.1902
■ In order to support run-length encoding of a primarily-numeric string with a few interspersed letters, a Base 13 is defined, per Table B-21903
```
■ Two of these extension bases (Base 40 and Base 84) are simply defined, in that they extend the corresponding non-numeric bases (Base 30 and1904
```
```
Base 74, respectively) to also include the ten decimal digits. The additional entries, for characters ‘0’ through ‘9’, are added as the next ten1905
```
```
sequential values (values 30 through 39 for Base 40, and values 74 through 83 for Base 84).1906
```
■ The "extended" version of Base 256 is defined as Base 40. This allows an encoder the option of encoding a few ASCII control or upper-ASCII1907
characters in Base 256, while using a Prefix and/or Suffix to more efficiently encode the remaining non-numeric characters.1908
The number of bits required to encode various numbers of Base 10, Base 16, Base 30, Base 40, Base 74, and Base 84 characters are shown1909
in Figure B-1. In all cases, a limit is placed on the size of a single input group, selected so as to output a group no larger than 20 octets.1910
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 435 of 448
Figure J.4.1-1 Required number of bits for a given number of Base ‘N’ values1911
/* Base10 encoding accepts up to 48 input values per group: */1912
```
static const unsigned char bitsForNumBase10[] = {1913
```
/* 0 - 9 */ 0, 4, 7, 10, 14, 17, 20, 24, 27, 30,1914
/* 10 - 19 */ 34, 37, 40, 44, 47, 50, 54, 57, 60, 64,1915
/* 20 - 29 */ 67, 70, 74, 77, 80, 84, 87, 90, 94, 97,1916
/* 30 - 39 */ 100, 103, 107, 110, 113, 117, 120, 123, 127, 130,1917
```
/* 40 - 48 */ 133, 137, 140, 143, 147, 150, 153, 157, 160};1918
```
1919
/* Base13 encoding accepts up to 43 input values per group: */1920
```
static const unsigned char bitsForNumBase13[] = {1921
```
/* 0 - 9 */ 0, 4, 8, 12, 15, 19, 23, 26, 30, 34,1922
/* 10 - 19 */ 38, 41, 45, 49, 52, 56, 60, 63, 67, 71,1923
/* 20 - 29 */ 75, 78, 82, 86, 89, 93, 97, 100, 104, 108,1924
/* 30 - 39 */ 112, 115, 119, 123, 126, 130, 134, 137, 141, 145,1925
```
/* 40 - 43 */ 149, 152, 156, 160 };1926
```
1927
/* Base30 encoding accepts up to 32 input values per group: */1928
```
static const unsigned char bitsForNumBase30[] = {1929
```
/* 0 - 9 */ 0, 5, 10, 15, 20, 25, 30, 35, 40, 45,1930
/* 10 - 19 */ 50, 54, 59, 64, 69, 74, 79, 84, 89, 94,1931
/* 20 - 29 */ 99, 104, 108, 113, 118, 123, 128, 133, 138, 143,1932
```
/* 30 - 32 */ 148, 153, 158};1933
```
1934
/* Base40 encoding accepts up to 30 input values per group: */1935
```
static const unsigned char bitsForNumBase40[] = {1936
```
/* 0 - 9 */ 0, 6, 11, 16, 22, 27, 32, 38, 43, 48,1937
/* 10 - 19 */ 54, 59, 64, 70, 75, 80, 86, 91, 96, 102,1938
/* 20 - 29 */ 107, 112, 118, 123, 128, 134, 139, 144, 150, 155,1939
```
/* 30 */ 160 };1940
```
1941
/* Base74 encoding accepts up to 25 input values per group: */1942
```
static const unsigned char bitsForNumBase74[] = {1943
```
/* 0 - 9 */ 0, 7, 13, 19, 25, 32, 38, 44, 50, 56,1944
/* 10 - 19 */ 63, 69, 75, 81, 87, 94, 100, 106, 112, 118,1945
```
/* 20 - 25 */ 125, 131, 137, 143, 150, 156 };1946
```
1947
/* Base84 encoding accepts up to 25 input values per group: */1948
```
static const unsigned char bitsForNumBase84[] = {1949
```
/* 0 - 9 */ 0, 7, 13, 20, 26, 32, 39, 45, 52, 58,1950
/* 10 - 19 */ 64, 71, 77, 84, 90, 96, 103, 109, 116, 122,1951
```
/* 20 - 25 */ 128, 135, 141, 148, 154, 160 };1952
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 436 of 448
Table J.4.1-1 Base 30 Character set1953
Val Basic set Shift 1 set Shift 2 set
Char Decimal Char Decimal Char Decimal
0 A-Punc1 N/A NUL 0 space 32
1 A 65 SOH 1 ! 33
2 B 66 STX 2 " 34
3 C 67 ETX 3 # 35
4 D 68 EOT 4 $ 36
5 E 69 ENQ 5 % 37
6 F 70 ACK 6 & 38
7 G 71 BEL 7 ‘ 39
```
8 H 72 BS 8 ( 40
```
```
9 I 73 HT 9 ) 41
```
10 J 74 LF 10 * 42
11 K 75 VT 11 + 43
12 L 76 FF 12 , 44
13 M 77 CR 13 - 45
14 N 78 SO 14 . 46
15 O 79 SI 15 / 47
16 P 80 DLE 16 : 58
```
17 Q 81 ETB 23 ; 59
```
18 R 82 ESC 27 < 60
19 S 83 FS 28 = 61
20 T 84 GS 29 > 62
21 U 85 RS 30 ? 63
22 V 86 US 31 @ 64
23 W 87 invalid N/A \ 92
24 X 88 invalid N/A ^ 94
25 Y 89 invalid N/A _ 95
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 437 of 448
Val Basic set Shift 1 set Shift 2 set
26 Z 90 [ 91 ‘ 96
27 Shift 1 N/A ] 93 | 124
```
28 Shift 2 N/A { 123 ~ 126
```
```
29 P-Punc2 N/A } 125 invalid N/A
```
```
Note 1: Application-Specified Punctuation character (Value 0 of the Basic set) is defined by default as the ASCII hyphen character1954
```
```
(45dec), but may be redefined by a registered Data Format1955
```
```
Note 2: Programmable Punctuation character (Value 29 of the Basic set): the first appearance of P-Punc in the alphanumeric data for a1956
```
Packed Object, whether that first appearance is compacted into the Base 30 segment or the Base 40 segment, acts as a <Shift 2>, and also1957
```
"programs" the character to be represented by second and subsequent appearances of P-Punc (in either segment) for the remainder of the1958
```
alphanumeric data in that Packed Object. The Base 30 or Base 40 value immediately following that first appearance is interpreted using the1959
```
Shift 2 column (Punctuation), and assigned to subsequent instances of P-Punc for the Packed Object.1960
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 438 of 448
Table J.4.1-2 Base 13 Character set1961
Value Basic set Shift 1 set Shift 2 set Shift 3 set
Char Decimal Char Decimal Char Decimal Char Decimal
0 0 48 A 65 N 78 space 32
1 1 49 B 66 O 79 $ 36
2 2 50 C 67 P 80 % 37
3 3 51 D 68 Q 81 & 38
4 4 52 E 69 R 82 * 42
5 5 53 F 70 S 83 + 43
6 6 54 G 71 T 84 , 44
7 7 55 H 72 U 85 - 45
8 8 56 I 73 V 86 . 46
9 9 57 J 74 W 87 / 47
10 Shift1 N/A K 75 X 88 ? 63
11 Shift2 N/A L 76 Y 89 _ 95
12 Shift3 N/A M 77 Z 90 <GS> 29
Table J.4.1-3 Base 40 Character set1962
Val Basic set Shift 1 set Shift 2 set
Char Decimal Char Decimal Char Decimal
0 See Table K-1
… …
29 See Table K-1
30 0 48
31 1 49
32 2 50
33 3 51
34 4 52
35 5 53
36 6 54
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 439 of 448
Val Basic set Shift 1 set Shift 2 set
37 7 55
38 8 56
39 9 57
Table J.4.1-4 Character Set1963
Val Char Decimal Val Char Decimal Val Char Decimal
0 GS 29 25 F 70 50 d 100
1 ! 33 26 G 71 51 e 101
2 " 34 27 H 72 52 f 102
3 % 37 28 I 73 53 g 103
4 & 38 29 J 74 54 h 104
5 ' 39 30 K 75 55 i 105
```
6 ( 40 31 L 76 56 j 106
```
```
7 ) 41 32 M 77 57 k 107
```
8 * 42 33 N 78 58 l 108
9 + 43 34 O 79 59 m 109
10 , 44 35 P 80 60 n 110
11 - 45 36 Q 81 61 o 111
12 . 46 37 R 82 62 p 112
13 / 47 38 S 83 63 q 113
14 : 58 39 T 84 64 r 114
```
15 ; 59 40 U 85 65 s 115
```
16 < 60 41 V 86 66 t 116
17 = 61 42 W 87 67 u 117
18 > 62 43 X 88 68 v 118
19 ? 63 44 Y 89 69 w 119
20 A 65 45 Z 90 70 x 120
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 440 of 448
Val Char Decimal Val Char Decimal Val Char Decimal
21 B 66 46 _ 95 71 y 121
22 C 67 47 a 97 72 z 122
23 D 68 48 b 98 73 Space 32
24 E 69 49 c 99
Table J.4.1-5 Base 84 Character Set1964
Val Char Decimal Val Char Decimal Val Char Decimal
0 FNC1 N/A 25 F 50 d
1-73 See Table K-4
74 0 48 78 4 52 82 8 56
75 1 49 79 5 53 83 9 57
76 2 50 80 6 54
77 3 51 81 7 55
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 441 of 448
```
L Encoding Packed Objects (non-normative)1965
```
In order to illustrate a number of the techniques that can be invoked when encoding a Packed Object, the following sample input data1966
consists of data elements from a hypothetical data system. This data represents:1967
```
■ An Expiration date (OID 7) of October 31, 2006, represented as a six-digit number 061031.1968
```
```
■ An Amount Payable (OID 3n) of 1234.56 Euros, represented as a digit string 978123456 ("978" is the ISO Country Code indicating that the1969
```
```
amount payable is in Euros). As shown in Table L-1, this data element is all-numeric, with at least 4 digits and at most 18 digits. In this example,1970
```
the OID "3n" will be "32", where the "2" in the data element name indicates the decimal point is located two digits from the right.1971
```
■ A Lot Number (OID 1) of 1A23B456CD1972
```
The application will present the above input to the encoder as a list of OID/Value pairs. The resulting input data, represented below as a1973
```
single data string (wherein each OID final arc is shown in parentheses) is:1974
```
```
(7)061031(32)978123456(1)1A23B456CD1975
```
```
The example uses a hypothetical ID Table. In this hypothetical table, each ID Value is a seven-bit index into the Base ID Table; the entries1976
```
relevant to this example are shown in Table L-1.1977
Encoding is performed in the following steps:1978
■ Three data elements are to be encoded, using Table L-1.1979
```
■ As shown in the table’s IDstring column, the combination of OID 7 and OID 1 is efficiently supported (because it is commonly seen in1980
```
```
applications), and thus the encoder re-orders the input so that 7 and 1 are adjacent and in the order indicated in the OIDs column:1981
```
```
■ (7)061031(1)1A23B456CD(32)9781234561982
```
```
■ Now, this OID pair can be assigned a single ID Value of 125 (decimal). The FormatString column for this entry shows that the encoded data will1983
```
always consist of a fixed-length 6-digit string, followed by a variable-length alphanumeric string.1984
```
■ Also as shown in Table L-1, OID 3n has an ID Value of 51 (decimal). The OIDs column for this entry shows that the OID is formed by1985
```
```
concatenating "3" with a suffix consisting of a single character in the range 30 hex to 39hex (i.e., a decimal digit). Since that is a range of ten1986
```
possibilities, a four-bit number will need to be encoded in the Secondary ID section to indicate which suffix character was chosen. The1987
```
FormatString column for this entry shows that its data is variable-length numeric; the variable length information will require four bits to be1988
```
encoded in the Aux Format section.1989
■ Since only a small percentage of the 128-entry ID Table is utilised in this Packed Object, the encoder chooses an ID List format, rather than an ID1990
Map format. As this is the default format, no Format Flags section is required.1991
■ This results in the following Object Info section:1992
```
□ EBV-6 (ObjectLength): the value is TBD at this stage of the encoding process1993
```
□ Pad Indicator bit: TBD at this stage1994
```
□ EBV-3 (numberOfIDs) of 001 (meaning two ID Values will follow)1995
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 442 of 448
□ An ID List, including:1996
- First ID Value: 125 (dec) in 7 bits, representing OID 7 followed by OID 11997
- Second ID Value: 51 (decimal) in 7 bits, representing OID 3n1998
■ A Secondary ID section is encoded as ‘0010’, indicating the trailing ‘2’ of the 3n OID. It so happens this ‘2’ means that two digits follow the1999
implied decimal point, but that information is not needed in order to encode or decode the Packed Object.2000
■ Next, an Aux Format section is encoded. An initial ‘1’ bit is encoded, invoking the Packed-Object compaction method. Of the three OIDs, only OID2001
```
(3n) requires encoded Aux Format information: a four-bit pattern of ‘0101’ (representing "six" variable-length digits – as "one" is the first allowed2002
```
```
choice, a pattern of "0101" denotes "six").2003
```
■ Next, the encoder encodes the first data item, for OID 7, which is defined as a fixed-length six-digit data item. The six digits of the source data2004
```
string are "061031", which are converted to a sequence of six Base-10 values by subtracting 30 hex from each character of the string (the resulting2005
```
```
values are denoted as values v 5 through v 0 in the formula below). These are then converted to a single Binary value, using the following formula:2006
```
□ 105 * v 5 + 104 * v 4 + 103 * v 3 + 102 * v2 + 101 * v 1+ 100 * v 02007
```
According to Figure K-1, a six-digit number is always encoded into 20 bits (regardless of any leading zero’s in the input), resulting in a2008
```
Binary string of:2009
"0000 11101110 01100111"2010
■ The next data item is for OID 1, but since the table indicates that this OID’s data is alphanumeric, encoding into the Packed Object is deferred2011
until after all of the known-length numeric data is encoded.2012
```
■ Next, the encoder finds that OID 3n is defined by Table L-1 as all-numeric, whose length of 9 (in this example) was encoded as (9 – 4 = 5) into2013
```
four bits within the Aux Format subsection. Thus, a Known-Length-Numeric subsection is encoded for this data item, consisting of a binary value2014
bit-pattern encoding 9 digits. Using Figure K-1 in Annex K, the encoder determines that 30 bits need to be encoded in order to represent a 9-digit2015
number as a binary value. In this example, the binary value equivalent of "978123456" is the 30-bit binary sequence:2016
"111010010011001111101011000000"2017
■ At this point, encoding of the Known-Length Numeric subsection of the Data Section is complete.2018
```
Note that, so far, the total number of encoded bits is (3 + 6 + 1 + 7 + 7 + 4 + 5 + 20 + 30) or 83 bits, representing the IDLPO Length2019
```
```
Section (assuming that a single EBV-6 vector remains sufficient to encode the Packed Object’s length), two 7-bit ID Values, the Secondary2020
```
ID and Aux Format sections, and two Known-Length-Numeric compacted binary fields.2021
```
At this stage, only one non-numeric data string (for OID 1) remains to be encoded in the Alphanumeric subsection. The 10-character source2022
```
data string is "1A23B456CD". This string contains no characters requiring a base-30 Shift out of the basic Base-30 character set, and so2023
```
Base-30 is selected for the non-numeric base (and so the first bit of the Alphanumeric subsection is set to ‘0’ accordingly). The data string2024
```
```
has no substrings with six or more successive characters from the same base, and so the next two bits are set to ‘00’ (indicating that2025
```
```
neither a Prefix nor a Suffix is run-length encoded). Thus, a full 10-bit Character Map needs to be encoded next. Its specific bit pattern is2026
```
‘0100100011’, indicating the specific sequence of digits and non-digits in the source data string "1A23B456CD".2027
Up to this point, the Alphanumeric subsection contains the 13-bit sequence ‘0 00 0100100011’. From Annex K, it can be determined that2028
```
lengths of the two final bit sequences (encoding the Base-10 and Base-30 components of the source data string) are 20 bits (for the six2029
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 443 of 448
```
digits) and 20 bits (for the four uppercase letters using Base 30). The six digits of the source data string "1A23B456CD" are "123456",2030
```
which encodes to a 20-bit sequence of:2031
"00011110001001000000"2032
which is appended to the end of the 13-bit sequence cited at the start of this paragraph.2033
```
The four non-digits of the source data string are "ABCD", which are converted (using Table K-1) to a sequence of four Base-30 values 1, 2,2034
```
```
3, and 4 (denoted as values v 3 through v 0 in the formula below. These are then converted to a single Binary value, using the following2035
```
```
formula:2036
```
303 * v 3 + 302 * v 2 + 301 * v 1 + 300 * v 02037
```
In this example, the formula calculates as (27000 * 1 + 900 * 2 + 30 * 3 + 1 * 4) which is equal to 070DE (hexadecimal) encoded as the2038
```
20-bit sequence "00000111000011011110" which is appended to the end of the previous 20-bit sequence. Thus, the AlphaNumeric section2039
```
contains a total of (13 + 20 + 20) or 53 bits, appended immediately after the previous 83 bits, for a grand total of 136 significant bits in the2040
```
Packed Object.2041
```
The final encoding step is to calculate the full length of the Packed Object (to encode the EBV-6 within the Length Section) and to pad-out2042
```
```
the last byte (if necessary). Dividing 136 by eight shows that a total of 17 bytes are required to hold the Packed Object, and that no pad2043
```
bits are required in the last byte. Thus, the EBV-6 portion of the Length Section is "010001", where this EBV-6 value indicates 17 bytes in2044
the Object. Following that, the Pad Indicator bit is set to ‘0’ indicating that no padding bits are present in the last data byte.2045
The complete encoding process may be summarised as follows:2046
```
Original input: (7)061031(32)978123456(1)1A23B456CD2047
```
```
Re-ordered as: (7)061031(1)1A23B456CD(32)9781234562048
```
2049
```
FORMAT FLAGS SECTION: (empty)2050
```
OBJECT INFO SECTION:2051
```
ebvObjectLen: 0100012052
```
```
paddingPresent: 02053
```
```
ebvNumIDs: 0012054
```
```
IDvals: 1111101 01100112055
```
SECONDARY ID SECTION:2056
```
IDbits: 00102057
```
AUX FORMAT SECTION:2058
```
auxFormatbits: 1 01012059
```
DATA SECTION:2060
```
KLnumeric: 0000 11101110 01100111 111010 01001100 11111010 110000002061
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 444 of 448
```
ANheader: 02062
```
```
ANprefix: 02063
```
```
ANsuffix: 02064
```
```
ANmap: 01 001000112065
```
```
ANdigitVal: 0001 11100010 010000002066
```
```
ANnonDigitsVal: 0000 01110000 110111102067
```
```
Padding: none2068
```
```
Total Bits in Packed Object: 136; when byte aligned: 1362069
```
Output as: 44 7E B3 2A 87 73 3F 49 9F 58 01 23 1E 24 00 70 DE2070
Table L-1 shows the relevant subset of a hypothetical ID Table for a hypothetical ISO-registered Data Format 99.2071
Table J.4.1-1 hypothetical Base ID Table, for the example in Annex L2072
K-Version = 1.0
K-TableID = F99B0
K-RootOID =
```
urn:oid:1.0.15961.99
```
K-IDsize = 128
IDvalue OIDs Data Title FormatString
3 1 BATCH/LOT 1*20an
8 7 USE BY OR EXPIRY 6n
51 3%x30-39 AMOUNT 4*18n
```
125 (7) (1) EXPIRY + BATCH/LOT (6n) (1*20an)
```
K-TableEnd = F99B0
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 445 of 448
```
M Decoding Packed Objects (non-normative)2073
```
M.1 Overview2074
The decode process begins by decoding the first byte of the memory as a DSFID. If the leading two bits indicate the Packed Objects access2075
method, then the remainder of this Annex applies. From the remainder of the DSFID octet or octets, determine the Data Format, which shall2076
be applied as the default Data Format for all of the Packed Objects in this memory. From the Data Format, determine the default ID Table2077
which shall be used to process the ID Values in each Packed Object.2078
Typically, the decoder takes a first pass through the initial ID Values list, as described earlier, in order to complete the list of identifiers. If2079
```
the decoder finds any identifiers of interest in a Packed Object (or if it has been asked to report back all the data strings from a tag’s2080
```
```
memory), then it will need to record the implied fixed lengths (from the ID table) and the encoded variable lengths (from the Aux Format2081
```
```
subsection), in order to parse the Packed Object’s compressed data. The decoder, when recording any variable-length bit patterns, must2082
```
```
first convert them to variable string lengths per the table (for example, a three-bit pattern may indicate a variable string length in the range2083
```
```
of two to nine).2084
```
Starting at the first byte-aligned position after the end of the DSFID, parse the remaining memory contents until the end of encoded data,2085
repeating the remainder of this section until a Terminating Pattern is reached.2086
```
Determine from the leading bit pattern (see I.4) which one of the following conditions applies:2087
```
1. there are no further Packed Objects in Memory (if the leading 8-bit pattern is all zeroes, this indicates the Terminating Pattern)2088
2. one or more Padding bytes are present. If padding is present, skip the padding bytes, which are as described in Annex I, and examine2089
the first non-pad byte.2090
3. a Directory Pointer is encoded. If present, record the offset indicated by the following bytes, and then continue examining from the next2091
byte in memory2092
4. a Format Flags section is present, in which case process this section according to the format described in Annex I2093
5. a default-format Packed Object begins at this location2094
If the Packed Object had a Format Flags section, then this section may indicate that the Packed Object is of the ID Map format, otherwise it2095
is of the ID List format. According to the indicated format, parse the Object Information section to determine the Object Length and ID2096
information contained in the Packed Object. See Annex I for the details of the two formats. Regardless of the format, this step results in a2097
```
known Object length (in bits) and an ordered list of the ID Values encoded in the Packed Object. From the governing ID Table, determine2098
```
```
the list of characteristics for each ID (such as the presence and number of Secondary ID bits).2099
```
Parse the Secondary ID section of the Object, based on the number of Secondary ID bits invoked by each ID Value in sequence. From this2100
```
information, create a list of the fully-qualified ID Values (FQIDVs) that are encoded in the Packed Object.2101
```
Parse the Aux Format section of the Object, based on the number of Aux Format bits invoked by each FQIDV in sequence.2102
Parse the Data section of the Packed Object:2103
1. If one or more of the FQIDVs indicate all-numeric data, then the Packed Object’s Data section contains a Known-Length Numeric2104
subsection, wherein the digit strings of these all-numeric items have been encoded as a series of binary quantities. Using the known2105
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 446 of 448
length of each of these all-numeric data items, parse the correct numbers of bits for each data item, and convert each set of bits to a2106
string of decimal digits.2107
2. If (after parsing the preceding sections) one or more of the FQIDVs indicate alphanumeric data, then the Packed Object’s Data section2108
contains an AlphaNumeric subsection, wherein the character strings of these alphanumeric items have been concatenated and encoded2109
into the structure defined in Annex I. Decode this data using the "Decoding Alphanumeric data" procedure outlined below.2110
3. For each FQIDV in the decoded sequence:2111
4. convert the FQIDV to an OID, by appending the OID string defined in the registered format’s ID Table to the root OID string defined in2112
```
that ID Table (or to the default Root OID, if none is defined in the table)2113
```
5. Complete the OID/Value pair by parsing out the next sequence of decoded characters. The length of this sequence is determined2114
```
directly from the ID Table (if the FQIDV is specified as fixed length) or from a corresponding entry encoded within the Aux Format2115
```
section.2116
M.2 Decoding alphanumeric data2117
Within the Alphanumeric subsection of a Packed Object, the total number of data characters is not encoded, nor is the bit length of the2118
```
character map, nor are the bit lengths of the succeeding Binary sections (representing the numeric and non-numeric Binary values). As a2119
```
result, the decoder must follow a specific procedure in order to correctly parse the AlphaNumeric section.2120
```
When decoding the A/N subsection using this procedure, the decoder will first count the number of non-bitmapped values in each base (as2121
```
```
indicated by the various Prefix and Suffix Runs), and (from that count) will determine the number of bits required to encoded these2122
```
numbers of values in these bases. The procedure can then calculate, from the remaining number of bits, the number of explicitly-encoded2123
```
character map bits. After separately decoding the various binary fields (one field for each base that was used), the decoder "re-interleaves"2124
```
the decoded ASCII characters in the correct order.2125
The A/N subsection decoding procedure is as follows:2126
■ Determine the total number of non-pad bits in the Packed Object, as described in section I.8.22127
■ Keep a count of the total number of bits parsed thus far, as each of the subsections prior to the Alphanumeric subsection is processed2128
■ Parse the initial Header bits of the Alphanumeric subsection, up to but not including the Character Map, and add this number to previous value of2129
TotalBitsParsed.2130
```
■ Initialise a DigitsCount to the total number of base-10 values indicated by the Prefix and Suffix (which may be zero)2131
```
```
■ Initialise an ExtDigitsCount to the total number of base-13 values indicated by the Prefix and Suffix (which may be zero)2132
```
```
■ Initialise a NonDigitsCount to the total number of base-30, base 74, or base-256 values indicated by the Prefix and Suffix (which may be zero)2133
```
```
■ Initialise an ExtNonDigitsCount to the total number of base-40 or base 84 values indicated by the Prefix and Suffix (which may be zero)2134
```
■ Calculate Extended-base Bit Counts: Using the tables in Annex K, calculate two numbers:2135
□ ExtDigitBits, the number of bits required to encode the number of base-13 values indicated by ExtDigitsCount, and2136
```
□ ExtNonDigitBits, the number of bits required to encode the number of base-40 (or base-84) values indicated by ExtNonDigitsCount2137
```
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 447 of 448
□ Add ExtDigitBits and ExtNonDigitBits to TotalBitsParsed2138
■ Create a PrefixCharacterMap bit string, a sequence of zero or more quad-base character-map pairs, as indicated by the Prefix bits just parsed.2139
Use quad-base bit pairs defined as follows:2140
```
□ ‘00’ indicates a base 10 value;2141
```
```
□ ‘01’ indicates a character encoded in Base 13;2142
```
□ ‘10’ indicates the non-numeric base that was selected earlier in the A/N header, and2143
□ ‘11’ indicates the Extended version of the non-numeric base that was selected earlier2144
■ Create a SuffixCharacterMap bit string, a sequence of zero or more quad-base character-map pairs, as indicated by the Suffix bits just parsed.2145
■ Initialise the FinalCharacterMap bit string and the MainCharacterMap bit string to an empty string2146
■ Calculate running Bit Counts: Using the tables in Annex B, calculate two numbers:2147
□ DigitBits, the number of bits required to encode the number of base-10 values currently indicated by DigitsCount, and2148
```
□ NonDigitBits, the number of bits required to encode the number of base-30 (or base 74 or base-256) values currently indicated by2149
```
NonDigitsCount2150
■ set AlnumBits equal to the sum of DigitBits plus NonDigitBits2151
■ if the sum of TotalBitsParsed and AlnumBits equals the total number of non-pad bits in the Packed Object, then no more bits remain to be parsed2152
from the character map, and so the remaining bit patterns, representing Binary values, are ready to be converted back to extended base values2153
```
and/or base 10/base 30/base 74/base-256 values (skip to the Final Decoding steps below). Otherwise, get the next encoded bit from the2154
```
encoded Character map, convert the bit to a quad-base bit-pair by converting each ‘0’ to ‘00’ and each ‘1’ to ‘10’, append the pair to the end of2155
the MainCharacterMap bit string, and:2156
□ If the encoded map bit was ‘0’, increment DigitsCount,2157
□ Else if ‘1’, increment NonDigitsCount2158
□ Loop back to the Calculate running Bit Counts step above and continue2159
■ Final decoding steps: once the encoded Character Map bits have been fully parsed:2160
□ Fetch the next set of zero or more bits, whose length is indicated by ExtDigitBits. Convert this number of bits from Binary values to2161
a series of base 13 values, and store the resulting array of values as ExtDigitVals.2162
□ Fetch the next set of zero or more bits, whose length is indicated by ExtNonDigitBits. Convert this number of bits from Binary values2163
```
to a series of base 40 or base 84 values (depending on the selection indicated in the A/N Header), and store the resulting array of2164
```
values as ExtNonDigitVals.2165
□ Fetch the next set of bits, whose length is indicated by DigitBits. Convert this number of bits from Binary values to a series of base2166
10 values, and store the resulting array of values as DigitVals.2167
□ Fetch the final set of bits, whose length is indicated by NonDigitBits. Convert this number of bits from Binary values to a series of2168
```
base 30 or base 74 or base 256 values (depending on the value of the first bits of the Alphanumeric subsection), and store the2169
```
resulting array of values as NonDigitVals.2170
EPC Tag Data Standard TDS
Release 2.3, Ratified, Oct 2025 © 2025 GS1 AISBL Page 448 of 448
□ Create the FinalCharacterMap bit string by copying to it, in this order, the previously-created PrefixCharacterMap bit string, then the2171
MainCharacterMap string, and finally append the previously-created SuffixCharacterMap bit string to the end of the2172
FinalCharacterMap string.2173
□ Create an interleaved character string, representing the concatenated data strings from all of the non-numeric data strings of the2174
Packed Object, by parsing through the FinalCharacterMap, and:2175
```
■ For each ‘00’ bit-pair encountered in the FinalCharacterMap, copy the next value from DigitVals to InterleavedString (add 48 to each value to2176
```
```
convert to ASCII);2177
```
■ For each ‘01’ bit-pair encountered in the FinalCharacterMap, fetch the next value from ExtDigitVals, and use Table K-2 to convert that value to2178
```
ASCII (or, if the value is a Base 13 shift, then increment past the next ‘01’ pair in the FinalCharacterMap, and use that Base 13 shift value plus2179
```
```
the next Base 13 value from ExtDigitVals to convert the pair of values to ASCII). Store the result to InterleavedString;2180
```
■ For each ‘10’ bit-pair encountered in the FinalCharacterMap, get the next character from NonDigitVals, convert its base value to an ASCII value2181
using Annex K, and store the resulting ASCII value into InterleavedString. Fetch and process an additional Base 30 value for every Base 30 Shift2182
values encountered, to create and store a single ASCII character.2183
■ For each ‘11’ bit-pair encountered in the FinalCharacterMap, get the next character from ExtNonDigitVals, convert its base value to an ASCII2184
value using Annex K, and store the resulting ASCII value into InterleavedString, processing any Shifts as previously described.2185
Once the full FinalCharacterMap has been parsed, the InterleavedString is completely populated. Starting from the first AlphaNumeric entry2186
on the ID list, copy characters from the InterleavedString to each such entry, ending each copy operation after the number of characters2187
indicated by the corresponding Aux Format length bits, or at the end of the InterleavedString, whichever comes first.2188
2189