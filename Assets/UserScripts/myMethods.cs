﻿using UnityEngine;
using System.Collections;

public class myMethods {

	public static float Map(float value, 
	                              float istart, 
	                              float istop, 
	                              float ostart, 
	                              float ostop) {
		return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
	}
}
