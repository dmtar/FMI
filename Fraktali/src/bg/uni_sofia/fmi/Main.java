package bg.uni_sofia.fmi;

import java.awt.*;
import java.util.*;

public class Main
{
	public static final int POLYGON_SIZE = 512;

	public static void main(String[] args)
	{
		// Asks user for level
		int level = 1;
		Scanner console = new Scanner(System.in);
		System.out.print("What level do you want? ");
		try{
			level = console.nextInt();
		} catch(Exception e){
			//Just use level 1.
		}
		Graphics newPanel = initializePanel(level);
		
		//Initialize 3 starting points
		Point p1 = new Point(POLYGON_SIZE/2, 0);
		Point p2 = new Point(POLYGON_SIZE,POLYGON_SIZE);
		Point p3 = new Point(0,POLYGON_SIZE);
		draw(level, newPanel, p1, p2, p3);
		console.close();
	}
	
	private static Graphics initializePanel(int level)
	{
		DrawingPanel panel = new DrawingPanel(POLYGON_SIZE, POLYGON_SIZE);
		panel.setBackground(Color.GRAY);
		Graphics graphic = panel.getGraphics();
		return graphic;
	}
	
	/*
	 * Draw method, needs level,polygon and 3 starting points in the beginning.
	 * 
	 */
	public static void draw(int level, Graphics graphic, Point p1, Point p2, Point p3)
	{
		if (level == 1)
		{
			
			Polygon polygon = new Polygon();
			polygon.addPoint(p1.x, p1.y);
			polygon.addPoint(p2.x, p2.y);
			polygon.addPoint(p3.x, p3.y);
			graphic.fillPolygon(polygon);
		}
		else
		{
			
			Point p4 = midpoint(p1, p2);
			Point p5 = midpoint(p2, p3);
			Point p6 = midpoint(p1, p3);

			
			draw(level - 1, graphic, p1, p4, p6);
			draw(level - 1, graphic, p4, p2, p5);
			draw(level - 1, graphic, p6, p5, p3);
		}
	}
	/*
	 * Calculates coordinates of the middle point between two others.
	 */
	public static Point midpoint(Point p1, Point p2)
	{
		return new Point((p1.x + p2.x) / 2, (p1.y + p2.y) / 2);
	}

}
