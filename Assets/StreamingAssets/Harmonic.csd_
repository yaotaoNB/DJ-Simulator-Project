<Cabbage>
form caption("Cube Sound"), size(300, 200)
hslider bounds(8, 40, 280, 30), channel("freq"), text("Sphere Freq"), range(0, 1000, 0)
hslider bounds(8, 140, 280, 30), channel("amp"), text("Sphere Amp"), range(0, 1, 0)
</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -d -m0d
</CsOptions>
<CsInstruments>
sr 	= 	48000 
ksmps 	= 	32
nchnls 	= 	2
0dbfs	=	1 

;very simple single tone instrument. This will run
;for the duration of the game, amp and freq are set through
;channels "amp" and "freq"
instr Harmonic
	kFreq port chnget:k("freq"), .1
	a1 oscili chnget:k("amp"), kFreq
	outs a1, a1
endin

</CsInstruments>
<CsScore>
;play for a week...
i"Harmonic" 0 [60*60*24*7]
</CsScore>
</CsoundSynthesizer>
<bsbPanel>
 <label>Widgets</label>
 <objectName/>
 <x>100</x>
 <y>100</y>
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
