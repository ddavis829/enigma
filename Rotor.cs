	public class Rotor
	{
		private string layout;
		private byte offset;
		private Rotor previous, next;
		private char cIn = '\0', notchPos;
	
		public Rotor(string layout,char notchPos)
		{
			this.layout = layout;
			this.notchPos = notchPos;
			offset = 0;	
		}

		public void SetNextRotor(Rotor next){
			this.next = next;
		}
		public void SetPreviousRotor(Rotor previous){
			this.previous = previous;
		}
		
		public char GetInverseCharAt(string ch){
			int pos = layout.IndexOf(ch);
			
			if(offset>pos){
				pos = 26 - (offset-pos);
			}else{
				pos = pos - offset;
			}
			
			if(previous!=null){
				pos = (pos+previous.GetOffset())%26;
			}
			
			return (char)(65+pos);
		}
		
		public int GetOffset(){
			return offset;
		}

        public char GetLetter()
        {
            return (char)('A' + offset);
        }
		
		public void Move(){
			if(next==null){
				return;
			}
			offset++;
			if(offset==26){
				offset = 0;
			}
			
			if(next!=null && (offset+66) == ((notchPos-64)%26)+66){
				next.Move();
			}
		}
		
		public void PutDataIn(char s){
			cIn = s;
			char c = s;
			c = (char)(((c - 65) + offset) % 26 + 65);
			
			if(next!=null){
				c = layout.Substring((c-65),1).ToCharArray()[0];
				if((((c-65)+(-offset))%26 + 65)>=65){
					c = (char)(((c-65)+(-offset))%26 + 65);
				}else{
					c = (char)(((c-65)+(26+(-offset)))%26 + 65);
				}
				next.PutDataIn(c);
				
			}
		}
		
		public char GetDataOut(){
			char c = '\0';
			
			if(next!=null){
				c = next.GetDataOut();
				c = GetInverseCharAt(""+c);
			}else{ //only in the reflector case
				c = layout.Substring((cIn-65),1).ToCharArray()[0];
				c = (char)(((c - 65) + previous.offset)%26+65);
				
			}
			
			return c;
		}
		
	}
