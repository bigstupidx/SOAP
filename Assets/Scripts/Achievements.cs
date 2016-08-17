using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

//
// This script is referenced in PointManager, TailLoader, CBAds, and SOAPStoreEvents
//


public class Achievements : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {

        // These are being called in leaderboards script
        //
        // Recommended for debugging:
        //PlayGamesPlatform.DebugLogEnabled = true;

        // Activate the Google Play Games platform
        //PlayGamesPlatform.Activate();

        // TODO: Remove if this messes up leaderboards
        // log the user in
        #if UNITY_ANDROID
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Debug.Log("Login success");
                }
                else
                {
                    Debug.Log("Login failed");
                }
            });
        #endif
	}
	

    // Unlock the beginner achievement
    public static void beginnerAchievement()
    {
        string beginner_achievement_id = GPGSIds.achievement_beginner;
        Social.ReportProgress(beginner_achievement_id, 100.0f, (bool success) =>
        {
            if (success) 
            {
                Debug.Log("Beginner achievement unlocked!");
            } 
            
            else 
            {
                Debug.Log("Failed to unlock beginner achievement.");
            }
        });
    }

    // Unlock the just_getting_the_hang_of_it achievement
    public static void justGettingTheHangOfItAchievement()
    {
        string just_getting_the_hang_of_it_achievement_id = GPGSIds.achievement_just_getting_the_hang_of_it;
        Social.ReportProgress(just_getting_the_hang_of_it_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Just_Getting_The_Hang_Of_It achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock just_getting_the_hang_of_it achievement.");
            }
        });
    }


    // Unlock the achievement_anaconda achievement
    public static void anacondaAchievement()
    {
        string achievement_anaconda_achievement_id = GPGSIds.achievement_anaconda;
        Social.ReportProgress(achievement_anaconda_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Achievement_Anaconda achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock achievement_anaconda achievement.");
            }
        });
    }


    // Unlock the titanoboa achievement
    public static void titanoboaAchievement()
    {
        string titanoboa_achievement_id = GPGSIds.achievement_titanoboa;
        Social.ReportProgress(titanoboa_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Titanoboa achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock titanoboa achievement.");
            }
        });
    }


    // Unlock the orochimarus_disciple achievement
    public static void orochimarusDiscipleAchievement()
    {
        string orochimarus_disciple_achievement_id = GPGSIds.achievement_orochimarus_disciple;
        Social.ReportProgress(orochimarus_disciple_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Orochimarus_Disciple achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock orochimarus_disciple achievement.");
            }
        });
    }


    // Unlock the proficient achievement
    public static void proficientAchievement()
    {
        string proficient_achievement_id = GPGSIds.achievement_proficient;
        Social.ReportProgress(proficient_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Proficient achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock proficient achievement.");
            }
        });
    }


    // Unlock the massive_facial_reconstruction achievement
    public static void massiveFacialReconstructionAchievement()
    {
        string massive_facial_reconstruction_achievement_id = GPGSIds.achievement_massive_facial_reconstruction;
        Social.ReportProgress(massive_facial_reconstruction_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Massive_Facial_Reconstruction achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock massive_facial_reconstruction achievement.");
            }
        });
    }


    // Unlock the so_much_death achievement
    public static void soMuchDeathAchievement()
    {
        string so_much_death_achievement_id = GPGSIds.achievement_so_much_death;
        Social.ReportProgress(so_much_death_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("So_Much_Death achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock so_much_death achievement.");
            }
        });
    }


    // Unlock the expert achievement
    public static void expertAchievement()
    {
        string expert_achievement_id = GPGSIds.achievement_expert;
        Social.ReportProgress(expert_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Expert achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock expert achievement.");
            }
        });
    }


    // Unlock the must_have_them_all achievement
    public static void mustHaveThemAllAchievement()
    {
        string must_have_them_all_achievement_id = GPGSIds.achievement_must_have_them_all;
        Social.ReportProgress(must_have_them_all_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Must_Have_Them_All achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock must_have_them_all achievement.");
            }
        });
    }


    // Unlock the python achievement
    public static void pythonAchievement()
    {
        string python_achievement_id = GPGSIds.achievement_python;
        Social.ReportProgress(python_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Python achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock python achievement.");
            }
        });
    }


    // Unlock the for_a_rainy_day achievement
    public static void forARainyDayAchievement()
    {
        string for_a_rainy_day_achievement_id = GPGSIds.achievement_for_a_rainy_day;
        Social.ReportProgress(for_a_rainy_day_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("For_A_Rainy_Day achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock for_a_rainy_day achievement.");
            }
        });
    }


    // Unlock the master achievement
    public static void masterAchievement()
    {
        string master_achievement_id = GPGSIds.achievement_master;
        Social.ReportProgress(master_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Master achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock master achievement.");
            }
        });
    }


    // Unlock the shedding_season achievement
    public static void sheddingSeasonAchievement()
    {
        string shedding_season_achievement_id = GPGSIds.achievement_shedding_season;
        Social.ReportProgress(shedding_season_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Shedding_Season achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock shedding_season achievement.");
            }
        });
    }


    // Unlock the intermediate achievement
    public static void intermediateAchievement()
    {
        string intermediate_achievement_id = GPGSIds.achievement_intermediate;
        Social.ReportProgress(intermediate_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Intermediate achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock intermediate achievement.");
            }
        });
    }


    // Unlock the masochist achievement
    public static void masochistAchievement()
    {
        string masochist_achievement_id = GPGSIds.achievement_masochist;
        Social.ReportProgress(masochist_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Masochist achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock masochist achievement.");
            }
        });
    }


    // Unlock the this_gets_easier_right achievement
    public static void thisGetsEasierRightAchievement()
    {
        string this_gets_easier_right_achievement_id = GPGSIds.achievement_this_gets_easier_right;
        Social.ReportProgress(this_gets_easier_right_achievement_id, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("This gets easeir right achievement unlocked!");
            }

            else
            {
                Debug.Log("Failed to unlock this gets easeir right achievement.");
            }
        });
    }
    
}
