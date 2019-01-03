using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
//using System.Windows;

//threading
using System.Threading;
//using System.Threading.Tasks;

//stopwatch
using System.Diagnostics;


namespace SortingHat
{
    public partial class Sort : Form
    {
        Color newColour = new Color();

        Random RandomNo = new Random();


        Graphics backgroundGFX;

        Bitmap image;
        Bitmap generatedBMP;

        //Bubble Sort
        Bitmap bubbleImage;
        Rectangle bubbleRect;
        Stopwatch bubbleWatch = new Stopwatch();
        public double bubbleTimer = 0;

        //Insertion Sort
        Bitmap insertionImage;
        Rectangle insertRect;
        Stopwatch insertWatch = new Stopwatch();
        public double insertionTimer = 0;

        //Selection Sort
        Bitmap selectionImage;
        Rectangle selectionRect;
        Stopwatch selectionWatch = new Stopwatch();
        public double selectionTimer = 0;

        //Timer
        System.Windows.Forms.Timer sortTextTimer = new System.Windows.Forms.Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            sortTextTimer.Tick += new EventHandler(TimerTick);
            sortTextTimer.Interval = 1;
            sortTextTimer.Start();
        }

        public Sort()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e){}//dammit

        /////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////Array management///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////
        private void buttonPopulateArray_Click(object sender, EventArgs e)
        {
            image = new Bitmap("Assets/sorting70x70.bmp");
            Graphics backgroundGFX = this.CreateGraphics();
            
            for( int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    int randomR = RandomNo.Next(0, 256);

                    newColour = Color.FromArgb(1, randomR, 0, 0);

                    image.SetPixel(x, y, newColour);
                }
            }

            generatedBMP = (Bitmap)image.Clone();

            Rectangle destRect = new Rectangle(470, 230, generatedBMP.Width, generatedBMP.Height);
            backgroundGFX.DrawImage(generatedBMP, destRect);

            //separates out bmps for sorting
            bubbleImage = (Bitmap)generatedBMP.Clone();
            insertionImage = (Bitmap)generatedBMP.Clone();
            selectionImage = (Bitmap)generatedBMP.Clone();

        }
        private void buttonResetCurrentArray_Click(object sender, EventArgs e)
        {
            //separates out bmps for sorting
            bubbleImage = (Bitmap)generatedBMP.Clone();
            insertionImage = (Bitmap)generatedBMP.Clone();
            selectionImage = (Bitmap)generatedBMP.Clone();

            //Bubble Sort
            backgroundGFX = this.CreateGraphics();
            Rectangle bubbleRect = new Rectangle(260, 425, bubbleImage.Width, bubbleImage.Height);
            backgroundGFX.DrawImage(bubbleImage, bubbleRect);

            //Insertion Sort
            backgroundGFX = this.CreateGraphics();
            Rectangle insertRect = new Rectangle(470, 425, insertionImage.Width, insertionImage.Height);
            backgroundGFX.DrawImage(insertionImage, insertRect);

            //selection Sort
            backgroundGFX = this.CreateGraphics();
            Rectangle selectionRect = new Rectangle(650, 425, selectionImage.Width, selectionImage.Height);
            backgroundGFX.DrawImage(selectionImage, selectionRect);
        }
        //private void buttonRefreshDrawing_Click(object sender, EventArgs e){}

        /////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////Sorting Algorithms//////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////
        private void buttonBubbleSort_Click(object sender, EventArgs e)
        {
            ThreadStart bStart = new ThreadStart(BubbleSort);
            Thread bThread = new Thread(bStart);
            bThread.Start();
            
        }
         private void BubbleSort()
        {
            if (bubbleImage != null)
            {
                bubbleTimer = 0;
                bubbleWatch.Restart();

                List<int> listOfRivals = new List<int>();
                //loops through 2D image array and adds to new list as 1D
                for (int yy = 0; yy < bubbleImage.Height; yy++)
                {
                    for (int xx = 0; xx < bubbleImage.Width; xx++)
                    {
                        listOfRivals.Add(bubbleImage.GetPixel(xx, yy).R);
                        bubbleTimer = bubbleWatch.Elapsed.TotalSeconds;
                    }
                }

                for (int p = 0; p <= listOfRivals.Count - 2; p++)
                {
                    for (int i = 0; i <= listOfRivals.Count - 2; i++)
                    {
                        if (listOfRivals[i] > listOfRivals[i + 1])
                        {
                            int t = listOfRivals[i + 1];
                            listOfRivals[i + 1] = listOfRivals[i];
                            listOfRivals[i] = t;
                        }
                    }
                }

                int counter = 0;
                for (int yi = 0; yi < bubbleImage.Height; yi++)
                {
                    for (int xi = 0; xi < bubbleImage.Width; xi++)
                    {
                        bubbleImage.SetPixel(xi, yi, Color.FromArgb(listOfRivals[counter], 0, 0));
                        counter++;

                        backgroundGFX = this.CreateGraphics();
                        bubbleRect = new Rectangle(260, 425, bubbleImage.Width, bubbleImage.Height);
                        backgroundGFX.DrawImage(bubbleImage, bubbleRect);


                        bubbleTimer = bubbleWatch.Elapsed.TotalSeconds;
                    }
                }

                backgroundGFX = this.CreateGraphics();
                bubbleRect = new Rectangle(260, 425, bubbleImage.Width, bubbleImage.Height);
                backgroundGFX.DrawImage(bubbleImage, bubbleRect);

                bubbleTimer = bubbleWatch.Elapsed.TotalSeconds;
            }
            bubbleWatch.Stop();
        }
        //Legacy sort in 2D
            /*
            if (bubbleImage != null)
            {
                bubbleTimer = 0;
                bubbleWatch.Restart();

                bool swapper = true;
                while (swapper)
                {
                    swapper = false;
                    for(int y = 0; y < bubbleImage.Height; y++)
                    {
                        for(int x = 0; x < bubbleImage.Width; x++)
                        {
                            Color pixelColour = bubbleImage.GetPixel(x, y);
                            Color nextPixelColour;
                            //if next is on same row
                            if (x + 1 <= bubbleImage.Width - 1)
                            {
                                //selects next
                                nextPixelColour = bubbleImage.GetPixel(x + 1, y);
                                //if not in sorted order
                                if (pixelColour.R < nextPixelColour.R)
                                {
                                    //swap
                                    bubbleImage.SetPixel(x + 1, y, pixelColour);
                                    bubbleImage.SetPixel(x, y, nextPixelColour);
                                    swapper = true;
                                }
                            }
                            //if next is still on array
                            else if (y != bubbleImage.Height - 1)
                            {
                                //selects next
                                nextPixelColour = bubbleImage.GetPixel(0, y + 1);
                                //if not in sorted order
                                if (pixelColour.R < nextPixelColour.R)
                                {
                                    //swap
                                    bubbleImage.SetPixel(0, y + 1, pixelColour);
                                    bubbleImage.SetPixel(x, y, nextPixelColour);
                                    swapper = true;
                                }
                            }
                            else break;
                        }
                    }
                    backgroundGFX = this.CreateGraphics();
                    bubbleRect = new Rectangle(260, 350, bubbleImage.Width, bubbleImage.Height);
                    backgroundGFX.DrawImage(bubbleImage, bubbleRect);

                    bubbleTimer = bubbleWatch.Elapsed.TotalSeconds;
                    //sortBubbleTime.Text = bubbleTimer.ToString();
                }
            }
            bubbleWatch.Stop();
        }
        */

        private void buttonInsertionSort_Click(object sender, EventArgs e)
        {
        ThreadStart iStart = new ThreadStart(InsertSort);
        Thread iThread = new Thread(iStart);
        iThread.Start();
        }
        private void InsertSort()
        {
            insertionTimer = 0;
            insertWatch.Restart();

            if (insertionImage != null)
            {
                List<int> listOfRivals = new List<int>();
                //loops through 2D image array and adds to new list as 1D
                for(int yy = 0; yy < insertionImage.Height; yy++)
                {
                    for(int xx = 0; xx < insertionImage.Width; xx++)
                    {
                        listOfRivals.Add(insertionImage.GetPixel(xx, yy).R);
                        insertionTimer = insertWatch.Elapsed.TotalSeconds;
                    }
                }
                //sorts new 1D list
                for(int i = 0; i < listOfRivals.Count - 1; i++)
                {
                    int key = listOfRivals[i];
                    int j = i - 1;

                    while (j >= 0 && listOfRivals[j] > key)
                    {
                        listOfRivals[j + 1] = listOfRivals[j];
                        j--;
                    }
                    listOfRivals[j + 1] = key;
                    insertionTimer = insertWatch.Elapsed.TotalSeconds;
                }

                //goes through 1D list and inserts back into 2D Array for Bitmap
                int counter = 0;
                for(int yi = 0; yi < insertionImage.Height; yi++)
                {
                    for(int xi = 0; xi < insertionImage.Width; xi++)
                    {
                        insertionImage.SetPixel(xi, yi, Color.FromArgb(listOfRivals[counter], 0, 0));
                        counter++;

                        backgroundGFX = this.CreateGraphics();
                        insertRect = new Rectangle(470, 425, insertionImage.Width, insertionImage.Height);
                        backgroundGFX.DrawImage(insertionImage, insertRect);
                        
                        insertionTimer = insertWatch.Elapsed.TotalSeconds;
                    }
                }
            }
            insertWatch.Stop();
        }

        private void buttonSelectionSort_Click(object sender, EventArgs e)
        {
            ThreadStart sStart = new ThreadStart(SelectionSort);
            Thread sThread = new Thread(sStart);
            sThread.Start();
        }
        private void SelectionSort()
        {
            if (selectionImage != null)
            {
                selectionTimer = 0;
                selectionWatch.Restart();

                List<int> listOfRivals = new List<int>();
                //loops through 2D image array and adds to new list as 1D
                for (int yy = 0; yy < selectionImage.Height; yy++)
                {
                    for (int xx = 0; xx < selectionImage.Width; xx++)
                    {
                        listOfRivals.Add(selectionImage.GetPixel(xx, yy).R);
                        selectionTimer = selectionWatch.Elapsed.TotalSeconds;
                    }
                }
                //does the sorting of 1D array
                doSelectionSort(0, listOfRivals);

                //goes through 1D list and inserts back into 2D Array for Bitmap
                int counter = 0;
                for (int yi = 0; yi < selectionImage.Height; yi++)
                {
                    for (int xi = 0; xi < selectionImage.Width; xi++)
                    {
                        selectionImage.SetPixel(xi, yi, Color.FromArgb(listOfRivals[counter], 0, 0));
                        counter++;

                        selectionTimer = selectionWatch.Elapsed.TotalSeconds;
                    }
                    backgroundGFX = this.CreateGraphics();
                    selectionRect = new Rectangle(650, 425, selectionImage.Width, selectionImage.Height);
                    backgroundGFX.DrawImage(selectionImage, selectionRect);
                }
                selectionWatch.Stop();
            }
        }

        private void doSelectionSort(int startIndex, List<int> listOfRivals)
        {
            //sorts list
            int minIndex = findMinimum(startIndex, listOfRivals);
            if (minIndex != startIndex)
            {
                int temp = listOfRivals[minIndex];
                listOfRivals[minIndex] = listOfRivals[startIndex];
                listOfRivals[startIndex] = temp;
            }

            backgroundGFX = this.CreateGraphics();
            selectionRect = new Rectangle(650, 425, selectionImage.Width, selectionImage.Height);
            backgroundGFX.DrawImage(selectionImage, selectionRect);

            selectionTimer = selectionWatch.Elapsed.TotalSeconds;

            startIndex++;
            if (startIndex < listOfRivals.Count)
            {
                //calls itself again as a recursive loop
                doSelectionSort(startIndex, listOfRivals);
            }
        }

        private int findMinimum(int startIndex, List<int> listOfRivals)
        {
            int minList = listOfRivals[startIndex];
            int minIndex = startIndex;
            //searches array for lowest
            for (int i = (startIndex + 1); i < listOfRivals.Count; i++)
            {
                if (minList > listOfRivals[i])
                {
                    minList = listOfRivals[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        //keeps text updated in realtime
        private void TimerTick(object sender, EventArgs e)
        {
            sortBubbleTime.Text = bubbleTimer.ToString("F2");
            sortInsertTime.Text = insertionTimer.ToString("F2");
            sortSelectionTime.Text = selectionTimer.ToString("F2");
        }
    }
}
