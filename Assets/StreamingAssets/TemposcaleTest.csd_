<Cabbage>
form caption("Test"), size(300, 200)
</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -d -m0d	-idac	-odac
</CsOptions>
<CsInstruments>
sr 	= 	48000 
ksmps 	= 	32
nchnls 	= 	2
0dbfs	=	1 

instr 1
;SPath chnget "AudioPath"
;SFilename sprintf "%s/Radiate.wav", SPath

;giTable ftgen 100, 0, 0, 1, "/Users/TaoYao/Google Drive/6th Semester/Class Recordings/MTEC-421/Unity Projects/DJ Game Project/Assets/Audio/Symphony.ogg", 0, 4, 1
endin

instr TEMPOSCALE
ain1, ainr inch 1, 2
asig temposcal	1,1,1, k(ain1), 1, 2048
;asig temposcal	1,1,1, 100, 1, 2048
outs ain1, ain1
endin  

</CsInstruments>
<CsScore>

i1 0 1
i"TEMPOSCALE" 2 [3600*12]
</CsScore>
</CsoundSynthesizer>
<bsbPanel>
 <label>Widgets</label>
 <objectName/>
 <x>100</x>
 <y>144</y>
 <width>320</width>
 <height>240</height>
 <visible>true</visible>
 <uuid/>
 <bgcolor mode="nobackground">
  <r>255</r>
  <g>255</g>
  <b>255</b>
 </bgcolor>
</bsbPanel>
<bsbPresets>
</bsbPresets>
