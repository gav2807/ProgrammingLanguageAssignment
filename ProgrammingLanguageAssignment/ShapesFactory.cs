using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    class ShapesFactory
    {
        public Shapes getShape(String shapeType) 
        {
            shapeType = shapeType.ToLower().Trim();

            if (shapeType.Equals("circle"))
            {
                return new Circle();
            }
            else if (shapeType.Equals("rect"))
            {
                return new Rectangle();
            }
            else if (shapeType.Equals("triangle"))
            {
                return new Triangle();
            }
            else if (shapeType.Equals("drawto"))
            {
                return new DrawTo();
            }
            else if (shapeType.Equals("moveto"))
            {
                return new MoveTo();
            }
            else
            {
                System.ArgumentException argumentException = new System.ArgumentException("Factoy error: " + shapeType + " does not exist");
                throw argumentException;
            }
        }
    }
}
