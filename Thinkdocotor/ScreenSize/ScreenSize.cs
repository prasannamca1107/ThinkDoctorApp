using System;
using Xamarin.Forms;
namespace ThinkDoctor
{
	public class ScreenSize
	{
		public static int left=10, right=10, top=10, bottom=10,spacing=10;
		public static int H, W;
		public ScreenSize()
		{



		}
		public static int[] imgHW(double widthAlloc,double heightAlloc)
		{
			int[] s1 = new int[2];
			if (widthAlloc <= 360 && heightAlloc<=640)
			{
				H = 25;
				W = 25;
			}
			else if (widthAlloc <= 414)
			{
				H = 25;
				W = 25;
			}
			else if (widthAlloc >= 700)
			{
				H = 30;
				W = 30;
			}

			s1[0] = H;
			s1[1] = W;


			return s1;
		}
public static int[] MarginSizeIOS(double widthAlloc, double heightAlloc)
{
int[] s1 = new int[4];
if (widthAlloc <= 320)
{
left = 15;
right = 15;
}
else if (widthAlloc <= 375)
{
left = 20;
right = 20;
}
else if (widthAlloc <= 414)
{
left = 25;
right = 25;
}
else if (widthAlloc >= 700)
{
left = 40;
right = 40;
}
if (heightAlloc <= 480)
{
top = 15;
bottom = 15;
}
else if (heightAlloc <= 568)
{
top = 25;
bottom = 25;
}
else if (heightAlloc > 600)
{
top = 30;
bottom = 30;
}
s1[0] = left;
s1[1] = right;
s1[2] = top;
s1[3] = bottom;

return s1;
}
public static int[] MarginSizeANDROID(double widthAlloc, double heightAlloc)
{
int[] s1 = new int[4];
if (widthAlloc <= 320)
{
left = 15;
right = 15;
}
else if (widthAlloc <= 480)
{
left = 20;
right = 20;
}
else if (widthAlloc <= 600)
{
left = 25;
right = 25;
}
else if (widthAlloc >= 640)
{
left = 40;
right = 40;
}
if (heightAlloc <= 480)
{
top = 15;
bottom = 15;
}
else if (heightAlloc <= 640)
{
top = 25;
bottom = 25;
}
else if (heightAlloc > 800)
{
top = 30;
bottom = 30;
}
s1[0] = left;
s1[1] = right;
s1[2] = top;
s1[3] = bottom;

return s1;
}

public static int SpacingSizeIOS(double widthAlloc, double heightAlloc)
{
if (heightAlloc <= 480)
{
spacing = 10;
}
else if (heightAlloc <= 568)
{
spacing = 25;

}
else if (heightAlloc <= 667)
{
spacing = 30;

}
else if (heightAlloc <= 736)
{
spacing = 35;

}
else if (heightAlloc > 900)
{
spacing = 55;

}
return spacing;

}


public static int SpacingSizeANDOID(double widthAlloc, double heightAlloc)
{
	if (heightAlloc <= 480)
	{
		spacing = 10;
	}
	else if (heightAlloc <= 640)
	{
		spacing = 25;

	}
	else if (heightAlloc <= 800)
	{
		spacing = 35;

	}
	else if (heightAlloc <= 854)
	{
		spacing = 45;

	}
	else if (heightAlloc > 960)
	{
		spacing = 55;

	}
	return spacing;
		}
	}
}
