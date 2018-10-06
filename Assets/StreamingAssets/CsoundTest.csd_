<Cabbage>
hslider channel("Time_Scaling"), range(0.0, 2.0, 1.0),text("Time Scale")
hslider channel("Amplitude"), range(0.0, 5.0, 1.0)
hslider channel("Pitch"), range(0.0, 1.0, 1.0)
</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -d -m0d
</CsOptions>
<CsInstruments>
sr = 48000
ksmps = 32
nchnls = 2
0dbfs = 1

gimain ftgen 2, 0, 44100, 10, 0

instr 1

ktime		chnget "Time_Scaling"
kamp		chnget "Amplitude"
kpitch	chnget "Pitch"
kcue		 chnget "SkipTime"


andx line 0,1,sr

andx += kcue * sr

andx = andx % ftlen(2)
asig tablei andx,2

;asigl		temposcal	 ktime,kamp,kpitch, 2, 1, 2048

outs asig,asig
endin

instr 199
SSong = p4
iskip = p5

;kcue		 chnget "SkipTime"
;gimain ftgen 2,0,0,1,SSong,0,0,1
gimain ftgen 2,0,0,1,SSong,iskip,0,1

endin

</CsInstruments>
<CsScore>
f0 z
;i199 0 1
;i1 	1 	z
;f 1 0 0 1 "/Users/TaoYao/Google Drive/6th Semester/Class Recordings/MTEC-421/Unity Projects/DJ Game Project/Assets/Resources/Symphony.ogg" 0 0 1
;f 2 0 1024 9 0.5 1 0	window shape for grainular opcode (half sine)
</CsScore>
</CsoundSynthesizer>
<bsbPanel>
 <label>Widgets</label>
 <objectName/>
 <x>99</x>
 <y>473</y>
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
