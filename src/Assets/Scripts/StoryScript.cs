public static class StoryScript
{
    public static Dialogue BedroomStart = new Dialogue("Charles",
        new string[] {
            "Ahhh.. Another day at the Academy of Magic..",
            "Why does everything here always feel so predictable?",
            "It's supposed to be a place full of mysteries, but nothing truly exciting ever happens."
        });
    // sai do quarto e vai ate a escola
    public static Dialogue MeetNpcLocker = new Dialogue("Kingsley", new string[] { "Hey, sorry to bother you... ", "I can't seem to get this locker open. These magical locks are a real headache.", "Could you give me a hand?" });
    // abre o cacifo
    public static Dialogue AfterOpenLoker = new Dialogue("Kingsley",
        new string[] {
            "Thanks a lot! I don’t know what I’d do without your help.",
            "Oh, by the way, could you do me one more favor?",
            "I just noticed one of the books in my locker is nearly overdue.",
            "I really need to return it, but I’ve got an important meeting to get to and can’t make it to the library.",
            "Could you drop it off for me?",
            "It belongs on one of the middle shelves, in the Ancient Arcane Magic section."
        });
    // vai a biblioteca apanhar o livro
    public static Dialogue PutBookSelf = new Dialogue("Charles", new string[] { "This should be the right shelf.. Ancient Arcane Magic, just like they said.", "Wait, what’s this? This book looks pretty different from the others.", "Let me take a closer look..." });
    // spawna livro com chave
    //texto pagina livro
    // // // The lost key and the void are bound by an ancient fate. When the key finds its place, the slumbering door shall awaken, revealing what lies beyond.
    public static Dialogue GoToTheoryClass = new Dialogue("Charles", new string[] { "Wait, is that a key hidden inside?", "Oh no, look at the time! I’m already late for the theoretical class. I need to hurry!" });
    // vai aula teorica e passa a aula
    public static Dialogue GoToBathroom = new Dialogue("Charles", new string[] { "Ugh, I’m not feeling so well…", "Maybe I should head to the bathroom." });
    // tem a visao do mini game
    public static Dialogue AfterVision = new Dialogue("Charles", new string[] { "What just happened? Was that a vision?", "Thankfully, I know telekinesis or I would have been lost!", "But it felt like time flew by... I need to hurry to the Potions class before I completely miss it!" });
    // vai pocoes class
    public static Dialogue ProfPotions = new Dialogue("Lachaln", new string[] { "You’re late! I told you that today’s lesson was vital.", "We’ll delve into crafting arcane magical items using spells and potions.", "Time is essential in the world of magic, don’t you see? Take a seat!" });
    // vai a mesa
    public static Dialogue PotionPaper = new Dialogue("Charles", new string[] { "What's this? A note tucked away on the table..." });
    // public static Dialogue Paper = new Dialogue("", new string[] { "To the seeker of hidden truths,\nIn the garden stands a sentinel of stone,\nGuarding an enigma that binds what was lost." });
    public static Dialogue AfterPaper = new Dialogue("Charles", new string[] { "First the vision and now this note...", "Could they be connected?" });
    // // // NOTA ESTATUA
    // public static Dialogue StatueEnigma = new Dialogue("", new string[] { "The path to the truth is shaped by what fits the void.\nPlace that which completes, and the veil shall lift.\nOnly then shall the sealed secrets emerge from the shadows." });
    // mexe o cubo
    public static Dialogue AfterPickLastFragment = new Dialogue("Charles", new string[] { "This seems to be the final fragment...", "Maybe I can craft it in the potions room." });
    //vai a aula de poçoes
    // animacao da chave a subir como a overlay do livro
    public static Dialogue AfterCraftKey = new Dialogue("Charles", new string[] { "Finally, the key!\nActually, I remember seeing a strange door in the basement some time ago.", "I have to go check it out." });
    // vai cave
    public static Dialogue BeforeOpenDoor = new Dialogue("Charles", new string[] { "Here it is... The door.", "I know it! It seems like the key fits perfectly..." });
    // vai a porta sai
    public static Dialogue AfterPassDoor = new Dialogue("Charles",
        new string[]{
            "Where am I? The door is locked...",
            "I walked through, and I’m back where I started... everything is in ruins.",
            "Where's the key? What just happened?\nI need to go out of this place..."
        });
    //sai com o lockpick
    public static Dialogue UnlockDoor = new Dialogue("Charles", new string[] { "I must retrace all my steps! I should go where it all began." });
    // vai explorar, no quarto com o boss
    public static Dialogue Player1 = new Dialogue("Charles", new string[] { "Who are you? What are you doing here?" });
    public static Dialogue Boss1 = new Dialogue("Velgrath", new string[] { "Ah, you’ve finally arrived. I’ve been waiting a long time for someone to break the seal. This is where it all begins." });

    public static Dialogue Player2 = new Dialogue("Charles", new string[] { "Break the seal? What do you mean?" });
    public static Dialogue Boss2 = new Dialogue("Velgrath", new string[] { "The seal that held chaos at bay. Your curiosity and bravery have opened the door to something much greater.", "You’re about to discover your true destiny." });

    public static Dialogue Player3 = new Dialogue("Charles", new string[] { "I won’t let you do whatever you want!" });
    public static Dialogue Boss3 = new Dialogue("Velgrath", new string[] { "Oh so naive! You’re already part of the game!", "The real challenge has just begun... Muahahahah" });
}
