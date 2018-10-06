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

instr 1

ktime		chnget "Time_Scaling"
kamp		chnget "Amplitude"
kpitch	chnget "Pitch"
kcue		 chnget "SkipTime"

Sfile_new		strcpy	""		
				
	Ssong chnget "SongPlay"
	SPath chnget "AudioPath"
	Sfile_old		strcpyk	Sfile_new
	Sfile_new		strcpyk	Ssong
	kfile 		strcmpk	Sfile_new, Sfile_old
	
	;Snew strcpy	 ""	
	;Sold strcpyk Snew
	;Snew strcpyk S(kcue)
	;kcuecom 		strcmpk	Snew, Sold

	;Do a seperate instr in Csound, check mono/stereo, use through L/R ftgen.Beat_Mangler
	;pvswarp,soundin,diskin1/2, tablei, tableikt
	
	if	kfile != 0	then															 
			reinit	NEW_FILE													
	endif
	
	;if kcuecom != 0 then
	;reinit	NEW_FILE													
	;endif
	
	NEW_FILE:
	SAudioFile sprintf "%s/%s",SPath, Ssong
	
;giTable ftgen 1, 0, 0, 1, SAudioFile,0,0,1
	;ifiler		ftgentmp	0, 0, 0, 1, SAudioFile,i(kcue),0,2		

kres 	tableikt kcue,1,1,0				

asigl		temposcal	 ktime,kamp,kpitch, 1, 1, 2048
;asigr		temposcal	 ktime,kamp,kpitch, ifiler, 1, 2048

		rireturn
;aenv		linsegr	0,0.05,1,0.05,0												
		;outs		asigl*aenv, asigr*aenv	
		outs		asigl,asigl
endin


</CsInstruments>
<CsScore>
i 1 	0 	3600
;f 1 0 0 1 "/Users/TaoYao/Google Drive/6th Semester/Class Recordings/MTEC-421/Unity Projects/DJ Game Project/Assets/Audio/Symphony.ogg" 0 0 1
;f 2 0 1024 9 0.5 1 0	window shape for grainular opcode (half sine)
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
