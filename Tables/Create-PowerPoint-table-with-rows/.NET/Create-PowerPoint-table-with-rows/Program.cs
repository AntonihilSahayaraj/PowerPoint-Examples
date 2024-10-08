﻿using Syncfusion.Presentation;

//Open an existing PowerPoint presentation.
using IPresentation pptxDoc = Presentation.Create();
//Add slide to the presentation.
ISlide slide = pptxDoc.Slides.Add(SlideLayoutType.Blank);
//Add a table to the slide
ITable table = slide.Shapes.AddTable(2, 2, 100, 120, 300, 200);
//Initialize index values to add text to table cells.
int rowIndex = 0, colIndex;
//Iterate row-wise cells and add text to it.
foreach (IRow rows in table.Rows)
{
    colIndex = 0;
    foreach (ICell cell in rows.Cells)
    {
        cell.TextBody.AddParagraph("(" + rowIndex.ToString() + " , " + colIndex.ToString() + ")");
        colIndex++;
    }
    rowIndex++;
}
using FileStream outputStream = new(Path.GetFullPath(@"Output/Result.pptx"), FileMode.Create, FileAccess.ReadWrite);
pptxDoc.Save(outputStream);