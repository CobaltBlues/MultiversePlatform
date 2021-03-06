/********************************************************************

The Multiverse Platform is made available under the MIT License.

Copyright (c) 2012 The Multiverse Foundation

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, 
merge, publish, distribute, sublicense, and/or sell copies 
of the Software, and to permit persons to whom the Software 
is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
OR OTHER DEALINGS IN THE SOFTWARE.

*********************************************************************/


namespace TUVienna.CS_CUP
{

	/** This class represents a reduce action within the parse table. 
	 *  The action simply stores the production that it reduces with and 
	 *  responds to queries about its type.
	 *
	 * @version last updated: 11/25/95
	 * @author  Scott Hudson
     * translated to C# 08.09.2003 by Samuel Imriska
	 */
	public class reduce_action : parse_action 
							   {
 
								   /*-----------------------------------------------------------*/
								   /*--- Constructor(s) ----------------------------------------*/
								   /*-----------------------------------------------------------*/

								   /** Simple constructor. 
									* @param prod the production this action reduces with.
									*/
								   public reduce_action(production prod ) 
																		  {
																			  /* sanity check */
																			  if (prod == null)
		throw new internal_error(
				  "Attempt to create a reduce_action with a null production");

		_reduce_with = prod;
	}

	/*-----------------------------------------------------------*/
	/*--- (Access to) Instance Variables ------------------------*/
	/*-----------------------------------------------------------*/
  
	/** The production we reduce with. */
	protected production _reduce_with;

	/** The production we reduce with. */
	public production reduce_with() {return _reduce_with;}

	/*-----------------------------------------------------------*/
	/*--- General Methods ---------------------------------------*/
	/*-----------------------------------------------------------*/

	/** Quick access to type of action. */
	  public override  int kind() {return REDUCE;}

	/*. . . . . . . . . . . . . . . . . . . . . . . . . . . . . .*/

	/** Equality test. */
	public  bool Equals(reduce_action other)
{
	return other != null && other.reduce_with() == reduce_with();
}

	/*. . . . . . . . . . . . . . . . . . . . . . . . . . . . . .*/

	/** Generic equality test. */
	 public override bool Equals(object other)
{
	if (other.GetType()==typeof(reduce_action))
	return Equals((reduce_action)other);
	else
	return false;
}

	/*. . . . . . . . . . . . . . . . . . . . . . . . . . . . . .*/

	/** Compute a hash code. */
	 public override int GetHashCode()
{
	/* use the hash code of the production we are reducing with */
	return reduce_with().GetHashCode();
}


	/** Convert to string. */
	  public override string ToString() 
{
	return "REDUCE(with prod " + reduce_with().index() + ")";
}

	/*-----------------------------------------------------------*/

}
}
