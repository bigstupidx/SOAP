using UnityEngine;
using System.Collections;


//
// This script is on the tile prefab and the obstacles are put into their corresponding arrays
// for further manipulation in the code

public class ObstacleManager : MonoBehaviour {

    public GameObject[] spike_obstacles; 
    public GameObject[] moving_wall_obstaclesLR; 
	public GameObject[] moving_wall_obstaclesUD;
	public GameObject[] crush_wall_obstacles; 
    public GameObject[] spinning_obstacles;
    public GameObject[] static_obstacles;
	public GameObject[] falling_obstacles;

    private int[] spike_speed = { 5, 9, 12 };
    private int[] wall_speed = { 5, 9, 12 };
    private int[] platform_speed = { 1, 2, 4 };
    private int[] spinning_speed = { 30, 50, 70 };
	//private int[] falling_speed = { 30, 50, 70 };
    private float[] spike_timing = { 8, 2, 3, 4 };

    private Animator the_animator;
	// The above can be done for other obstacles if necessary

	private Vector2 force_push_left = new Vector2(-6.0f, 0.0f);
	private Vector2 force_push_right = new Vector2(6.0f, 0.0f);
	private Vector2 force_push_up = new Vector2(0.0f, 8.0f);
    // Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


    // Move spikes in the tile
	public void moveSpikes()
    {
        for (int i = 0; i < spike_obstacles.Length; i++)
        {
            if (spike_obstacles[i].transform.parent.gameObject.activeSelf == true)
            {
				if(spike_obstacles[i].transform.parent.parent.gameObject.tag == "no_spike_delay")
				{
					the_animator = spike_obstacles[i].GetComponent<Animator>();

					the_animator.SetBool("is_moving", true);
				}

				if(spike_obstacles[i].transform.parent.parent.gameObject.tag == "half_spike_delay")
				{
					the_animator = spike_obstacles[i].GetComponent<Animator>();

					StartCoroutine(spikeDelayTime(the_animator, 2.0f));
				}

				if(spike_obstacles[i].transform.parent.parent.gameObject.tag == "full_spike_delay")
				{
					the_animator = spike_obstacles[i].GetComponent<Animator>();

					StartCoroutine(spikeDelayTime(the_animator, 4.0f));
				}
			}
        }
    }

	public void stopSpikes()
	{
		for (int i = 0; i < spike_obstacles.Length; i++)
		{
			the_animator = spike_obstacles[i].GetComponent<Animator>();

			the_animator.SetBool("is_moving", false);
		}
	}

	public void moveCrushWalls()
	{
		for (int i = 0; i < crush_wall_obstacles.Length; i++)
		{
			if (crush_wall_obstacles[i].GetComponent<IsMoving>().is_moving == true)
			{
				if(crush_wall_obstacles[i].transform.parent.gameObject.tag == "crush_wall_LR")
				{
					crush_wall_obstacles[i].transform.Translate(platform_speed[1] * Time.deltaTime, 0, 0);
				}

				if(crush_wall_obstacles[i].transform.parent.gameObject.tag == "crush_wall_RL")
				{
					crush_wall_obstacles[i].transform.Translate(platform_speed[1] * -Time.deltaTime, 0, 0);
				}
			}

			else
			{
				if(crush_wall_obstacles[i].transform.parent.gameObject.tag == "crush_wall_LR")
				{
					crush_wall_obstacles[i].transform.Translate(platform_speed[1] * -Time.deltaTime, 0, 0);
				}

				if(crush_wall_obstacles[i].transform.parent.gameObject.tag == "crush_wall_RL")
				{
					crush_wall_obstacles[i].transform.Translate(platform_speed[1] * Time.deltaTime, 0, 0);
				}
			}
		}
	}
    // Move walls in the tile
	public void moveWallsLR()
    {
		for (int i = 0; i < moving_wall_obstaclesLR.Length; i++)
        {
            // code to move walls and time their offsets (if required)
			if (moving_wall_obstaclesLR[i].GetComponent<IsMoving>().is_moving == true)
			{
				if(moving_wall_obstaclesLR[i].transform.parent.parent.gameObject.activeSelf == true)
				{
					if(moving_wall_obstaclesLR[i].transform.parent.gameObject.tag == "move_wall_normal_speed")
					{
						moving_wall_obstaclesLR[i].transform.Translate(platform_speed[1] * Time.deltaTime, 0, 0);
					}

					if(moving_wall_obstaclesLR[i].transform.parent.gameObject.tag == "move_wall_half_speed")
					{
						moving_wall_obstaclesLR[i].transform.Translate(platform_speed[0] * Time.deltaTime, 0, 0);
					}

					if(moving_wall_obstaclesLR[i].transform.parent.gameObject.tag == "move_wall_double_speed")
					{
						moving_wall_obstaclesLR[i].transform.Translate(platform_speed[2] * Time.deltaTime, 0, 0);
					}
				}
			}

			else
			{
				if(moving_wall_obstaclesLR[i].transform.parent.parent.gameObject.activeSelf == true)
				{
					if(moving_wall_obstaclesLR[i].transform.parent.gameObject.tag == "move_wall_normal_speed")
					{
						moving_wall_obstaclesLR[i].transform.Translate(platform_speed[1] * -Time.deltaTime, 0, 0);
					}

					if(moving_wall_obstaclesLR[i].transform.parent.gameObject.tag == "move_wall_half_speed")
					{
						moving_wall_obstaclesLR[i].transform.Translate(platform_speed[0] * -Time.deltaTime, 0, 0);
					}

					if(moving_wall_obstaclesLR[i].transform.parent.gameObject.tag == "move_wall_double_speed")
					{
						moving_wall_obstaclesLR[i].transform.Translate(platform_speed[2] * -Time.deltaTime, 0, 0);
					}
				}
			}
        }
    }

