using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalQuests
{
    public static Quest GoToSchool = new Quest("go_to_school", "Go to school!");

    public static Quest OpenLocker = new Quest("open_locker", "Open the locker!");

    public static Quest TakeBookToLibrary = new Quest("book_to_library", "Take the book back to the library!");

    public static Quest GoToTheoryClass = new Quest("theory_class_quest", "Go to the theory class!");

    public static Quest GoToBathroom = new Quest("go_to_bathroom", "Go to the toilet in the bathroom!");

    public static Quest PickupWCFragment = new Quest("wc_fragment", "Pickup the key fragment!");

    public static Quest GoToPotionClass = new Quest("potion_class", "Go to your Potion class!");

    public static Quest PickupStatueFragment = new Quest("statue_fragment", "Pickup the key fragment next to the statue!");

    public static Quest CraftKey = new Quest("craft_key", "Craft the key using the fragments in the Potion Lab!");

    public static Quest GoToBasement = new Quest("go_to_basement", "Go to the basement and unlock the door!");

    public static Quest EnterDoor = new Quest("enter_door", "Cross through the door!");

    public static Quest GoOutBasement = new Quest("go_out_basement", "Go out of the basement!");

    public static Quest ReturnToHouse = new Quest("retrace_steps", "Go to your bedroom, where it all began!");
}
