#pragma once


#define DRAW_DEBUG_LINE(location,target, color) DrawDebugLine(GetWorld(), location, target, FColor::color, false, -1);

#define DRAW_DEBUG_SPHERE(target,radius ,color)  DrawDebugSphere(GetWorld(), target, radius, 32, FColor::color, false, -1);

#define DRAW_DEBUG_BOX( from, extents, color, size) DrawDebugBox(GetWorld(), from, extents,  FColor::color, false, -1, 0, size);