    public void moveWallsUD()
    {
		for (int i = 0; i < moving_wall_obstaclesUD.Length; i++)
        {
            // code to move walls and time their offsets (if required)
			if (moving_wall_obstaclesUD[i].GetComponent<IsMoving>().is_moving == true)
			{
				if (moving_wall_obstaclesUD[i].transform.parent.parent.gameObject.activeSelf == true)
				{
					moving_wall_obstaclesUD[i].transform.Translate(0, platform_speed[0] * Time.deltaTime, 0);
				}
			}

			else
			{
				if(moving_wall_obstaclesUD[i].transform.parent.parent.gameObject.activeSelf == true)
				{
					moving_wall_obstaclesUD[i].transform.Translate(0, platform_speed[0] * -Time.deltaTime, 0);
				}

			}
        }
    }

    // Same as obove for other arrays (other than static_obstacles)

	public void spinWalls()
    {
		for (int i = 0; i < spinning_obstacles.Length; i++)
        {
			if(spinning_obstacles[i].transform.parent.parent.gameObject.activeSelf == true)
			{
            	// code to move walls and time their offsets (if required)
				//spinning_obstacles[i].transform.Rotate(0, 0, spinning_speed[1] * Time.deltaTime);

				if(spinning_obstacles[i].transform.parent.gameObject.tag == "obstacle_spin_counterclockwise")
				{
					spinning_obstacles[i].transform.Rotate(0, 0, spinning_speed[1] * Time.deltaTime);
				}

				if(spinning_obstacles[i].transform.parent.gameObject.tag == "obstacle_spin_clockwise")
				{
					spinning_obstacles[i].transform.Rotate(0, 0, spinning_speed[1] * -Time.deltaTime);
				}
			}
        }
    }

    public void dropBalls()
    {
		for (int i = 0; i < falling_obstacles.Length; i++)
		{
			if(falling_obstacles[i].transform.parent.parent.parent.gameObject.activeSelf == true)
			{
				falling_obstacles[i].GetComponent<Rigidbody2D>().isKinematic = false;

				if(falling_obstacles[i].gameObject.tag == "force_push_left")
				{
					falling_obstacles[i].GetComponent<Rigidbody2D>().AddForce(force_push_left);
				}

				if(falling_obstacles[i].gameObject.tag == "force_push_right")
				{
					falling_obstacles[i].GetComponent<Rigidbody2D>().AddForce(force_push_right);
				}

				if(falling_obstacles[i].gameObject.tag == "force_push_up")
				{
					falling_obstacles[i].GetComponent<Rigidbody2D>().AddForce(force_push_up);
				}
			}
		}
    }

	IEnumerator spikeDelayTime(Animator animator, float delay)
 	{
     	yield return new WaitForSeconds(delay);
 
		animator.SetBool("is_moving", true);
 	}
}
