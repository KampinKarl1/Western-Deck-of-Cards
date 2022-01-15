using System;



public class CardGame 
{    
    public CardGame()
    {
        CreateDeck();
    }
    
    public class Card
    {
        public CardSuit suit;
        public string value;
        
        public Card (CardSuit _suit, string _value)
        {
            suit= _suit;
            value = _value;
        }
    }    
    
    public enum CardSuit {Hearts, Clubs, Spades, Diamonds, Joker}
   
    Card [] deck = new Card[NUM_CARDS];
    int curIndex = 0;
    
    const int NUM_CARDS = 54; //
    const int START_VAL = 2;
    const int END_VAL = 14;
    
    private string CardValue(int numericValue)
    {
        if (numericValue <= 10)
            return numericValue.ToString();
        else
        {
            switch(numericValue)
            {
                case 11: return "Jack";
                case 12: return "Queen";
                case 13: return "King";
                case 14: return "Ace";
                default: return numericValue.ToString();
            }
        }
    }
    
    private void MakeSuit(CardSuit suit)
    {
        for (int i = START_VAL; i <= END_VAL; i++)
                {
                   // string val = i < 11 ? i.ToString() : "Face";
                    deck[curIndex++] = new Card((CardSuit) suit, CardValue(i));
                }
    }
    
    private void CreateDeck()
    {
        
        for  (int suit = 0; suit < 4; suit++)
        {
                MakeSuit((CardSuit) suit);
        }
        
        deck[52] = new Card(CardSuit.Joker, "Joker");
        deck[53] = new Card(CardSuit.Joker, "Joker");
    }
    
    Random rNumGen = new Random();
    
    int GetRandIndex (int notEqualTo = -1)
    {
        int num = rNumGen.Next(0,NUM_CARDS);
        
        if (num == notEqualTo)
            num = GetRandIndex(notEqualTo);
        
        return num;
    }
    
    
    internal void Shuffle(int numSwaps)
    {
        
        for(int i = 0; i < numSwaps; i++)
        {
            int randIndex = GetRandIndex();
            
            Card c1 = deck[randIndex];
            
            
            int otherRandIndex = GetRandIndex(randIndex);
            Card c2 = deck[otherRandIndex];
            
            deck[otherRandIndex] = c1;
            deck[randIndex] = c2;
        }
        
    }
    
    static int Main()
    {
        CardGame game = new CardGame();
        
        //Shuffle works but if you look at the output, the number of like suits together is offputting.
        game.Shuffle(2500);
        
        
        foreach(Card card in game.deck)
        {
            Console.WriteLine(card.suit.ToString() + " " + card.value);
        }
        
        return 0;
    }
