#pragma once

#define USE_DRAW_DEBUG 1
#define DRAW_SPHERE( from, radius, color, size) \
	if (USE_DRAW_DEBUG) DrawDebugSphere(WORLD, from, radius, 20, color, false, -1,0 , size);

#define DRAW_SPHERE_DEF( from, radius,def , color, size)\
	if (USE_DRAW_DEBUG)\
		DrawDebugSphere(WORLD, from, radius, def, color, false, -1,0 , size);

#define DRAW_BOX( from, extents, color, size) \
	if (USE_DRAW_DEBUG)\
		DrawDebugBox(WORLD, from, extents, color, false, -1,0 , size);

#define DRAW_LINE( from, to, color, size) \
	if (USE_DRAW_DEBUG)\
	 	DrawDebugLine(WORLD, from, to, color, false, -1,0 , size);

#define DRAW_TEXT( from, text, color, size) \
	if (USE_DRAW_DEBUG)\
		 DrawDebugString(WORLD, from, text, nullptr, color,DELTATIME , false, size);

#define LERP_COLOR(from, to, t) UKismetMathLibrary::LinearColorLerp(from.ReinterpretAsLinear(), to.ReinterpretAsLinear(), t).ToFColor(true);
